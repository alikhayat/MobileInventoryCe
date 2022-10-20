Imports System.Data

Public Class VendorItem
    Private Code As String
    Private FilteredDT As New DataTable
    Private Row As Integer
    Public Barcode As String
    Public Sub New(Optional ByVal _Code As String = "")
        InitializeComponent()
        Code = _Code
    End Sub
    Private Sub VendorItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        If Code <> String.Empty Then
            If Code = "3" Then
                FillGrid(VT)
            ElseIf Code = "5" Then
                FillGrid(BT)
            End If
        Else
            FillGrid(SL)
        End If    

        SetDataGridColumnSize(DataGrid1, 80, 185)
        FilteredDT.Columns.Add("Barcode", GetType(String))
        FilteredDT.Columns.Add("Description", GetType(String))
        Cursor.Current = Cursors.Default
    End Sub
    'Private Sub Fill_BarcodeDatatable()
    '    Try
    '        If InialFillBT = False Then
    '            db.read("[Barcode No_],[Description]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Description] like '%{0}%' AND [Default Barcode] = '{1}' ORDER BY [Description] ASC" _
    '                                                                                                                 , Search.Text.Trim, 1))
    '            BT.Load(dr)
    '            InialFillBT = True
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        DBClose(False)
    '    End Try
    'End Sub
    Private Sub FillGrid(ByVal Datatable As DataTable)
        DataGrid1.DataSource = Datatable
        SetDataGridColumnSize(DataGrid1, 80, 185)
    End Sub

    Private Sub FilterDatatable(ByVal DataTable As DataTable)
        FilteredDT.Clear()

        Dim Rows As DataRow() = DataTable.Select(String.Format("Description like '%{0}%'", Search.Text))
        For Each Row As DataRow In Rows
            FilteredDT.ImportRow(Row)
        Next
    End Sub
    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If Barcode <> String.Empty Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        DataGrid1.Select(DataGrid1.CurrentRowIndex)
        Row = DataGrid1.CurrentRowIndex
        Barcode = DataGrid1.Item(Row, 0).ToString()
        Desc.Text = DataGrid1.Item(Row, 1).ToString()
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
    Private Sub VendorItem_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = 13 Then
            If Barcode <> String.Empty Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        ElseIf e.KeyValue = 125 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel

            Me.Close()
        End If
    End Sub
    Private Sub Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.TextChanged
        If CheckBox1.Checked = True And Search.Text <> String.Empty Then
            If Code = "3" Then
                FilterDatatable(VT)
            ElseIf Code = "5" Then
                FilterDatatable(BT)
            ElseIf Code = "" Then
                FilterDatatable(SL)
            End If

            FillGrid(FilteredDT)
            'ElseIf CheckBox1.Checked = False And Search.Text.Length >= 5 Then
            '    FilterDatatable(BT)
            '    FillGrid(FilteredDT)
        ElseIf Search.Text.Trim = "" And CheckBox1.Checked = True Then
            Cursor.Current = Cursors.WaitCursor
            If Code = "3" Then
                FillGrid(VT)
            ElseIf Code = "5" Then
                FillGrid(BT)
            End If

            Cursor.Current = Cursors.Default
            'ElseIf Search.Text.Trim = "" And CheckBox1.Checked = False Then
            '    Cursor.Current = Cursors.WaitCursor
            '    FillGrid(BT)
            '    Cursor.Current = Cursors.Default
        End If
    End Sub

    'Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
    '    Search.Text = String.Empty
    '    If CheckBox1.Checked = False Then
    '        Cursor.Current = Cursors.WaitCursor
    '        Fill_BarcodeDatatable()
    '        FillGrid(BT)
    '        Cursor.Current = Cursors.Default
    '    Else
    '        Cursor.Current = Cursors.WaitCursor
    '        FillGrid(VT)
    '        Cursor.Current = Cursors.Default
    '    End If
    'End Sub

    Private Sub VendorItem_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class