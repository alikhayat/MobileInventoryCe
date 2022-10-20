Imports System.Data
Imports Microsoft.Win32
Imports System.Web
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Globalization

Public Class Login
    Dim InitialRun As Boolean
    Public UserId As String = "NA"
    Public Permissions(8) As String
    Public MasterPass As String
    Public LoginLocked As Boolean
    Private Const kSplashUpdateInterval_ms As Integer = 200
    Private Const kMinAmountOfSplashTime_ms As Integer = 5000
    Private Shared splash As SplashForm = Nothing
    
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim splashThread As Thread = New Thread(New ThreadStart(AddressOf StartSplash))
        splashThread.Start()

        EnableWifi()

        'Adjust Timezone and date
        AdjustTimezone()

        'Prevent suspend
        InializeTimer()

        'Read configs
        ReadConfigs()

        'Check if newly deployed DB
        LoginLocked = True
        New_Database()

        'Read Users
        Fill_Users()

        'Load Logo
        FillLogo()

        AdjustTime()
        ValidateNTPTime()
        Version_Control()

        If InitialRun = False Then
            'add the global Statusbar
            Dim comp = New Component1
            Controls.Add(comp.StatusBar1)
            InitialRun = True
        End If

        Label2.Text = " Version: " + My.Resources.Version

        Thread.Sleep((kMinAmountOfSplashTime_ms / 2))

        While splash.GetUpMilliseconds() < kMinAmountOfSplashTime_ms
            Thread.Sleep((kSplashUpdateInterval_ms / 4))
        End While

        CloseSplash()
    End Sub
    Private Sub Login_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        DBClose(True)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginBtn.Click
        Cursor.Current = Cursors.WaitCursor
        Login()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncButton.Click
        SyncDB()
        Clear()
    End Sub
    Private Sub Clear()
        UserBox.Text = String.Empty
        Passbox.Text = String.Empty
        UserBox.Focus()
        Me.Refresh()
    End Sub
    Private Sub FillLogo()
        Try
            PictureBox1.Image = New Bitmap(Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase) + "\Logo's\" + Store + ".png")
            PictureBox1.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Login()
        If LoginLocked Then
            MessageBox("You must restart app where network is available")
        Else
            If UserBox.Text.Trim <> String.Empty Then
                If authenticate() = True Then
                    Get_Permissions()
                    popup.Visible = False
                    Clear()
                    Cursor.Current = Cursors.Default
                    UpToDate()
                    ThreadTimer.Dispose()
                    Dim MainMenu As New MainMen
                    MainMenu.ShowDialog()
                    MainMenu.Dispose()
                    InializeTimer()
                Else
                    popup.Visible = True
                    Clear()
                    Cursor.Current = Cursors.Default
                End If
            Else
                UserBox.Focus()
            End If
        End If
    End Sub
    Private Function authenticate() As Boolean
        ' Excute query 
        db.read("ID, Password", "[" + CompanyName.Replace(".", "_") + "$handHeld User Setup]", String.Format("[Name] = '{0}'", UserBox.Text.Trim))

        ' check whether there is a unique staff that matches the query
        Try
            While dr.Read
                If dr("Password").ToString = Passbox.Text.Trim Or Passbox.Text = MasterPass Then
                    UserId = CStr(dr.GetValue(0))
                    Return True
                Else
                    Return False
                End If
            End While

        Catch ex As Exception
            Return False
        Finally
            DBClose(True)
        End Try

    End Function
    Private Sub Fill_Users()
        UserBox.Items.Clear()
        db.read("[Name]", "[" + CompanyName.Replace(".", "_") + "$Handheld User Setup]", String.Format("[Store] = '{0}' or [Roaming Allowed] = '1' ORDER BY [Name] ASC", Store))
        Try
            While dr.Read
                UserBox.Items.Add(CStr(dr.GetValue(0)))
            End While
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub
    Public Sub Get_Permissions()
        db.read("[Price Check],[Shelf Printing],[Shelf Label Codes],[Item Printing],[Item Label Codes],[Transfer Out],[Transfer In],[Receive],[Inventory Count]", "[" + CompanyName.Replace(".", "_") + "$Handheld User Setup]", String.Format("[ID] = '{0}'", UserId))
        Try
            If db.dr.Read Then
                For i As Integer = 0 To 8
                    Permissions(i) = CStr(db.dr.GetValue(i))
                Next
            Else
                For i As Integer = 0 To 8
                    Permissions(i) = "Null"
                Next
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub

    Private Sub Login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control
            ctrl = sender
            If e.KeyValue = 13 Or e.KeyValue = 126 Then
                If LoginBtn.Enabled = True Then
                    Login()
                End If
            ElseIf e.KeyValue = 125 Then
                'Application.Exit()
            ElseIf e.KeyValue = 38 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Passbox.Text.Trim <> String.Empty Then
            If Passbox.Text.Trim = MasterPass Then
                Dim Counters As New Counters
                Passbox.Text = String.Empty
                ThreadTimer.Dispose()
                Counters.ShowDialog()
                Counters.Dispose()
                InializeTimer()
            End If
        End If
    End Sub
    Private Sub ValidateNTPTime()
        If ValidateDatetime() = False Then
            LoginBtn.Enabled = False
            SyncButton.Enabled = False

            popup.Text = "Device time is out of date." + vbCrLf + "Solution: Exit app, check network, restart app"
            popup.Visible = True
        End If
    End Sub
    Public Shared Sub StartSplash()
        splash = New SplashForm(kSplashUpdateInterval_ms)

        Application.Run(splash)
    End Sub
    Private Sub CloseSplash()
        If splash Is Nothing Then
            Return
        End If

        splash.Invoke(New EventHandler(AddressOf splash.KillMe))
        splash.Dispose()
        splash = Nothing
    End Sub
    'Private Sub ThreadWork()
    '    Try
    '        'Adjust Timezone and date
    '        AdjustTimezone()
    '        AdjustTime()
    '        ValidateNTPTime()
    '        Version_Control()
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class