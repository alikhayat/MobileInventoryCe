Imports System.IO
Imports System.Reflection
Imports System.Data

Module AppUtility
    Public Store As String = "", CompanyName As String = ""
    Public VT As New DataTable
    Public BT As New DataTable
    Public SL As New DataTable

    Public Sub Version_Control()
        Dim Ver As String = ""
        'Dim Deploy As New ProcessStartInfo
        'Dim path As String = "Application\DeployDc\DeployDc.exe"
        'Deploy.FileName = "Application\DeployDc\DeployDc.exe"
        db.read("[DC Version]", "[" + CompanyName.Replace(".", "_") + "$Retail Setup]", "")
        Try
            If dr.Read Then
                Ver = CStr(dr.GetValue(0))
            End If
            If Ver <> "" Then
                If CDec(Ver) > CDec(My.Resources.Version) Then
                    MessageBox("Please update your app")
                    'If File.Exists(path) Then
                    '    'Process.Start(Deploy)
                    '    MessageBox("Please update your app")
                    'End If
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub
    Public Sub ReadConfigs()
        'Read configs
        Dim c As String = ""
        Dim allLines As List(Of String) = New List(Of String)

        Try

            For i As Integer = 0 To 2

                If i = 0 Then
                    c = "ENV.txt"
                ElseIf i = 1 Then
                    c = "DB.txt"
                Else
                    c = "API.txt"
                End If

                Dim reader As New System.IO.StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase) + "\" + c)

                Do While Not reader.EndOfStream
                    allLines.Add(reader.ReadLine())
                Loop
                reader.Close()
                reader.Dispose()

                If i = 0 Then
                    CompanyName = ReadLine(1, allLines)
                    allLines.Clear()
                ElseIf i = 1 Then
                    Dim DBIp = ReadLine(1, allLines)
                    Dim WebAlias = ReadLine(2, allLines)
                    Dim Publisher = ReadLine(3, allLines)
                    Dim PublisherLogin = ReadLine(4, allLines)
                    Dim PublisherPassword = ReadLine(5, allLines)
                    Dim Publication = ReadLine(6, allLines)
                    Dim PublisherDatabase = ReadLine(7, allLines)
                    Dim LocalDB = ReadLine(8, allLines)
                    allLines.Clear()
                    DeviceID = Get_DeviceID()
                    DBInialize(DBIp, WebAlias, Publisher, PublisherDatabase, Publication, PublisherLogin, PublisherPassword, DeviceID, LocalDB)
                Else
                    Dim NavIp = ReadLine(1, allLines)
                    Dim InstanceName = ReadLine(2, allLines)
                    Dim SoapPort = ReadLine(3, allLines)
                    Dim NavUsername = Retreive_NTLMParameters(1)
                    Dim NavPassword = Retreive_NTLMParameters(2)
                    Dim WebDomain = Retreive_NTLMParameters(3)
                    allLines.Clear()
                    WebUtilInialize(NavIp, SoapPort, InstanceName, NavUsername, NavPassword, WebDomain)
                End If
            Next
            Store = Get_LocalStore()
            Login.MasterPass = RetrieveMaster()
        Catch ex As Exception
            MessageBox("Check Configs")
            'Application.Exit()
        Finally

        End Try

    End Sub
    Private Function ReadLine(ByVal lineNumber As Integer, ByVal lines As List(Of String)) As String
        Dim s As String = lines(lineNumber - 1)
        Return s.Substring(s.IndexOf(":") + 1).Trim
    End Function
    Public Function Get_LocalStore() As String
        Dim Store As String = ""
        db.read("[Local Store No_]", "[" + CompanyName.Replace(".", "_") + "$Retail Setup]", "")
        Try
            If db.dr.Read Then
                Store = CStr(db.dr.GetValue(0))
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
        Return Store
    End Function
    Public Function Get_ReasonGroup() As String
        Dim ReasonGroup As String = ""
        db.read("[Pricing Job Reason Code Group]", "[" + CompanyName.Replace(".", "_") + "$Retail Setup]", "")

        If db.dr.Read Then
            Reasongroup = db.dr.GetValue(0)
        End If
        DBClose(True)

        Return ReasonGroup
    End Function
    Public Function Cultural(ByVal s As String, ByVal Dec As Boolean) As String
        Try
            Dim d As Decimal
            d = CDec(s)
            If Dec Then
                s = d.ToString("##,##00.00")
            Else
                s = d.ToString("##,##00")
            End If

        Catch ex As Exception
            s = s
        End Try
        Return s
    End Function
    Public Function SessId(ByVal Type As String) As String
        Dim i As Integer = 0
        Dim S As String = String.Empty
        Dim P As String = String.Empty
        If Type = "2" Then
            db.read("[Prefix]", "[Counter]", "Name = 'ReceivingSession'")
            If dr.Read Then
                P = dr.GetValue(0)
                db.Update("[Counter]", String.Format("[Prefix] = '{0}'", P.Substring(0, 1) + DeviceID.Substring(3)), "[Name] = 'ReceivingSession'")
                'If dr.GetValue(0).ToString.Length < 2 Then
            Else
                P = "R"
                db.Update("[Counter]", String.Format("[Prefix] = '{0}'", P + DeviceID.Substring(3)), "[Name] = 'ReceivingSession'")
            End If

            'End If
        ElseIf Type = "3" Then
            db.read("[Prefix]", "[Counter]", "Name = 'PickingSession'")
            If dr.Read Then
                P = dr.GetValue(0)
                'If dr.GetValue(0).ToString.Length < 2 Then
                db.Update("[Counter]", String.Format("[Prefix] = '{0}'", P.Substring(0, 1) + DeviceID.Substring(3)), "[Name] = 'PickingSession'")
            Else
                P = "P"
                db.Update("[Counter]", String.Format("[Prefix] = '{0}'", P + DeviceID.Substring(3)), "[Name] = 'PickingSession'")
            End If
            'End If
            End If

            If Type = "0" Then
                db.read("*", "[Counter]", "Name = 'ShelfSession'")
            ElseIf Type = "1" Then
                db.read("*", "[Counter]", "Name = 'ItemSession'")
            ElseIf Type = "2" Then
                db.read("*", "[Counter]", "Name = 'ReceivingSession'")
            ElseIf Type = "3" Then
                db.read("*", "[Counter]", "Name = 'PickingSession'")
            End If

            Try
                If dr.Read Then
                    i = CInt(dr.GetValue(2).ToString) + 1
                    S = dr.GetValue(1).ToString
                    S = S + String.Format("{0:D6}", i)
                End If

            Catch ex As Exception
                S = CStr(1)
            Finally
                DBClose(True)
            End Try

            Return S
    End Function
    Public Function LabelLineNo(ByVal SessID As String, ByVal LabelCode As String) As Integer
        Dim i As Integer = 0
        db.read("MAX([Line No.]) AS [Line]", "[Session Label Line]", String.Format("[Session ID] = '{0}' and [Label Code] = '{1}'", SessID, LabelCode))
        Try
            If dr.Read Then
                If dr.GetValue(0).ToString <> String.Empty Then
                    i = dr.GetValue(0)
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try

        Return i + 1
    End Function
    Public Function PRLineNo(ByVal SessID As String) As Integer
        Dim i As Integer = 0
        db.read("MAX([Line No.]) AS [Line]", "[P/R Line]", String.Format("[Document No.] = '{0}'", SessID))
        Try
            If dr.Read Then
                If dr.GetValue(0).ToString <> String.Empty Then
                    i = dr.GetValue(0)
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try

        Return i
    End Function

    Public Sub AddCounter(ByVal Type As String)
        Dim i As Integer = 0
        Dim S As String = ""

        If Type = "0" Then
            db.read("[LastValue]", "Counter", "Name = 'ShelfSession'")
        ElseIf Type = "1" Then
            db.read("[LastValue]", "Counter", "Name = 'ItemSession'")
        ElseIf Type = "2" Then
            db.read("[LastValue]", "Counter", "Name = 'ReceivingSession'")
        ElseIf Type = "3" Then
            db.read("[LastValue]", "Counter", "Name = 'PickingSession'")
        End If

        If dr.Read Then
            'If Type = "2" Or Type = "3" Then
            '    S = dr.GetValue(0).ToString.Substring(0, 3)
            '    i = CInt(dr.GetValue(0).ToString.Substring(2) + 1)
            'Else
            i = CInt(dr.GetValue(0).ToString) + 1
            'End If

        End If

        If Type = "0" Then
            db.Update("[Counter]", String.Format("LastValue = '{0}'", i.ToString), "Name = 'ShelfSession'")
        ElseIf Type = "1" Then
            db.Update("[Counter]", String.Format("LastValue = '{0}'", i.ToString), "Name = 'ItemSession'")
        ElseIf Type = "2" Then
            db.Update("[Counter]", String.Format("LastValue = '{0}'", S + i.ToString), "Name = 'ReceivingSession'")
        ElseIf Type = "3" Then
            db.Update("[Counter]", String.Format("LastValue = '{0}'", S + i.ToString), "Name = 'PickingSession'")
        End If
    End Sub
    Public Sub Fill_VendorDataTable(ByVal ReferenceNo As Integer)
        If VT.Rows.Count = 0 Then
            Try
                db.read("B.[Barcode No_] As [Barcode], B.[Description]", "" _
                    + "[" + CompanyName.Replace(".", "_") + "$Barcodes] as B Inner JOIN [" + CompanyName.Replace(".", "_") + "$Item Vendor] as V ON B.[Item No_] = V.[Item No_] AND B.[Variant Code] = V.[Variant Code]", _
                     String.Format("B.[Default Barcode] = '{0}' AND V.[Vendor No_] = '{1}' ", 1, ReferenceNo) _
                    + " GROUP BY B.[Barcode No_],B.[Description]")

                VT.Load(dr)
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try
        End If
    End Sub
    Public Sub Fill_SessionLinesDatatable(ByVal SessionID As String)
        SL.Clear()

        Try
            db.read("[Barcode],[Description]", "[Session Label Line]", String.Format("[Session ID] = '{0}'", SessionID))

            SL.Load(dr)
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Public Sub Fill_BarcodeDataTable()
        If BT.Rows.Count = 0 Then
            Try
                db.read("[Barcode No_] As [Barcode] ,[Description]", "" _
                        + "[" + CompanyName.Replace(".", "_") + "$Barcodes]", "[PLU] <> ''")
                BT.Load(dr)
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try
        End If
    End Sub
    Public Sub Delete_JobLines(ByVal JobNo As String)
        db.Delete("[Pricing Job Lines]", String.Format("[Job No.] = '{0}'", JobNo))
    End Sub
    Public Sub Clear_VendorDataTable()
        VT.Clear()
        VT.Dispose()
    End Sub
    Public Function FindFocusedControl(ByVal container As Control) As Control
        Try
            For Each childControl As Control In container.Controls

                If childControl.Focused Then
                    Return childControl
                End If
            Next

            For Each childControl As Control In container.Controls
                Dim maybeFocusedControl As Control = FindFocusedControl(childControl)

                If maybeFocusedControl IsNot Nothing Then
                    Return maybeFocusedControl
                End If
            Next
        Catch ex As Exception

        End Try

        Return Nothing
    End Function
    Private Function Retreive_NTLMParameters(ByVal Index As Integer) As String
        Dim Param As String = ""
        Dim Valu As String = ""
        Select Case Index
            Case 1
                Param = "WebUsername"
            Case 2
                Param = "WebPassword"
            Case 3
                Param = "WebDomain"
        End Select
        If Param <> String.Empty Then
            db.read("[Value]", "[utility]", String.Format("[Key] = '{0}'", Param))
            If dr.Read Then
                Valu = CStr(dr.GetValue(0))
            End If
        End If
        Return Valu
    End Function
    Public Function RetrieveMaster() As String
        Dim Pass As String = ""
        db.read("[Value]", "[Utility]", "[Key] = 'MasterPassword'")
        If dr.Read Then
            Pass = dr.GetValue(0)
        End If
        Return Pass
    End Function
    Public Function ValidBarcode(ByVal Barcode As String) As Boolean
        db.read("[Valid Barcode]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Barcode No_] = '{0}'", Barcode))
        If dr.Read Then
            Return dr.GetValue(0)
        End If
        DBClose(True)
    End Function
    Public Function MobilePrintingJob(ByVal SessID As String) As Boolean
        db.read("[MobilePrinting]", "[Session Header]", String.Format("[ID] = '{0}'", SessID))
        If dr.Read Then
            Return dr.GetValue(0)
        End If
        DBClose(True)
    End Function
    Public Sub MessageBox(ByVal Message As String)
        ThreadTimer.Dispose()
        MsgBox(Message)
        InializeTimer()
    End Sub
End Module
