Imports System.Windows.Forms
Public Class MainMen
    Dim InitialRun As Boolean
    Private Sessions As LabelSessions
    Private TransIN As TransferIn
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub StartPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Check_Permission()
        'add the global Statusbar
        If InitialRun = False Then
            Dim comp = New Component1
            Controls.Add(comp.StatusBar1)
            InitialRun = True
        End If
    End Sub
    Private Sub LogoutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logoutButton.Click
        Login.UserId = "NA"

        Me.Close()
    End Sub
    Private Sub PriceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriceButton.Click
        UpToDate()
        ThreadTimer.Dispose()
        Dim Pcheck As New PriceCheck
        Pcheck.ShowDialog()
        Pcheck.Dispose()
        InializeTimer()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelingBtn.Click
        UpToDate()
        ThreadTimer.Dispose()
        Dim LabelForm As New Labeling
        LabelForm.ShowDialog()
        LabelForm.Dispose()
        InializeTimer()
    End Sub
    Private Sub MainMen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control
            ctrl = sender
            If e.KeyValue = 13 Or e.KeyValue = 126 Then
                Dim c As Control = ActiveControl
                If c.Name = "SyncButton" Then
                    Sync_Click(c, e)
                ElseIf c.Name = "PriceButton" Then
                    PriceButton_Click(c, e)
                ElseIf c.Name = "LabelingBtn" Then
                    Button1_Click_1(c, e)
                ElseIf c.Name = "Receiving" Then
                    ReceivingBtn_Click(c, e)
                End If
            ElseIf e.KeyValue = 125 Then
                Login.UserId = "NA"

                Me.Close()
            ElseIf e.KeyValue = 38 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Sync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncButton.Click
        Cursor.Current = Cursors.WaitCursor
        SyncDB()
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Check_Permission()
        If Login.Permissions(0) = "0" Then
            PriceButton.BackColor = Color.DimGray
            PriceButton.Enabled = False
        Else
            PriceButton.BackColor = Color.White
            PriceButton.Enabled = True
        End If
        If Login.Permissions(5) = "0" Then
            TransferOutBtn.BackColor = Color.DimGray
            TransferOutBtn.Enabled = False
        Else
            TransferOutBtn.BackColor = Color.White
            TransferOutBtn.Enabled = True
        End If
        If Login.Permissions(6) = "0" Then
            TransferInBtn.BackColor = Color.DimGray
            TransferInBtn.Enabled = False
        Else
            TransferInBtn.BackColor = Color.White
            TransferInBtn.Enabled = True
        End If
        If Login.Permissions(7) = "0" Then
            ReceivingBtn.BackColor = Color.DimGray
            ReceivingBtn.Enabled = False
        Else
            ReceivingBtn.BackColor = Color.White
            ReceivingBtn.Enabled = True
        End If       
        If Login.Permissions(1) = "0" And Login.Permissions(3) = "0" Then
            LabelingBtn.BackColor = Color.DimGray
            LabelingBtn.Enabled = False
        Else
            LabelingBtn.BackColor = Color.White
            LabelingBtn.Enabled = True
        End If
    End Sub

    Private Sub TransferInBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferInBtn.Click
        UpToDate()
        Cursor.Current = Cursors.WaitCursor
        ThreadTimer.Dispose()
        TransIN = New TransferIn()
        TransIN.ShowDialog()
        TransIN.Dispose()
        InializeTimer()
    End Sub

    Private Sub ReceivingBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivingBtn.Click
        UpToDate()
        Cursor.Current = Cursors.WaitCursor
        ThreadTimer.Dispose()
        Sessions = New LabelSessions("2", "3")
        Sessions.ShowDialog()
        Sessions.Dispose()
        InializeTimer()
    End Sub

    Private Sub TransferOutBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferOutBtn.Click
        UpToDate()
        Cursor.Current = Cursors.WaitCursor
        ThreadTimer.Dispose()
        Sessions = New LabelSessions("3", "5")
        Sessions.ShowDialog()
        Sessions.Dispose()
        InializeTimer()
    End Sub

    Private Sub MainMen_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
        Me.Dispose(False)
    End Sub
End Class