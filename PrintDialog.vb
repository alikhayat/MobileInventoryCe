Public Class PrintDialog
    Private Printers() As Printer
    Private SelectedPrinter As Printer
    Private Code As String
    Private Type As String
    Private EXP As String
    Private MobilePrinting As Boolean
    Private PricingJob As Boolean
    Private DirectPrinting As Boolean
    Private PrintInfo As String
    Private PricingForm As PricingJobMain
    Private JobNo, JobDesc, SessionID As String
    Private PricingJobLines() As PricingJobLines
    Private Assigned As Boolean
    Private Result As String
    Private Action As Integer
    Public Sub New(ByVal _Printers As Printer(), Optional ByVal _DirectPrinting As Boolean = False, Optional ByVal _PrintInfo As String = "")
        InitializeComponent()
        Printers = _Printers
        PrintInfo = _PrintInfo
        DirectPrinting = _DirectPrinting
    End Sub
    Public Sub New(ByVal _Type As String, ByVal _Code As String, ByVal _EXP As String, ByVal _MobilePrinting As Boolean, Optional ByVal _PricingJob As Boolean = False)
        InitializeComponent()
        Type = _Type
        Code = _Code
        EXP = _EXP
        MobilePrinting = _MobilePrinting
        PricingJob = _PricingJob
    End Sub
    Public Sub New(ByVal _Type As String, ByVal _Code As String, ByVal _EXP As String, ByVal _Action As Integer, ByVal _MobilePrinting As Boolean, ByVal _JobNo As String, ByVal _JobDesc As String, ByVal _SessionID As String, ByVal _PricingJobLines() As PricingJobLines, Optional ByVal _PricingJob As Boolean = True)
        InitializeComponent()
        Type = _Type
        Code = _Code
        EXP = _EXP
        Action = _Action
        MobilePrinting = _MobilePrinting
        JobNo = _JobNo
        JobDesc = _JobDesc
        SessionID = _SessionID
        PricingJobLines = _PricingJobLines
        PricingJob = _PricingJob
    End Sub
    Public Function GetSelectedPrinter() As Printer
        Return SelectedPrinter
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If PricingJob And Action = 0 Then
                Cursor.Current = Cursors.WaitCursor
                Dim Result As Boolean = False
                Dim Count As Integer = 0
                Do Until Result = True Or Count = 3
                    Result = UnAssign_PricingJob(JobNo)
                    Count += 1
                Loop
                If Result Then
                    Delete_Session()
                    Delete_JobLines(JobNo)
                End If
                Cursor.Current = Cursors.Default
            End If
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PrintDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default
        InializeTimer()
        If MobilePrinting Then
            If Not BluetoothEnable() Then
                MessageBox("Could not enable bluetooth")

                Me.Close()
            Else
                Cursor.Current = Cursors.WaitCursor
                Printers = GetMobilePrinters()
                Cursor.Current = Cursors.Default
            End If

        End If
        Button1.Enabled = False
        PrinterList.Items.Clear()
        If Printers.Length = 0 Then
            MessageBox("No printers found")
            Me.Close()
        End If

        For i As Integer = 0 To Printers.Length - 1
            PrinterList.Items.Add(Printers(i).Name)
        Next
        If DirectPrinting Then
            Label1.Visible = True
            Label2.Visible = True
            Label2.Text = PrintInfo
            Quantity.Visible = True
            Quantity.Focus()

            Dim DefaultPrinter As String = GetDefaultPrinterName()
            If DefaultPrinter <> String.Empty Then
                PrinterList.SelectedIndex = PrinterList.Items.IndexOf(DefaultPrinter)
            End If
        End If
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If PrinterList.Items.Count <> 0 Or PrinterList.SelectedIndex <> -1 Then
            SelectedPrinter = Printers(PrinterList.SelectedIndex)
            Cursor.Current = Cursors.WaitCursor
            If MobilePrinting = True Then
                If BluetoothConnect(SelectedPrinter.IP, SelectedPrinter.Port) = True Then
                    If Not PricingJob Then
                        ThreadTimer.Dispose()
                        Dim Label As New Label(SessId(Type), 1, Type, Code, EXP, MobilePrinting)
                        Cursor.Current = Cursors.Default
                        Label.ShowDialog()
                        Label.Dispose()
                        BluetoothDisconnect()
                        InializeTimer()
                    Else
                        PricingForm = New PricingJobMain(SessionID, JobNo, JobDesc, 1, Type, Code, EXP, True, PricingJobLines)
                        PricingForm.ShowDialog()
                        PricingForm.Dispose()
                    End If
                Else
                    Cursor.Current = Cursors.Default
                    If Not BluetoothReconnect() Then
                        MessageBox("Could not Connect to bluetooth printer")

                        Dim Result As Boolean = False
                        Dim Count As Integer = 0
                        Do Until Result = True Or Count = 3
                            Result = UnAssign_PricingJob(JobNo)
                            Count += 1
                        Loop
                        If Result Then
                            Delete_Session()
                            Delete_JobLines(JobNo)
                        End If
                    Else
                        PricingForm = New PricingJobMain(SessionID, JobNo, JobDesc, 1, Type, Code, EXP, True, PricingJobLines)
                        PricingForm.ShowDialog()
                        PricingForm.Dispose()
                    End If
                End If
            ElseIf DirectPrinting = True Then
                If Quantity.Text.Trim = String.Empty Or Quantity.Text.Trim = "0" Then
                    Quantity.Text = "1"
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Cursor.Current = Cursors.WaitCursor
                Me.Close()
            End If
            Me.Close()
        Else
            SelectedPrinter.Valid = False
            MessageBox("Nothing Selected")
            Me.Close()
        End If
    End Sub
    Private Sub PrintDialog_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control
            If e.KeyValue = 38 Then
                ctrl = sender
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl = sender
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            ElseIf e.KeyValue = 125 Then
                If PricingJob And Action = 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Dim Result As Boolean = False
                    Dim Count As Integer = 0
                    Do Until Result = True Or Count = 3
                        Result = UnAssign_PricingJob(JobNo)
                        Count += 1
                    Loop
                    If Result Then
                        Delete_Session()
                        Delete_JobLines(JobNo)
                    End If
                    Cursor.Current = Cursors.Default
                End If

                Me.Close()
            ElseIf e.KeyValue = 13 Or e.KeyValue = 126 Then
                Dim c As Control = ActiveControl
                If c.Name = "Button2" Then
                    Me.Close()
                Else
                    Button1_Click(sender, e)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Delete_Session()
        db.Delete("[Session Label Line]", String.Format("[Session ID] = '{0}'", SessionID))
        db.Delete("[Session Header]", String.Format("[ID] = '{0}'", SessionID))
    End Sub
    
    Private Sub PrintDialog_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MobilePrinting Then
            BluetoothDisable()
        End If
        ThreadTimer.Dispose()
    End Sub

    Private Sub Restrict_Alpha(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(8))
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Quantity.KeyPress
        Restrict_Alpha(e)
    End Sub
End Class