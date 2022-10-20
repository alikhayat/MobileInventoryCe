Imports System.Data
Imports Symbol.Barcode2

Public Structure PricingJobLines
    Public JodNo As String
    Public LineNo As Integer
    Public VarCode As String
    Public ItemNo As String
    Public UOM As String
    Public Description As String
    Public ARDesc As String
    Public NewPrice As Decimal
    Public OldPrice As Decimal
    Public BarcodeList As String
    Public ScaleItem As Int16
    Public ReasonCode As String
    Public DolphinNo As String
    Public Vendor As String
    Public VATGroup As String
    Public ProductGroup As String
    Public Quantity As Integer
End Structure
Public Class PricingJobMain
    Private SessionID As String
    Private PricingJobNo As String
    Private Action As Integer
    Private Type As String
    Private Code As String
    Private Exp As Boolean
    Private MobilePrinitng As Boolean
    Private PricingJobLines() As PricingJobLines
    Private JobDesc As String
    Private Flow As New Dictionary(Of String, Integer)
    Private DT As New DataTable

    Dim crAr As New Arabic.Controls.ArabicShape
    Dim TrimmedDigitsL As String = ""
    Dim TrimmedDigitsF As String = ""
    Dim ShowAR As String = ""
    Dim LineNo As Integer = 1
    Dim JobLineNo As Integer = 0
    Dim JobLine As Boolean = False
    Dim JobLineIndex As Integer = -1
    Dim ItemNo, VarCode, Barcode, ARDB, DolphinNo, ProductGroup, Vendor As String
    Dim Marked As Int16 = 0
    Dim NPrice As Decimal = 0
    Dim PreLine As PricingJobLines

    Public Sub New(ByVal _SessionID As String, ByVal _PricingJobNo As String, ByVal _JobDesc As String, ByVal _Action As Integer, ByVal _Type As String, ByVal _Code As String, ByVal _Exp As Boolean, ByVal _MobilePrinting As Boolean, ByVal _PricingJobLines() As PricingJobLines)
        InitializeComponent()
        SessionID = _SessionID
        PricingJobNo = _PricingJobNo
        JobDesc = _JobDesc
        Action = _Action
        Type = _Type
        Code = _Code
        Exp = _Exp
        MobilePrinitng = _MobilePrinting
        PricingJobLines = _PricingJobLines
    End Sub
    Private Sub PricingJobMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        'Barcode21.EnableScanner = True
        Me.Text = PricingJobNo
        JobTittle.Text = JobDesc
        Inialize_Datagrid()

        Fill_DatatableFromStructure()
        Fill_Flow()
        Fill_Reasonbox()
        Cursor.Current = Cursors.Default
        BarcodeBox.Focus()
    End Sub
    Private Sub Fill_Flow()
        For i As Integer = 0 To PricingJobLines.Length - 1
            Flow.Add(PricingJobLines(i).ItemNo + "-" + PricingJobLines(i).VarCode + "-" + PricingJobLines(i).UOM, PricingJobLines(i).LineNo)
        Next
    End Sub
    Private Sub Inialize_Datagrid()
        DT.Columns.Add("Description")
        DT.Columns.Add("R")
        DT.Columns.Add("LineNo")

        DataGrid1.DataSource = DT
    End Sub
    Private Sub Fill_DatatableFromStructure()
        For i As Integer = 0 To PricingJobLines.Length - 1
            Dim dp As DataRow = DT.NewRow
            dp("Description") = PricingJobLines(i).Description
            If PricingJobLines(i).ReasonCode = String.Empty Or PricingJobLines(i).ReasonCode = " " Then
                dp("R") = ""
            Else
                'dp("R") = PricingJobLines(i).ReasonCode
                dp("R") = "*"
            End If

            dp("LineNo") = PricingJobLines(i).LineNo
            DT.Rows.Add(dp)
        Next
        If DT.Rows.Count > 5 Then
            SetDataGridColumnSize(DataGrid1, 265, 10, 0)
        Else
            SetDataGridColumnSize(DataGrid1, 280, 10, 0)
        End If
        LineCounter.Text = CStr(DT.Rows.Count)
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
    Private Sub Read_BarcodeData()
        If IsNumeric(BarcodeBox.Text) And BarcodeBox.Text.Trim <> String.Empty And BarcodeBox.Text.Length >= 4 Then
            If BarcodeBox.Text.Length > 4 Then
                ' Excute Query
                db.read("Barcodes.[Barcode No_],Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code], Barcodes.[Variant Code], Barcodes.[Dolphin Item No_], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                        "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + _
                        Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "[Barcode No_] = " + "'" + BarcodeBox.Text.Trim + "'")
            ElseIf BarcodeBox.Text.Length = 4 Then
                ' Excute Query
                db.read("Barcodes.[Barcode No_],Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code],Barcodes.[Variant Code], Barcodes.[Dolphin Item No_], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                        "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + _
                        Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "Barcodes.[PLU] = " + "'" + BarcodeBox.Text.Trim + "'")
            End If
            If DataGrid1.CurrentRowIndex <> -1 Then
                DataGrid1.UnSelect(DataGrid1.CurrentRowIndex)
            End If
            BarcodeBox.Enabled = False

            Fill_Labels()

            DBClose(False)
        Else
            BarcodeBox.Enabled = True
            BarcodeBox.Text = String.Empty
            Return
        End If
    End Sub
    Private Sub Fill_Labels()
        ErrorOcurred = False
        Clear_Labels()
        ClearLineDisplayInfo()

        Try
            If dr.Read Then
                PricingJobLineHandle()
                If Not JobLine And MobilePrinitng Then
                    Barcode = dr.GetValue(0)
                    PreLine.BarcodeList = dr.GetValue(0)
                    BarcodeBox.Text = Barcode
                    PreLine.ItemNo = dr.GetValue(1)
                    PreLine.Description = dr.GetValue(2)
                    Desc.Text = PreLine.Description
                    ARDB = dr.GetValue(3)
                    If ARDB <> String.Empty Then
                        ShowAR = crAr.DisplayArabic(Remove_Leading_Numbers(ARDB))
                        ShowAR = TrimmedDigitsL + ShowAR + TrimmedDigitsF
                        PreLine.ARDesc = ShowAR
                    Else
                        ShowAR = ""
                    End If
                    ARB.Text = ShowAR
                    PreLine.UOM = dr.GetValue(4)
                    UOM.Text = PreLine.UOM
                    PreLine.VarCode = dr.GetValue(5)
                    VarCode = PreLine.VarCode
                Else
                    Barcode = dr.GetValue(0)
                    BarcodeBox.Text = Barcode
                    ItemNo = dr.GetValue(1)
                    Desc.Text = dr.GetValue(2)
                    ARDB = dr.GetValue(3)
                    If ARDB <> String.Empty Then
                        ShowAR = crAr.DisplayArabic(Remove_Leading_Numbers(ARDB))
                        ShowAR = TrimmedDigitsL + ShowAR + TrimmedDigitsF
                        PreLine.ARDesc = ShowAR
                    Else
                        ShowAR = ""
                    End If
                    ARB.Text = ShowAR

                    UOM.Text = dr.GetValue(4)
                    VarCode = dr.GetValue(5)
                End If
                              
                If JobLine And Not MobilePrinitng Then
                    NewPrice.Text = Cultural(PricingJobLines(JobLineIndex).NewPrice.ToString, False)
                    OldPrice.Text = Cultural(PricingJobLines(JobLineIndex).OldPrice.ToString, False)
                ElseIf Not JobLine And Not MobilePrinitng Then
                    NewPrice.Text = Cultural(CStr(dr.GetValue(7)), False)
                ElseIf JobLine And MobilePrinitng Then
                    NewPrice.Text = Cultural(PricingJobLines(JobLineIndex).NewPrice.ToString, False)
                    OldPrice.Text = Cultural(PricingJobLines(JobLineIndex).OldPrice.ToString, False)
                    CompleteMobileInfo()
                ElseIf Not JobLine And MobilePrinitng Then
                    CompleteMobileInfo()
                End If
            Else
                MessageBox("Barcode not found")
                ErrorOcurred = True
            End If

        Catch ex As Exception
        Finally
            If ErrorOcurred = False Then
                BarcodeBox.Enabled = False
                Qty.Enabled = True
                Qty.Focus()
                Clear.Enabled = True
                Submit.Enabled = True
                If JobLine Then
                    If PricingJobLines(JobLineIndex).ScaleItem Then
                        Mark.Visible = True
                    End If
                    Dim RowIndex As Integer = Get_LineNoGridIndex()
                    DataGrid1.CurrentCell = New DataGridCell(RowIndex, 1)
                    DataGrid1.Select(RowIndex)
                    DataGrid1.SelectionBackColor = Color.Green
                    Fill_BarcodeList()
                End If
            End If
            db.DBClose(False)
        End Try
    End Sub
    Private Sub Submit_Handle()
        If Qty.Text.Trim = String.Empty And Marked = 0 Then
            Qty.Text = "1"
        ElseIf Marked = 1 Then
            Qty.Text = "0"
        End If

        Select Case Action
            Case 1
                LineNo = LabelLineNo(SessionID, Code)
        End Select
        Cursor.Current = Cursors.WaitCursor
        If Marked <> 1 Then
            If MobilePrinitng Then
                Marked = 1
                If GetReply() Then
                    If JobLine Then
                        If MobileLineImplement() Then
                            PricingJobLines(JobLineIndex).NewPrice = NPrice
                            PricingJobLines(JobLineIndex).BarcodeList = BarcodeBox.Text.Trim
                            PricingJobLines(JobLineIndex).ARDesc = ShowAR
                            PricingJobLines(JobLineIndex).Quantity = Qty.Text.Trim
                        Else
                            Cursor.Current = Cursors.Default
                            Marked = 0
                            MessageBox("Try again")
                            Return
                        End If
                    Else
                        If Not ErrorOcurred Then
                            PreLine.NewPrice = CDec(NewPrice.Text)
                            PreLine.Quantity = CInt(Qty.Text)
                            PreLine.ARDesc = ShowAR
                        Else
                            Cursor.Current = Cursors.Default
                            ClearLineDisplayInfo()
                            Return
                        End If
                    End If
                    If Not MobilePrint() Then
                        Cursor.Current = Cursors.Default
                        MessageBox("Could'nt print try agian")
                        Me.Close()
                    End If
                Else
                    If Not BluetoothReconnect() Then
                        Cursor.Current = Cursors.Default
                        MessageBox("Bluetooth connection has been lost retry")
                        Me.Close()
                    Else
                        If GetReply() Then
                            If JobLine Then
                                If MobileLineImplement() Then
                                    PricingJobLines(JobLineIndex).NewPrice = NPrice
                                    PricingJobLines(JobLineIndex).Quantity = Qty.Text
                                    PricingJobLines(JobLineIndex).BarcodeList = BarcodeBox.Text
                                    PricingJobLines(JobLineIndex).ARDesc = ShowAR
                                Else
                                    Cursor.Current = Cursors.Default
                                    MessageBox("Try again")
                                    Return
                                End If
                            Else
                                If Not ErrorOcurred Then
                                    PreLine.NewPrice = CDec(NewPrice.Text)
                                    PreLine.Quantity = CInt(Qty.Text)
                                    PreLine.ARDesc = ARDB
                                Else
                                    Cursor.Current = Cursors.Default
                                    ClearLineDisplayInfo()
                                    Return
                                End If
                            End If
                            If Not MobilePrint() Then
                                Cursor.Current = Cursors.Default
                                MessageBox("Could'nt print try agian")
                                Me.Close()
                            End If
                        Else
                            MessageBox("Printer seems to be disconnected")
                            Me.Close()
                        End If
                    End If
                End If
            End If
        ElseIf Marked = 1 And MobilePrinitng And JobLine Then
            If MobileLineImplement() Then
                PricingJobLines(JobLineIndex).NewPrice = NPrice
                PricingJobLines(JobLineIndex).Quantity = Qty.Text
                PricingJobLines(JobLineIndex).BarcodeList = BarcodeBox.Text
                PricingJobLines(JobLineIndex).ARDesc = ARDB
            Else
                Cursor.Current = Cursors.Default
                MessageBox("Try again")
                Return
            End If
        End If
        New_Line(Marked)
        LineNo += 1
        If JobLine Then
            db.Delete("[Pricing Job Lines]", String.Format("[Job No.] = '{0}' AND [Line No.] = '{1}'", PricingJobNo, JobLineNo))
            DeleteFrom_Flow()
            Manipulate_PricingJobLine(JobLineIndex)
            Delete_FromGrid()
            If DT.Rows.Count <= 5 Then
                SetDataGridColumnSize(DataGrid1, 280, 10, 0)
            End If
            LineCounter.Text = CStr(DT.Rows.Count)
        End If
        Clear_Labels()
        ClearLineDisplayInfo()
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub CompleteMobileInfo()
        If JobLine Then
            PricingJobLines(JobLineIndex).DolphinNo = dr.GetValue(6)
            ' Get Vendor, Product Group, VAT
            DBClose(False)
            PricingJobLines(JobLineIndex).Vendor = ""
            db.read("[Vendor No_]", "[" + CompanyName.Replace(".", "_") + "$Stockkeeping Unit]", String.Format("[Item No_] = '{0}' and [Variant Code] = '{1}'", ItemNo, VarCode))
            Try
                If dr.Read Then
                    PricingJobLines(JobLineIndex).Vendor = dr.GetValue(0)
                End If
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try

            db.read("[Vendor No_],[Product Group Code],[Gen_ Prod_ Posting Group]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", ItemNo))
            Try
                If dr.Read Then
                    If PricingJobLines(JobLineIndex).Vendor = "" Then
                        PricingJobLines(JobLineIndex).Vendor = dr.GetValue(0)
                    End If
                    PricingJobLines(JobLineIndex).VATGroup = dr.GetValue(2)
                End If
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try
        Else
            PreLine.DolphinNo = dr.GetValue(6)
            ' Get Vendor, Product Group, VAT
            DBClose(False)
            PreLine.Vendor = ""
            db.read("[Vendor No_]", "[" + CompanyName.Replace(".", "_") + "$Stockkeeping Unit]", String.Format("[Item No_] = '{0}' and [Variant Code] = '{1}'", PreLine.ItemNo, PreLine.UOM))
            Try
                If dr.Read Then
                    PreLine.Vendor = dr.GetValue(0)
                End If
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try

            db.read("[Vendor No_],[Product Group Code],[Gen_ Prod_ Posting Group]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", PreLine.ItemNo))
            Try
                If dr.Read Then
                    If PreLine.Vendor = "" Then
                        PreLine.Vendor = dr.GetValue(0)
                    End If
                    PreLine.ProductGroup = dr.GetValue(1)
                    PreLine.VATGroup = dr.GetValue(2)
                End If
            Catch ex As Exception
            Finally
                DBClose(False)
            End Try
            Cursor.Current = Cursors.WaitCursor
            OldPrice.Text = ""
            Dim TmpPrice As Decimal = GetRetailPrice(PreLine.ItemNo, PreLine.VarCode, PreLine.UOM)
            If TmpPrice > 0 Then
                NewPrice.ForeColor = Color.Green
                NewPrice.Text = Cultural(TmpPrice, False)
                ErrorOcurred = False
            ElseIf TmpPrice < 0 Then
                NewPrice.ForeColor = Color.Red
                NewPrice.Text = Cultural(Math.Abs(TmpPrice), False)
                ErrorOcurred = True
            Else
                NewPrice.ForeColor = Color.Red
                NewPrice.Text = "Error"
                ErrorOcurred = True
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Sub New_Line(ByVal Printed As Int16)
        db.Insert("[Session Label Line]", String.Format(" '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'", SessionID, Login.UserId, Store, DeviceID, LineNo, Code, Barcode, Desc.Text.Replace("'", "''"), _
                                                Qty.Text, ItemNo, UOM.Text, VarCode, Desc.Text.Replace("'", "''"), "", ARDB.Replace("'", "''"), "", "", DateTime.Now, Printed, Date.Now.ToShortDateString, DateTime.Now))
    End Sub
    Private Function MobileLineImplement() As Boolean
        NPrice = 0
        NPrice = ImplementPricingJobLine(PricingJobNo, PricingJobLines(JobLineIndex).LineNo)
        If NPrice <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function MobilePrint() As Boolean
        Cursor.Current = Cursors.WaitCursor
        Dim Printed As Boolean = False
        If JobLine Then
            Printed = BluetoothPrintPricingJob(PricingJobLines(JobLineIndex))
        Else
            Printed = BluetoothPrintPricingJob(PreLine)
        End If
        If Not Printed Then
            Cursor.Current = Cursors.Default
            Dim Result As New MsgBoxResult
            Result = MsgBox("Print failed, Do you want to retry?", MsgBoxStyle.RetryCancel, Nothing)
            If Result = MsgBoxResult.Retry Then
                Cursor.Current = Cursors.WaitCursor
                If BluetoothReconnect() Then
                    If JobLine Then
                        Printed = BluetoothPrintPricingJob(PricingJobLines(JobLineIndex))
                    Else
                        Printed = BluetoothPrintPricingJob(PreLine)
                    End If
                    If Not Printed Then
                        ClearLineDisplayInfo()
                        Cursor.Current = Cursors.Default
                        Return False
                    Else
                        Cursor.Current = Cursors.Default
                        Return True
                    End If
                Else
                    Return False
                End If
            End If
        Else
            Cursor.Current = Cursors.Default
            Return True
        End If
    End Function
    Private Sub New_Line(ByVal Printed As Integer)
        Try
            db.Insert("[Session Label Line]", String.Format(" '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'", SessionID, Login.UserId, Store, DeviceID, LineNo, Code, Barcode, Desc.Text.Replace("'", "''"), _
                                                Qty.Text, ItemNo, UOM.Text, VarCode, Desc.Text.Replace("'", "''"), "", ARDB.Replace("'", "''"), "", "", DateTime.Now, Printed.ToString, Date.Now.ToShortDateString, DateTime.Now))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_LabelsFromGrid()
        Clear_Labels()
        ClearLineDisplayInfo()

        Barcode = PricingJobLines(JobLineIndex).BarcodeList
        Desc.Text = PricingJobLines(JobLineIndex).Description
        ARB.Text = crAr.DisplayArabic(Remove_Leading_Numbers(PricingJobLines(JobLineIndex).ARDesc))
        If PricingJobLines(JobLineIndex).ARDesc <> Nothing Then
            ARDB = PricingJobLines(JobLineIndex).ARDesc
        Else
            ARDB = " "
        End If

        ItemNo = PricingJobLines(JobLineIndex).ItemNo
        If PricingJobLines(JobLineIndex).VarCode <> Nothing Then
            VarCode = PricingJobLines(JobLineIndex).VarCode
        Else
            VarCode = " "
        End If
        UOM.Text = PricingJobLines(JobLineIndex).UOM
        If UOM.Text = "KG" Then
            Barcode = "23" + PricingJobLines(JobLineIndex).BarcodeList + "0000000"
        Else
            Barcode = "27" + PricingJobLines(JobLineIndex).BarcodeList + "0000000"
        End If
        Barcode = PricingJobLines(JobLineIndex).BarcodeList
        NewPrice.Text = Cultural(PricingJobLines(JobLineIndex).NewPrice.ToString, False)
        OldPrice.Text = Cultural(PricingJobLines(JobLineIndex).OldPrice.ToString, False)
    End Sub
    Private Sub PricingJobLineHandle(Optional ByVal ScaleItem As Boolean = False)
        JobLineNo = CheckFlow(ScaleItem)
        If JobLineNo <> 0 Then
            JobLine = True
            JobLineIndex = Get_ArrayIndex(JobLineNo)
        Else
            JobLine = False
        End If
    End Sub
    Private Function CheckFlow(Optional ByVal ScaleItem As Boolean = False) As Integer
        If Not ScaleItem Then
            If Flow.ContainsKey(dr.GetValue(1) + "-" + dr.GetValue(5) + "-" + dr.GetValue(4)) Then
                Return Flow(dr.GetValue(1) + "-" + dr.GetValue(5) + "-" + dr.GetValue(4))
            Else
                Return 0
            End If
        Else
            If Flow.ContainsKey(PricingJobLines(JobLineIndex).ItemNo + "-" + PricingJobLines(JobLineIndex).VarCode + "-" + PricingJobLines(JobLineIndex).UOM) Then
                Return Flow(PricingJobLines(JobLineIndex).ItemNo + "-" + PricingJobLines(JobLineIndex).VarCode + "-" + PricingJobLines(JobLineIndex).UOM)
            Else
                Return 0
            End If
        End If        
    End Function
    Private Sub DeleteFrom_Flow()
        If Flow.ContainsKey(PricingJobLines(JobLineIndex).ItemNo + "-" + PricingJobLines(JobLineIndex).VarCode + "-" + PricingJobLines(JobLineIndex).UOM) Then
            Flow.Remove(PricingJobLines(JobLineIndex).ItemNo + "-" + PricingJobLines(JobLineIndex).VarCode + "-" + PricingJobLines(JobLineIndex).UOM)
        End If
    End Sub
    Private Sub Manipulate_PricingJobLine(ByVal DeletedIndex As Integer)
        ' Transfering data inside array so we can delete the last index 
        Dim ArrLen As Integer = PricingJobLines.Length - 1
        If DeletedIndex < ArrLen Then
            For i As Integer = DeletedIndex To ArrLen - 1
                PricingJobLines(i) = PricingJobLines(i + 1)
            Next
        End If
        Array.Resize(PricingJobLines, ArrLen)
    End Sub
    Private Function Get_ArrayIndex(ByVal LineNo As Integer) As Integer
        Dim Count As Integer = 0
        For Each Line As PricingJobLines In PricingJobLines
            If Line.LineNo = LineNo Then
                Exit For
            Else
                Count += 1
            End If
        Next
        Return Count
    End Function
    Private Sub Delete_FromGrid()
        Dim intTargetIndex As Integer = -1
        Dim IntCursor As Integer = 0
        Do Until IntCursor = DT.Rows.Count OrElse intTargetIndex > -1
            If DT.Rows(IntCursor)(2) = JobLineNo Then
                intTargetIndex = IntCursor
            End If
            IntCursor += 1
        Loop
        DT.Rows(intTargetIndex).Delete()
    End Sub
    Private Function Get_LineNoGridIndex() As Integer
        Dim intTargetIndex As Integer = -1
        Dim IntCursor As Integer = 0
        Do Until IntCursor = DT.Rows.Count OrElse intTargetIndex > -1
            If DT.Rows(IntCursor)(2) = JobLineNo Then
                intTargetIndex = IntCursor
            End If
            IntCursor += 1
        Loop
        Return intTargetIndex
    End Function
    Private Sub Fill_BarcodeList()
        BarcodeList.Items.Clear()
        If PricingJobLines(JobLineIndex).BarcodeList <> Nothing Then
            Dim Barcode As String = PricingJobLines(JobLineIndex).BarcodeList
            If Barcode <> String.Empty Then
                If Barcode.Contains(",") Then
                    Do Until Not Barcode.Contains(",")
                        BarcodeList.Items.Add(Barcode.Substring(0, Barcode.IndexOf(",")))
                        Barcode = Barcode.Remove(0, Barcode.IndexOf(",") + 1)
                    Loop
                    BarcodeList.Items.Add(Barcode)
                Else
                    BarcodeList.Items.Add(Barcode)
                End If
            End If
        End If
    End Sub
    Private Sub Fill_Reasonbox()
        ReasonCodes.Items.Clear()
        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Reason Code]", String.Format("[Group] = '{0}'", Get_ReasonGroup))
        Try
            While dr.Read
                ReasonCodes.Items.Add(dr.GetValue(0))
            End While
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub DataGrid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Grid_Selection()
    End Sub
    Private Sub Grid_Selection()
        Try
            If DataGrid1.CurrentCell.RowNumber <> -1 Then
                DataGrid1.Select(DataGrid1.CurrentRowIndex)
                JobLineIndex = Get_ArrayIndex(DataGrid1(DataGrid1.CurrentRowIndex, 2))
                Fill_LabelsFromGrid()
                Fill_BarcodeList()
                ReasonCodes.Enabled = True
                JobLine = True
                If PricingJobLines(JobLineIndex).ReasonCode <> String.Empty Then
                    ReasonCodes.Text = PricingJobLines(JobLineIndex).ReasonCode
                End If
                If PricingJobLines(JobLineIndex).ScaleItem = 1 Then
                    Mark.Visible = True
                Else
                    Mark.Visible = False
                End If
                BarcodeBox.Enabled = False
            End If
        Catch ex As Exception
        Finally
            DataGrid1.Focus()
        End Try
    End Sub
    Private Sub Clear_Labels()
        NewPrice.Text = ""
        OldPrice.Text = ""
        Desc.Text = ""
        ARB.Text = ""
        UOM.Text = ""
        Qty.Text = ""
    End Sub
    Private Sub ClearLineDisplayInfo()
        JobLine = False
        BarcodeBox.Enabled = True
        BarcodeBox.Text = ""
        Marked = 0
        Qty.Enabled = False
        Mark.Visible = False
        Clear.Enabled = True
        ReasonCodes.SelectedIndex = -1
        ReasonCodes.Enabled = False
        BarcodeList.Items.Clear()
        Submit.Enabled = False
        If DataGrid1.CurrentRowIndex <> -1 Then
            DataGrid1.UnSelect(DataGrid1.CurrentRowIndex)
        End If
        BarcodeBox.Focus()
    End Sub
    Private Function Remove_Leading_Numbers(ByVal Arabic As String) As String
        Dim i As Integer = 0
        Dim S As String = Arabic
        TrimmedDigitsL = ""
        TrimmedDigitsF = ""

        For Each c As Char In S
            c = S.Chars(i)
            If Char.IsDigit(c) Then
                S = S.Substring(i + 1)
                TrimmedDigitsF += c
            Else
                Exit For
            End If
        Next

        S = StrReverse(S)
        i = 0

        For Each c As Char In S
            c = S.Chars(i)
            If Char.IsDigit(c) Then
                S = S.Substring(i + 1)
                TrimmedDigitsL += c
            Else
                Exit For
            End If
        Next
        If TrimmedDigitsL <> String.Empty Then
            TrimmedDigitsL = StrReverse(TrimmedDigitsL)
        End If

        Return StrReverse(S)
    End Function
    
    Private Sub Restrict_Alpha2(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(8))
    End Sub
    Private Sub Qty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Restrict_Alpha2(e)
    End Sub

    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Barcode21.EnableScanner = False
        Barcode21.Dispose()
        Me.Close()
    End Sub

    Private Sub PricingJobMain_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Barcode21.EnableScanner = False
        ThreadTimer.Dispose()
    End Sub

    Private Sub Clear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click
        Clear_Labels()
        ClearLineDisplayInfo()
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        DataGrid1.Select(DataGrid1.CurrentRowIndex)
        DataGrid1.SelectionBackColor = Color.DarkBlue
    End Sub
    Private Sub Barcode21_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection) Handles Barcode21.OnScan
        Try
            Dim Barcode As String = ""
            For Each D As ScanData In scanDataCollection
                Barcode = D.Text
            Next

            If Barcode <> String.Empty Then
                BarcodeBox.Text = Barcode
                Read_BarcodeData()
            End If
        Catch ex As Exception
        Finally

        End Try
    End Sub
    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Submit_Handle()
    End Sub

    Private Sub BarcodeBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarcodeBox.KeyDown
        If e.KeyValue = 13 And BarcodeBox.Text.Trim <> String.Empty Then
            Read_BarcodeData()
        End If
    End Sub

    Private Sub Qty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Qty.KeyDown
        If e.KeyValue = 13 Then
            Submit_Handle()
        End If
    End Sub

    Private Sub Mark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mark.Click
        Marked = 1
        PricingJobLineHandle(True)
        Get_ScaleItemInfo()
        Submit_Handle()
    End Sub
    Private Sub Get_ScaleItemInfo()
        db.read("[Barcode No_] , [Variant Code],[Arabic Description]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[PLU] = '{0}'", PricingJobLines(JobLineIndex).BarcodeList))
        If dr.Read Then
            Barcode = dr.GetValue(0)
            VarCode = dr.GetValue(1)
            ARDB = dr.GetValue(2)
        Else
            Return
        End If
        If ARDB = String.Empty Then
            ARDB = " "
        End If
        If VarCode = String.Empty Then
            VarCode = " "
        End If
        ItemNo = PricingJobLines(JobLineIndex).ItemNo
        DBClose(False)
    End Sub
    Private Sub PricingJobMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = 125 Then
            ClearLineDisplayInfo()
            Barcode21.EnableScanner = False
            Barcode21.Dispose()
            Me.Close()
        ElseIf (e.KeyValue = 38 Or e.KeyValue = 40) And DataGrid1.Focused = False Then
            DataGrid1.Focus()
            Return
        End If
    End Sub

    Private Sub ReasonCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReasonCodes.SelectedIndexChanged
        If JobLine Then
            db.Update("[Pricing Job Lines]", String.Format("[Reason Code] = '{0}'", ReasonCodes.Text), String.Format("[Job No.] = '{0}' AND [Line No.] = '{1}'", PricingJobNo, DT.Rows(DataGrid1.CurrentRowIndex).Item(2)))
            PricingJobLines(JobLineIndex).ReasonCode = ReasonCodes.Text
            DT.Rows(DataGrid1.CurrentRowIndex)("R") = "*"
        End If
    End Sub

    Private Sub DataGrid1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGrid1.KeyDown
        If e.KeyValue = 38 Or e.KeyValue = 40 Then
            Grid_Selection()
            DataGrid1.Focus()
        End If
    End Sub

    Private Sub DataGrid1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.GotFocus
        DataGrid1.SelectionBackColor = Color.DarkBlue
    End Sub
End Class