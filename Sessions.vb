Imports System.Data
Public Class LabelSessions
    Dim row As Integer = 0
    Dim cellValue As String
    Dim SelectedSession As String
    Dim InialDraw As Boolean = True
    Public dt As DataTable = New DataTable("Sessions")
    Private Type As String
    Private Code As String
    Private Exp As Boolean
    Private Labeling As Boolean
    Private LabelForm As Label
    Private PricingForm As PricingJobMain
    Private GetInv As GetInv
    Private RecTra As Rectra
    Private PriceJob As PricingJob
    Public Sub New(ByVal _Type As String, ByVal _Code As String, ByVal _Exp As Boolean)
        InitializeComponent()
        Type = _Type
        Code = _Code
        Exp = _Exp
        Labeling = True
    End Sub
    Public Sub New(ByVal _Type As String, ByVal _Code As String)
        InitializeComponent()
        Type = _Type
        Code = _Code
        Labeling = False
    End Sub
    Private Sub Sessions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Inialize()
        If Not Labeling Then
            Print.Visible = False
        Else
            Print.Visible = True
        End If
        If Labeling And Type = "0" And Code = "SHELF" Then
            PlusJob.Visible = True
        End If

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub FillGrid()
        ' Set datagrid style and excute query to fill datagrid
        Try
            DataGrid1.DataSource = dt
            If InialDraw = True Then
                If Labeling Then
                    SetDataGridColumnSize(DataGrid1, 60, 67, 38, 60, 60)
                    DataGrid1.Font = New Font("Arial", 10, FontStyle.Regular)
                ElseIf Not Labeling And (Code = "2" Or Code = "3") Then
                    SetDataGridColumnSize(DataGrid1, 65, 100, 85, 38)
                    DataGrid1.Font = New Font("Arial", 9, FontStyle.Regular)
                ElseIf Not Labeling And Code = "5" Then
                    SetDataGridColumnSize(DataGrid1, 105, 145, 38)
                    DataGrid1.Font = New Font("Arial", 9, FontStyle.Regular)
                End If
                InialDraw = False
            End If
        Catch ex As Exception
            MessageBox("Can't fetch sessions")
        End Try
    End Sub
    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Plus_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Plus.Click
        UpToDate()
        ThreadTimer.Dispose()
        If Labeling Then
            LabelForm = New Label(SessId(Type), 1, Type, Code, Exp, False)
            LabelForm.ShowDialog()
            LabelForm.Dispose()
        Else
            GetInv = New GetInv("", Type, Code)
            GetInv.ShowDialog()
            GetInv.Dispose()
        End If
        InializeTimer()
        FillDatatable()

        If dt.Rows.Count > 0 Then
            DataGrid1.UnSelect(0)
            DataGrid1.Select(dt.Rows.Count - 1)
        End If
    End Sub
    Private Sub PlusJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlusJob.Click
        UpToDate()
        ThreadTimer.Dispose()
        Cursor.Current = Cursors.WaitCursor
        PriceJob = New PricingJob(SessId(Type), 0, Type, Code, Exp, False)
        PriceJob.ShowDialog()
        PriceJob.Dispose()
        InializeTimer()
        FillDatatable()
    End Sub
    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        Cursor.Current = Cursors.WaitCursor
        UpToDate()
        ThreadTimer.Dispose()
        SelectedSession = Get_SelectedSession(0)
        If SelectedSession <> String.Empty Or SelectedSession <> Nothing Then
            'If Get_SelectedSession(1) = String.Empty Then
            If Labeling And Get_SelectedSession(1) = String.Empty Then
                LabelForm = New Label(Get_SelectedSession(0), 2, Type, Code, Exp, False)
                LabelForm.ShowDialog()
                LabelForm.Dispose()
            ElseIf Labeling And Get_SelectedSession(1) <> String.Empty Then
                Dim JobNo As String = Get_SelectedSession(1)
                Dim MobilePrinting As Boolean = MobilePrintingJob(Get_SelectedSession(0))
                If MobilePrinting Then
                    Cursor.Current = Cursors.WaitCursor
                    Dim PrintDialog As PrintDialog = New PrintDialog(Type, Code, Exp, 1, True, JobNo, Get_JobDesc(JobNo), SelectedSession, Get_PricingJobRemainingLines(JobNo), True)
                    PrintDialog.ShowDialog()
                    PrintDialog.Dispose()
                    'If PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    '    PrintDialog.Dispose()

                    '    PricingForm = New PricingJobMain(SelectedSession, JobNo, Get_JobDesc(JobNo), 1, Type, Code, Exp, True, Get_PricingJobRemainingLines(JobNo))
                    '    PricingForm.ShowDialog()
                    '    PricingForm.Dispose()
                    'Else
                    '    PrintDialog.Dispose()
                    'End If
                Else
                    PricingForm = New PricingJobMain(SelectedSession, JobNo, Get_JobDesc(JobNo), 1, Type, Code, Exp, False, Get_PricingJobRemainingLines(JobNo))
                    PricingForm.ShowDialog()
                    PricingForm.Dispose()
                End If
            Else
                RecTra = New Rectra(Get_SelectedSession(0), Type, Code, Get_SessRefNo, CStr(DataGrid1.Item(row, 1)), CStr(DataGrid1.Item(row, 2)))
                RecTra.ShowDialog()
                RecTra.Dispose()
            End If

            If dt.Rows.Count > 0 Then
                DataGrid1.UnSelect(0)
                DataGrid1.Select(dt.Rows.Count - 1)
            Else
                SelectedSession = ""
            End If
        Else
            InializeTimer()
            Return
        End If
        InializeTimer()
        FillDatatable()
    End Sub
    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        'Select whole row 
        DataGrid1.Select(DataGrid1.CurrentRowIndex)

        'get row index selected
        row = DataGrid1.CurrentRowIndex
    End Sub
    Public Function Get_SelectedSession(ByVal Column As Integer) As String
        Try
            cellValue = DataGrid1.Item(row, Column).ToString
        Catch ex As Exception
            MessageBox("No row selected")
            Cursor.Current = Cursors.Default
            Return Nothing
        End Try

        Return cellValue
    End Function
    Private Sub SetDataGridColumnSize(ByRef DG As DataGrid, ByVal ParamArray cols As Integer())
        ' Datagrid styling
        Dim DT As DataTable = CType(DG.DataSource, DataTable)
        Dim dgts As DataGridTableStyle = New DataGridTableStyle()
        dgts.MappingName = DT.TableName

        For i As Integer = 0 To DT.Columns.Count - 1
            Dim dgCol As DataGridTextBoxColumn = New DataGridTextBoxColumn()
            dgCol.MappingName = DT.Columns(i).ColumnName
            dgCol.HeaderText = dgCol.MappingName

            If cols(i) <> -1 Then
                dgCol.Width = cols(i)
            End If
            dgts.GridColumnStyles.Add(dgCol)
        Next

        DG.TableStyles.Clear()
        DG.TableStyles.Add(dgts)
        dgts.Dispose()
    End Sub
    Private Sub Delete_Session()
        Try
            If Labeling Then
                db.Delete("[Session Label Line]", String.Format("[Session ID] = '{0}'", SelectedSession))
                db.Delete("[Session Header]", String.Format("[ID] = '{0}'", SelectedSession))
            Else
                db.Delete("[P/R Line]", String.Format("[Document No.] = '{0}'", SelectedSession))
                db.Delete("[P/R Header]", String.Format("[No.] = '{0}'", SelectedSession))
            End If           
        Catch ex As Exception
            MessageBox("Error Deleting Session")
        Finally
            DBClose(True)
        End Try
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            SelectedSession = Get_SelectedSession(0)
            Dim PricingJobID = Get_SelectedSession(1)
            Dim MobilePrinting As Boolean = MobilePrintingJob(Get_SelectedSession(0))
            Dim ans As MsgBoxResult
            If SelectedSession <> String.Empty Then
                ans = MsgBox("Delete session " + "'" + SelectedSession + "'", MsgBoxStyle.YesNo, Nothing)
                If ans = vbYes Then
                    Cursor.Current = Cursors.WaitCursor
                    If Labeling And PricingJobID <> "" And PricingJobID <> Nothing Then
                        If MobilePrinting Then
                            MessageBox("Can't unassign a mobile pricing job ")
                            Cursor.Current = Cursors.Default
                            Return
                        End If
                        Dim Result As Boolean = UnAssign_PricingJob(PricingJobID)
                        If Result Then
                            Delete_Session()
                            Delete_JobLines(PricingJobID)
                        Else
                            MessageBox(String.Format("Could not delete session {0},Unable to unassign pricing job try again", SelectedSession))
                        End If
                    Else
                        Delete_Session()
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            FillDatatable()
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub Clear_DG()
        'Clear Prevoius data
        DataGrid1.DataSource = Nothing
        DataGrid1.Refresh()
        dt.Clear()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sync_Nav.Click
        PostSession()
    End Sub
    Private Sub FillDatatable()
        dt.Clear()
        Try
            If Labeling Then
                db.read("H.[ID] As [ID],H.[Job ID], COALESCE(l.[Lines], 0 ) AS [Lines] , COALESCE(P.[Remaining] , 0) AS [Remaining] ,COALESCE(PN.[NoReason],0) as [NoReason]", _
                "[Session Header] AS H " + _
                "LEFT JOIN (SELECT [Session ID],COUNT([Line No.]) as [Lines],[Label Code] from [Session Label Line] where [Label Code] = '" + Code + "' " + _
                "GROUP BY [Session ID],[Label Code]) l" + _
             " On l.[Session ID] = H.[ID]" + _
                   " LEFT JOIN (SELECT [Job No.],COUNT([Line No.]) as [Remaining] from [Pricing Job Lines]" + _
                " GROUP BY [Job No.]) P" + _
             " On  P.[Job No.] = H.[Job ID]" + _
             " LEFT JOIN (SELECT [Job No.],COUNT([Line No.]) as [NoReason] from [Pricing Job Lines] WHERE [Reason Code] = ''" + _
             " GROUP BY [Job No.])  PN" + _
             " On PN.[Job No.] = H.[Job ID]", _
                String.Format("H.[Replicated] = '0' and H.[User ID] = '{0}' and H.[Store No.] = '{1}' and H.[Device ID] = '{2}' and H.[Label Code] = '{3}' " + _
                              "GROUP BY H.[ID],H.[Job ID],l.[Lines],P.[Remaining],PN.[NoReason]", Login.UserId, Store, DeviceID, Code))
            ElseIf Labeling = False And (Code = "2" Or Code = "3") Then
                db.read("H.[No.] as [Serial No], H.[Reference Name] as [Name], H.[Vendor Invoice No.] as [Invoice], COUNT(l.[Document No.]) as [Items]", "" _
                        + "[P/R Header] as H LEFT JOIN (SELECT DISTINCT [Document No.],[Barcode] from [P/R Line]) as l on H.[No.] = l.[Document No.]", _
                        String.Format("[Receiving] = '{0}' AND H.[RF ID] = '{1}'", Code, Login.UserId) + " GROUP BY H.[No.], H.[Reference Name], H.[Vendor Invoice No.]")
            ElseIf Labeling = False And Code = "5" Then
                db.read("H.[No.] as [Serial No], H.[Reference No.] as [To Location], COUNT(l.[Document No.]) as [Items]", "" _
                        + "[P/R Header] as H LEFT JOIN (SELECT DISTINCT [Document No.],[Barcode] from [P/R Line]) as l on H.[No.] = l.[Document No.]", _
                        String.Format("[Picking] = '{0}' AND H.[RF ID] = '{1}'", Code, Login.UserId) + " GROUP BY H.[No.], H.[Reference No.]")
            End If

            dt.Load(dr)
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncAll.Click
        PostAllSessions()
    End Sub
    Private Function Get_DGColumn(ByVal col As Integer) As String()
        Dim rows = dt.Rows.Count
        Dim sessID(rows - 1) As String
        Try
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    sessID(i) = DataGrid1(i, col).ToString
                Next
            End If
        Catch ex As Exception
            MessageBox("Couldn't Fetch Sessions")
        End Try

        Return sessID
    End Function
    Private Function Get_PricingJobRemainingLines(ByVal JobNo As String) As PricingJobLines()
        Dim Index As Integer = 0
        Dim PricingJobLines(0) As PricingJobLines
        db.read("*", "[Pricing Job Lines]", String.Format("[Job No.] = '{0}'", JobNo))

        Try
            While dr.Read
                ReDim Preserve PricingJobLines(Index)
                PricingJobLines(Index).JodNo = dr.GetValue(0)
                PricingJobLines(Index).LineNo = dr.GetValue(1)
                PricingJobLines(Index).ItemNo = dr.GetValue(3)
                PricingJobLines(Index).VarCode = dr.GetValue(2)
                PricingJobLines(Index).UOM = dr.GetValue(4)
                PricingJobLines(Index).NewPrice = dr.GetValue(7)
                PricingJobLines(Index).OldPrice = dr.GetValue(8)
                PricingJobLines(Index).Description = dr.GetValue(5)
                PricingJobLines(Index).ARDesc = dr.GetValue(6)
                PricingJobLines(Index).BarcodeList = dr.GetValue(9)
                PricingJobLines(Index).ScaleItem = dr.GetValue(10)
                PricingJobLines(Index).ReasonCode = dr.GetValue(11)
                Index += 1
            End While
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try

        Return PricingJobLines
    End Function
    Private Function Get_JobDesc(ByVal JobNo As String) As String
        Dim JobDesc As String = ""
        db.read("[Job Description]", "[Session Header]", String.Format("[Job ID] = '{0}'", JobNo))
        If dr.Read Then
            JobDesc = dr.GetValue(0)
        End If
        DBClose(False)

        Return JobDesc
    End Function
    Private Sub Inialize()
        'Clear Previous data
        Clear_DG()

        FillDatatable()
        FillGrid()
        Try
            'DataGrid1.Select(0)
            SelectedSession = DataGrid1.Item(0, 0)
            row = DataGrid1.CurrentRowIndex
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PostSession()      
        Try
            Dim sessID(0) As String
            Dim PricingJob(0) As String
            If Get_SelectedSession(0) <> String.Empty Then
                Cursor.Current = Cursors.WaitCursor
                sessID(0) = Get_SelectedSession(0)
                PricingJob(0) = Get_SelectedSession(1)
                If Labeling Then
                    Dim Post As New PostLabels
                    Post.postSessions(sessID, PricingJob)
                Else
                    Dim Post As New PostPR
                    Dim Ans As MsgBoxResult
                    Ans = MsgBox(String.Format("Skip posting Session {0} after sending?", sessID), MsgBoxStyle.YesNo, Nothing)
                    If Ans = MsgBoxResult.Yes Then
                        Post.postSessions(sessID, False, Code)
                    Else
                        If Code = "5" Then
                            Ans = MsgBox(String.Format("Print Transfer Order?", sessID), MsgBoxStyle.YesNo, Nothing)
                            If Ans = MsgBoxResult.Yes Then
                                Post.postSessions(sessID, True, Code, True)
                            Else
                                Post.postSessions(sessID, True, Code)
                            End If
                        ElseIf Code = "3" Then
                            Post.postSessions(sessID, True, Code)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        Finally
            Inialize()
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub PostAllSessions()
        Try
            Dim Sessid() As String = Get_DGColumn(0)
            Dim PricingJobs() As String = Get_DGColumn(1)
            If Sessid(0) <> String.Empty Then
                Cursor.Current = Cursors.WaitCursor
                If Labeling Then
                    Dim Post As New PostLabels
                    ' Dim in if statement
                    Post.postSessions(Sessid, PricingJobs)
                Else
                    Dim Post As New PostPR
                    Dim Ans As MsgBoxResult
                    Ans = MsgBox(String.Format("Skip posting Session {0} after sending?", Sessid), MsgBoxStyle.YesNo, Nothing)
                    If Ans = MsgBoxResult.Yes Then
                        Post.postSessions(Sessid, False, Code)
                    Else
                        If Code = "5" Then
                            Ans = MsgBox(String.Format("Print Transfer Order?", Sessid), MsgBoxStyle.YesNo, Nothing)
                            If Ans = MsgBoxResult.Yes Then
                                Post.postSessions(Sessid, True, Code, True)
                            Else
                                Post.postSessions(Sessid, True, Code)
                            End If
                        ElseIf Code = "3" Then
                            Post.postSessions(Sessid, True, Code)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        Finally
            Inialize()
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub Sessions_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control

            If e.KeyValue = 112 Then
                UpToDate()
                ThreadTimer.Dispose()
                If Labeling Then
                    LabelForm = New Label(SessId(Type), 1, Type, Code, Exp, False)
                    LabelForm.ShowDialog()
                    LabelForm.Dispose()
                Else
                    GetInv = New GetInv("", Type, Code)
                    GetInv.ShowDialog()
                    GetInv.Dispose()
                End If
                InializeTimer()
                FillDatatable()

                If dt.Rows.Count > 0 Then
                    DataGrid1.UnSelect(0)
                    DataGrid1.Select(dt.Rows.Count - 1)
                End If
            ElseIf e.KeyValue = 8 Then
                Try
                    SelectedSession = Get_SelectedSession(0)
                    Dim PricingJobID = Get_SelectedSession(1)
                    Dim ans As MsgBoxResult
                    If SelectedSession <> String.Empty Then
                        ans = MsgBox("Delete session " + "'" + SelectedSession + "'", MsgBoxStyle.YesNo, Nothing)
                        If ans = vbYes Then
                            Cursor.Current = Cursors.WaitCursor
                            If Labeling And PricingJobID <> "" And PricingJobID <> Nothing Then
                                Dim Result As Boolean = UnAssign_PricingJob(PricingJobID)
                                If Result Then
                                    Delete_Session()
                                    Delete_JobLines(PricingJobID)
                                Else
                                    MessageBox(String.Format("Could not delete session {0},Unable to unassign pricing job try again", SelectedSession))
                                End If
                            Else
                                Delete_Session()
                            End If
                        End If
                    End If
                Catch ex As Exception
                Finally
                    FillDatatable()
                    Cursor.Current = Cursors.Default
                End Try
            ElseIf e.KeyValue = 126 Then
                Cursor.Current = Cursors.WaitCursor
                UpToDate()
                ThreadTimer.Dispose()
                SelectedSession = Get_SelectedSession(0)
                If SelectedSession <> String.Empty Or SelectedSession <> Nothing Then
                    'If Get_SelectedSession(1) = String.Empty Then
                    If Labeling And Get_SelectedSession(1) = String.Empty Then
                        LabelForm = New Label(Get_SelectedSession(0), 2, Type, Code, Exp, False)
                        LabelForm.ShowDialog()
                        LabelForm.Dispose()
                    ElseIf Labeling And Get_SelectedSession(1) <> String.Empty Then
                        Dim JobNo As String = Get_SelectedSession(1)
                        PricingForm = New PricingJobMain(SelectedSession, JobNo, Get_JobDesc(JobNo), 1, Type, Code, Exp, False, Get_PricingJobRemainingLines(JobNo))
                        PricingForm.ShowDialog()
                        PricingForm.Dispose()
                    Else
                        RecTra = New Rectra(Get_SelectedSession(0), Type, Code, Get_SessRefNo, CStr(DataGrid1.Item(row, 1)), CStr(DataGrid1.Item(row, 2)))
                        RecTra.ShowDialog()
                        RecTra.Dispose()
                    End If

                    If dt.Rows.Count > 0 Then
                        DataGrid1.UnSelect(0)
                        DataGrid1.Select(dt.Rows.Count - 1)
                    Else
                        SelectedSession = ""
                    End If
                Else
                    InializeTimer()
                    Return
                End If
                InializeTimer()
                FillDatatable()
            ElseIf e.KeyValue = 113 Then
                PostAllSessions()
            ElseIf e.KeyValue = 114 Then
                PostSession()
            ElseIf e.KeyValue = 125 Then
                Me.Close()
            ElseIf e.KeyValue = 115 Then
                Try
                    SelectedSession = Get_SelectedSession(0)
                    If SelectedSession <> String.Empty Then
                        Print_Handle(SelectedSession, Type, Code)
                    Else
                        MessageBox("No session data available")
                    End If
                Catch ex As Exception
                Finally
                    FillDatatable()

                    Cursor.Current = Cursors.Default
                End Try
            ElseIf e.KeyValue = 38 Then
                ctrl = sender
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl = sender
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function Get_SessRefNo() As String
        Dim RefNo As String = ""
        db.read("[No_]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] = '{0}'", DataGrid1.Item(row, 1).ToString.Replace("'", "''")))
        If dr.Read Then
            RefNo = dr.GetValue(0)
        End If
        DBClose(True)
        Return RefNo
    End Function
    Private Sub PictureBox1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            SelectedSession = Get_SelectedSession(0)
            If SelectedSession <> String.Empty And Get_SelectedSession(1) = String.Empty Then
                Print_Handle(SelectedSession, Type, Code)
            Else
                MessageBox("Prohibited")
            End If
        Catch ex As Exception
        Finally
            FillDatatable()

            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LabelSessions_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class