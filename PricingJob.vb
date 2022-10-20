Imports Symbol.Barcode2
Imports System.Data

Public Class PricingJob
    Private SessionID As String
    Private Action As Integer
    Private Type As String
    Private Code As String
    Private Exp As Boolean
    Private MobilePrinitng As Boolean

    Private PricingForm As PricingJobMain
    Private PrintDialog As PrintDialog
    Private Result As String
    Private PricingJobLines() As PricingJobLines
    Private JobDesc As String
    Private DT As New DataTable

    Dim SelectedSession As String = ""

    Public Sub New(ByVal _SessionID As String, ByVal _Action As Integer, ByVal _Type As String, ByVal _Code As String, ByVal _Exp As Boolean, ByVal _MobilePrinting As Boolean)
        InitializeComponent()
        SessionID = _SessionID
        Action = _Action
        Type = _Type
        Code = _Code
        Exp = _Exp
        MobilePrinitng = _MobilePrinting
    End Sub
    Private Sub PricingJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.Default
        InializeTimer()
        Inialize_Datagrid()
        Fill_datatable()
        If DT.Rows.Count <> 0 Then
            DataGrid1.Select(0)
        End If
    End Sub
    Private Function Assign() As Boolean
        Cursor.Current = Cursors.WaitCursor
        Result = Assign_PricingJob(SelectedSession)
        If Result <> String.Empty Then
            If Result.Substring(0, 1) = "0" Then
                JobDesc = Result.Substring(2)
                Return True
            ElseIf Result.Substring(0, 1) = "1" Then
                MessageBox(Result.Substring(2))
                Return False
            End If
        Else
            MessageBox("Check Network")
            Return False
        End If
    End Function
    Private Sub Inialize_Datagrid()
        DT.Columns.Add("JobID")
        DT.Columns.Add("Key Description")
        DT.Columns.Add("Priority")
        DT.Columns.Add("Lines")

        DataGrid1.DataSource = DT
        SetDataGridColumnSize(DataGrid1, 70, 137, 43, 40)
    End Sub
    Private Sub Fill_datatable()
        Dim PricingHeader As PricingJobHeaderPage.PricingJobHeaderPage() = Fetch_JobList()
        Try
            If PricingHeader.Length = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Index As Integer = 0

        For Index = 0 To PricingHeader.Length - 1
            Dim dp As DataRow = DT.NewRow
            dp("JobID") = PricingHeader(Index).No
            dp("Key Description") = PricingHeader(Index).Key1 + "-" + PricingHeader(Index).Key_Description
            dp("Priority") = PricingHeader(Index).Priority
            dp("Lines") = PricingHeader(Index).No_of_Lines

            DT.Rows.Add(dp)
        Next
        
        If DT.Rows.Count > 5 Then
            SetDataGridColumnSize(DataGrid1, 70, 117, 45, 40)
        End If
    End Sub
    Private Function Get_SelectedSession(ByVal Column As Integer) As String
        Dim cellValue As String = ""
        Try
            cellValue = DataGrid1.Item(DataGrid1.CurrentRowIndex, Column).ToString
        Catch ex As Exception
            MessageBox("No row selected")
            Cursor.Current = Cursors.Default
            Return Nothing
        End Try

        Return cellValue
    End Function
    Private Sub Assign_Handle()
        If Assign() Then
            If Fill_PricingJobLines() Then
                NewShelfHeader()
                AddCounter(Type)
                ThreadTimer.Dispose()
                Cursor.Current = Cursors.Default
                If MobilePrinitng Then
                    PrintDialog = New PrintDialog(Type, Code, Exp, 0, MobilePrinitng, SelectedSession, JobDesc, SessionID, PricingJobLines, True)
                    PrintDialog.ShowDialog()
                    Me.Close()
                Else
                    PricingForm = New PricingJobMain(SessionID, SelectedSession, JobDesc, 0, Type, Code, Exp, MobilePrinitng, PricingJobLines)
                    PricingForm.ShowDialog()
                    PricingForm.Dispose()
                    Me.Close()
                End If
            Else
                Dim Unassigned As Boolean = False
                Dim Count As Integer = 0
                Do Until Unassigned = True Or Count = 3
                    Unassigned = UnAssign_PricingJob(SelectedSession)
                    Count += 1
                Loop
                Delete_Session()
                Delete_JobLines(SelectedSession)
                If Unassigned = False Then
                    MessageBox("Could not Unassign pricing job manually Re-open on nav")
                End If
                Cursor.Current = Cursors.Default
                MessageBox("Failed to assign pricing job try again")
            End If
        Else
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Function Fill_PricingJobLines() As Boolean
        Dim JobFetched As Boolean = False

        PricingJobLines = RetreivePricigJobLines(SelectedSession)

        For i As Integer = 0 To PricingJobLines.Length - 1
            If PricingJobLines(i).ARDesc = Nothing Then
                PricingJobLines(i).ARDesc = " "
            End If
            If PricingJobLines(i).ReasonCode = Nothing Then
                PricingJobLines(i).ReasonCode = " "
            End If
            db.Insert("[Pricing Job Lines]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'", PricingJobLines(i).JodNo, PricingJobLines(i).LineNo, _
                                                       PricingJobLines(i).VarCode, PricingJobLines(i).ItemNo, PricingJobLines(i).UOM, PricingJobLines(i).Description.Replace("'", "''"), PricingJobLines(i).ARDesc.Replace("'", "''"), _
                                                      PricingJobLines(i).NewPrice, PricingJobLines(i).OldPrice, PricingJobLines(i).BarcodeList, PricingJobLines(i).ScaleItem, PricingJobLines(i).ReasonCode))
            If ErrorOcurred Then
                Return False
            End If
        Next
        'For Each JobLine As PricingJobLines In PricingJobLines
        '    db.Insert("[Pricing Job Lines]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'", JobLine.JodNo, JobLine.LineNo, _
        '                                                   JobLine.VarCode, JobLine.ItemNo, JobLine.UOM, JobLine.Description.Replace("'", "''"), JobLine.ARDesc.Replace("'", "''"), _
        '                                                  JobLine.NewPrice, JobLine.OldPrice, JobLine.BarcodeList, JobLine.ScaleItem, JobLine.ReasonCode))
        'Next
        DBClose(True)
        'JobFetched = True

        'If PricingJobLines.Length > 0 Then
        '    For Each JobLine As PricingJobLines In PricingJobLines
        '        db.Insert("[Pricing Job Lines]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'", JobLine.JodNo, JobLine.LineNo, _
        '                                                       JobLine.VarCode, JobLine.ItemNo, JobLine.UOM, JobLine.Description.Replace("'", "''"), JobLine.ARDesc.Replace("'", "''"), _
        '                                                      JobLine.NewPrice, JobLine.OldPrice, JobLine.BarcodeList, JobLine.ScaleItem, JobLine.ReasonCode))
        '    Next
        '    DBClose(True)
        'End If
        
        JobFetched = True
        Return JobFetched
    End Function
    Private Sub NewShelfHeader()
        Try
            If MobilePrinitng Then
                db.Insert("[Session Header]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'", SessId(Type), Login.UserId, Store, DeviceID, Type, DateTime.Now.ToString, "0", Code, "0", "0", SelectedSession, JobDesc, "1"))
            Else
                db.Insert("[Session Header]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'", SessId(Type), Login.UserId, Store, DeviceID, Type, DateTime.Now.ToString, "0", Code, "0", "0", SelectedSession, JobDesc, "0"))
            End If

        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
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
    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If SelectedSession <> Nothing Or SelectedSession <> String.Empty Then
            Assign_Handle()
        End If
    End Sub
    Private Sub MobileAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MobileAssign.Click
        If SelectedSession <> Nothing Or SelectedSession <> String.Empty Then
            MobilePrinitng = True
            Cursor.Current = Cursors.WaitCursor
            Assign_Handle()
        End If
    End Sub

    Private Sub Back_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.Close()
    End Sub

    Private Sub PricingJob_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = 125 Then
            Me.Close()
        End If
    End Sub

    Private Sub JobID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 13 Then
            Assign_Handle()
        End If
    End Sub
    Private Sub Delete_Session()
        db.Delete("[Session Label Line]", String.Format("[Session ID] = '{0}'", SessionID))
        db.Delete("[Session Header]", String.Format("[ID] = '{0}'", SessionID))
    End Sub

    'Private Sub Barcode100_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection)
    '    Try
    '        Dim Barcode As String = ""
    '        For Each D As ScanData In scanDataCollection
    '            Barcode = D.Text
    '        Next

    '        If Barcode <> String.Empty Then
    '            JobID.Text = Barcode.Replace("*", "")
    '            Assign_Handle()
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        If assigned Then
    '            scanDataCollection.Current.Dispose()
    '            Me.Close()
    '        End If
    '    End Try
    'End Sub
    Private Sub DataGrid1_CurrentCellChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        DataGrid1.Select(DataGrid1.CurrentRowIndex)

        SelectedSession = Get_SelectedSession(0)
        Label1.Text = SelectedSession
    End Sub
End Class