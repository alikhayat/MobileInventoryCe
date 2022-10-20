Option Explicit On
Imports System.Data.SqlServerCe
Imports System.Data
Imports System.IO
Imports System.Threading

Module db
    Private Conn As SqlCeConnection
    Private Sync As Sync
    Private LocalDBName As String
    Public TimeSynced As String
    Public Out_Of_Date As Boolean
    Public DBIP As String
    Dim Cmd As New SqlCeCommand
    Public dr As SqlCeDataReader
    Public ErrorOcurred As Boolean = False
    Private LastSyncCheck As DateTime

    Public Sub DBInialize(ByVal _DBIP As String, ByVal WebAlias As String, ByVal Publisher As String, ByVal PublisherDatabase As String, ByVal Publication As String, ByVal PublisherLogin As String, ByVal PublisherPassword As String, ByVal Subscriber As String, ByVal LocalDB As String)
        LocalDBName = LocalDB
        DBIP = _DBIP
        Conn = New SqlCeConnection("Data Source=Application\" + LocalDBName + ".sdf;Max Database Size=512;Persist Security Info=False;")
        Sync = New Sync(DBIP, WebAlias, Publisher, PublisherDatabase, Publication, PublisherLogin, PublisherPassword, Subscriber, LocalDB)
        TimeSynced = Sync.Retreive_TimeSync()
        LastSyncCheck = Get_LastSync()
        'Out_Of_Date = False
    End Sub

    Public Sub SyncDB()
        Dim Last_Preaction As Integer
        If Conn.State = System.Data.ConnectionState.Open Then
            Conn.Close()
        End If

        'If Ping(DBIP, "Could not sync database, check network") Then
        Dim time As String = Sync.SyncNow()
        If time <> String.Empty Then
            TimeSynced = time
            Last_Preaction = Last_Action()
            If Last_Preaction <> -1 Then
                db.Update("[Utility]", String.Format("[Value] = '{0}'", Last_Preaction), "[Key] = 'LastAction'")
            End If
        End If
        'End If
    End Sub

    Public Sub DBClose(ByVal CloseConn As Boolean)
        dr.Close()
        dr.Dispose()
        If CloseConn Then
            Conn.Close()
        End If
    End Sub

    Public Sub read(ByVal Columns As String, ByVal Table As String, ByVal Condition As String)
        Try

            If Conn.State <> System.Data.ConnectionState.Open Then
                Conn.Open()
            End If
            If Condition <> String.Empty Then
                Cmd = New SqlCeCommand(String.Format("SELECT {0} FROM {1} WHERE {2}", Columns, Table, Condition), Conn)
            Else
                Cmd = New SqlCeCommand(String.Format("SELECT {0} FROM {1}", Columns, Table), Conn)
            End If

            dr = Cmd.ExecuteReader

        Catch ex As Exception
            MessageBox("Failed at excuting query")
        Finally
            Cmd.Dispose()
        End Try
    End Sub
    Public Sub Insert(ByVal Table As String, ByVal Data As String)
        Try
            If Conn.State <> System.Data.ConnectionState.Open Then
                Conn.Open()
            End If

            Cmd = New SqlCeCommand(String.Format("INSERT INTO {0} VALUES ({1})", Table, Data), Conn)
            Cmd.ExecuteNonQuery()

            ErrorOcurred = False

        Catch ex As Exception
            ErrorOcurred = True
            MessageBox("Failed at excuting query")
        Finally
            Cmd.Dispose()
        End Try
    End Sub
    Public Sub Update(ByVal Table As String, ByVal Column As String, ByVal Condition As String)
        Try
            If Conn.State <> System.Data.ConnectionState.Open Then
                Conn.Open()
            End If

            Cmd = New SqlCeCommand(String.Format("UPDATE {0} SET {1} WHERE {2}", Table, Column, Condition), Conn)
            Cmd.ExecuteNonQuery()

            ErrorOcurred = False
        Catch ex As Exception
            ErrorOcurred = True
            MessageBox("Failed at excuting query")
        Finally
            Cmd.Dispose()
        End Try
    End Sub
    Public Sub Delete(ByVal Table As String, ByVal Condition As String)
        Try
            If Conn.State <> System.Data.ConnectionState.Open Then
                Conn.Open()
            End If
            If Condition <> String.Empty Then
                Cmd = New SqlCeCommand(String.Format("Delete FROM {0} WHERE {1}", Table, Condition), Conn)
            Else
                Cmd = New SqlCeCommand(String.Format("Delete FROM {0}", Table), Conn)
            End If

            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            ErrorOcurred = True
            MessageBox("Failed at excuting query")
        Finally
            Cmd.Dispose()
        End Try
    End Sub
    Public Sub Purge(ByVal Table As String)
        Try
            If Conn.State <> System.Data.ConnectionState.Open Then
                Conn.Open()
            End If

            Cmd = New SqlCeCommand(String.Format("Delete FROM {0}", Table), Conn)
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            Cmd.Dispose()
        End Try
    End Sub
    Public Function Loc_Preaction() As Integer
        db.read("[Value]", "[Utility]", "[Key] = 'LastAction'")
        Dim Preaction As String = ""
        Try
            If db.dr.Read Then
                If CInt(db.dr.GetValue(0)) <> 0 Then
                    Preaction = CInt(db.dr.GetValue(0))
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
        Return Preaction
    End Function
    Public Sub UpToDate()
        'Dim Last_Preaction As Integer
        'Dim T As New Thread(AddressOf Last_Action)

        Try
            Dim Present As DateTime = DateAndTime.Now
            Dim Span As TimeSpan = Present.Subtract(Convert.ToDateTime(TimeSynced))
            Dim span2 As TimeSpan = Present.Subtract(Convert.ToDateTime(LastSyncCheck))
            If Out_Of_Date = True Then
                MessageBox("Database out of sync; please sync now")
            Else
                If (Span.Minutes > 20) Or (Span.Hours > 0) Or (Span.Days > 0) Then
                    'Last_Preaction = T.Start
                    If (span2.Minutes > 10) Or (Span.Hours > 0) Or (Span.Days > 0) Then
                        If Last_Action() > Loc_Preaction() Then
                            LastSyncCheck = DateTime.Now
                            Out_Of_Date = True
                            MessageBox("Database out of sync; please sync now")
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            Out_Of_Date = True
            MessageBox("Database out of sync; please sync now")
        End Try
    End Sub
    Public Sub New_Database()
        Dim Counters As String
        db.read("[Value]", "[Utility]", "[Key] = 'NewDB'")
        If db.dr.Read Then
            If db.dr.GetValue(0) = "true" Then
                Counters = Get_Counters()
                If Counters <> String.Empty Then
                    Dim ItemCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
                    db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ItemCounter), "[Name] = 'ItemSession'")

                    Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

                    Dim ShelfCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
                    db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ShelfCounter), "[Name] = 'ShelfSession'")

                    Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

                    Dim ReceivingCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
                    db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ReceivingCounter), "[Name] = 'ReceivingSession'")

                    Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

                    Dim PickingCounter As String = Counters.Substring(1)
                    db.Update("[Counter]", String.Format("[LastValue] = '{0}'", PickingCounter), "[Name] = 'PickingSession'")

                    db.Update("[Utility]", "[Value] = 'false'", "[Key] = 'NewDB'")
                    Login.LoginBtn.Enabled = True
                    Login.LoginLocked = False
                Else
                    Login.LoginBtn.Enabled = False
                    'Login.LoginLocked = True
                    MessageBox("Check network and restart App")
                End If
            Else
                Login.LoginBtn.Enabled = True
                Login.LoginLocked = False
            End If
        End If
        DBClose(True)
    End Sub
    Public Sub Debug_New_Database()
        Dim Counters As String
        Counters = Get_Counters()
        If Counters <> String.Empty Then
            Dim ItemCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
            db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ItemCounter), "[Name] = 'ItemSession'")

            Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

            Dim ShelfCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
            db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ShelfCounter), "[Name] = 'ShelfSession'")

            Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

            Dim ReceivingCounter As String = Counters.Substring(1, Counters.IndexOf(",") - 1)
            db.Update("[Counter]", String.Format("[LastValue] = '{0}'", ReceivingCounter), "[Name] = 'ReceivingSession'")

            Counters = Counters.Remove(0, Counters.IndexOf(",") + 1)

            Dim PickingCounter As String = Counters.Substring(1)
            db.Update("[Counter]", String.Format("[LastValue] = '{0}'", PickingCounter), "[Name] = 'PickingSession'")

        Else
            MessageBox("Could not update counters")
        End If
        DBClose(True)
    End Sub
    Private Function Get_LastSync() As DateTime
        db.read("[Value]", "Utility", "[Key] = 'LastSync'")
        If db.dr.Read Then
            Return db.dr.GetValue(0)
        End If
        DBClose(True)
    End Function
End Module
Class Sync
    Private replobj As SqlCeReplication

    Public Sub New(ByVal DBIP As String, ByVal WebAlias As String, ByVal Publisher As String, ByVal PublisherDatabase As String, ByVal Publication As String, ByVal PublisherLogin As String, ByVal PublisherPassword As String, ByVal Subscriber As String, ByVal SubscriberConnectionString As String)
        'Setting replication library parameteres
        replobj = New SqlCeReplication()
        replobj.InternetUrl = "http://" + DBIP + "/" + WebAlias + "/sqlcesa35.dll"
        replobj.Publisher = Publisher
        replobj.PublisherDatabase = PublisherDatabase
        replobj.Publication = Publication
        replobj.PublisherSecurityMode = SecurityType.DBAuthentication
        replobj.PublisherLogin = PublisherLogin
        replobj.PublisherPassword = PublisherPassword
        replobj.Subscriber = Subscriber
        replobj.SubscriberConnectionString = "Data Source=Application\" + SubscriberConnectionString + ".sdf;Max Database Size = 512"
    End Sub

    Public Function SyncNow() As String
        Dim Time As String = ""

        'Change cursor state
        Cursor.Current = Cursors.WaitCursor

        Try
            'Begin Synchronization
            replobj.Synchronize()

            'State that sync process has finished
            Time = DateAndTime.Now.ToString
            Write_Record(Time)
            Out_Of_Date = False
            If NTPretrieved = False Then
                AdjustTime()
            End If
            MessageBox("Sync Succeeded")
        Catch ex As Exception
            MessageBox("Sync Failed")
            Time = ""
        Finally
            'replobj.Dispose()
            Cursor.Current = Cursors.Default
        End Try

        Return Time
    End Function
    Private Sub Write_Record(ByVal Time As String)
        db.Update("[Utility]", String.Format("[Value] = '{0}'", Time), "[Key] = 'LastSync'")
    End Sub
    Public Function Retreive_TimeSync() As String
        Dim Time As String = ""
        db.read("[Value]", "[Utility]", "[Key] = 'LastSync'")

        Try
            If db.dr.Read Then
                Time = CStr(db.dr.GetValue(0))
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try

        Return Time
    End Function
End Class