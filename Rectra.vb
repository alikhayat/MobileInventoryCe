Imports System.Data
Imports Symbol.Barcode2
Imports Arabic.Controls
Public Structure Line
    Public DocumentNo As String
    Public LineNo As Integer
    Public ItemNo As String
    Public Desc As String
    Public VarCode As String
    Public BarcodeNo As String
    Public Quantity As String
    Public UOMCode As String
    Public QtyPUOM As String
    Public QtyBase As String
    Public ShortcutDimenion As String
    Public VendorCustomerNo As String
    Public VendorItemNo As String
    Public PostingAction As String
    Public ReasonCode As String
    Public ToLocation As String
    Public HandHeldUser As String
    Public HandHeldStartTime As DateTime
    Public UOMBase As String
    Public NewItem As Int16
    Public Brand As String
    Public NewDesc As String
    Public QtyPerBaseCompUnit As String
    Public BaseCompUnit As String
    Public NewPurchaseUOM As String
    Public WeightItem As Int16
    Public PackagingWeight As String
    Public TotalWeight As String
    Public EnteredQty1 As Decimal
    Public EnteredQty2 As Decimal
    Public ARDesc As String
    Public Printed As Int16
    Public PrintedQty As String
    Public QtyPerScannedUnit As Decimal
    Public ScannedUnitQty As Decimal
    Public Price As String
    Public NewLine As Int16
    Public KG As Boolean
    Public ScannedUOM As String
    Public AddQty As Boolean
    Public Pack As Integer
    Public NewWeightItem As Int16
    Public Multiply As Integer
End Structure
Public Class Rectra
    Private DT As New DataTable
    Shadows size As System.Drawing.Size
    Private SessionID As String
    Private Type As String
    Private Code As String
    Private ReferenceNo As String
    Private VendorName As String
    Private InvoiceNo As String
    Private ExpectedDate As Date

    Dim SessionCreating As Boolean = False
    Dim crAr As New Arabic.Controls.ArabicShape
    Dim TrimmedDigitsL As String = ""
    Dim TrimmedDigitsF As String = ""
    Dim IntialRun As Integer = 0
    Dim CountingType As Int16, RefNo As String, Picking As Int16, Receiving As Int16, RFstat As Int16
    Dim ComittedLines(0) As Line
    Dim CurrLine As New Line
    Dim LineCount As Integer = 0
    Dim LineIndex As Integer = -1
    Dim UpdateLineIndex As Integer
    Dim SpecialCaseQty As Boolean
    Dim QtyDifference As Decimal
    Dim EditMode As Boolean
    Dim Form_Submitting As Boolean
    Dim Flow As New Dictionary(Of String, Decimal)()

    Public Sub New(ByVal _SessionID As String, ByVal _Type As String, ByVal _Code As String, ByVal _ReferenceNo As String, ByVal _VendorName As String, ByVal _InvoiceNo As String, Optional ByVal _ExpectedDate As Date = Nothing)
        InitializeComponent()
        SessionID = _SessionID
        Type = _Type
        Code = _Code
        If _ReferenceNo <> String.Empty Then
            ReferenceNo = _ReferenceNo
        End If
        VendorName = _VendorName
        InvoiceNo = _InvoiceNo
        ExpectedDate = _ExpectedDate
    End Sub
    Private Sub Rec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Cursor.Current = Cursors.Default
        Barcode100.EnableScanner = True
        Clear_Labels()
        Inialize_Datagrid()

        If Type = "2" And Code = "3" Then
            CountingType = 0
            Picking = 0
            Receiving = 3
            RFstat = 2
            RefNo = ReferenceNo
            Vendor.Text = VendorName
            Invoice.Text = InvoiceNo
        ElseIf Type = "2" And Code = "2" Then
            CountingType = 0
            Picking = 0
            Receiving = 2
            RFstat = 2
            RefNo = ""
            Vendor.Text = VendorName
            Invoice.Text = InvoiceNo
        ElseIf Type = "3" And Code = "5" Then
            CountingType = 1
            Picking = 5
            Receiving = 0
            RFstat = 2
            RefNo = ReferenceNo
            Vendor.Text = "Transfer to " + ReferenceNo
            Invoice.Text = ""
        End If

        ' Edit Mode
        If SessionID <> String.Empty Then
            ReferenceNo = Get_ReferenceNo()
            Get_SessLines()
            Fill_Flow()
            FillGrid_CommittedLines()
            LineCount = PRLineNo(SessionID)
            If ComittedLines(0).BarcodeNo = "" Then
                LineIndex = -1
            Else
                LineIndex = ComittedLines.Length - 1
            End If

            If DT.Rows.Count > 5 Then
                SetDataGridColumnSize(DataGrid1, 81, 160, 36, 0)
            End If
        End If
    End Sub
    Private Sub Clear_Labels()
        Price.Text = ""
        Desc.Text = ""
        ARB.Text = ""
        NetWeight.Text = ""
        Pack.Text = ""
        Qty.Text = ""
        Qty2.Text = ""
        Qty.Enabled = False
        Qty2.Enabled = False
        EditWeight.Enabled = False
        EditWeight.Visible = False
        Delete.Enabled = False
        Submit.Enabled = False
    End Sub
    Private Sub ClearLineDisplayInfo()
        'ResetUOMControls()

        Clear_Labels()
        BarcodeBox.Enabled = True
        'Barcode100.EnableScanner = True
        BarcodeBox.Text = ""
        NetWeight.Text = ""
        Pack.Text = ""
        Qty.Text = ""
        Qty2.Text = ""
        Qty.Enabled = False
        Qty2.Enabled = False
        EditWeight.Enabled = False
        EditWeight.Visible = False
        UOM.Enabled = False
        UOM.Items.Clear()
        Submit.Enabled = False
        Delete.Enabled = False
        EditMode = False
        VendorIt.Enabled = True
        Clear.Enabled = False

        If DT.Rows.Count > 5 Then
            Datagrid_Selection(DT.Rows.Count - 1, False)
        End If

        BarcodeBox.Focus()
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
                db.read("Barcodes.[Barcode No_],Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code],Barcodes.[Variant Code], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                        "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + _
                        Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "[Barcode No_] = " + "'" + BarcodeBox.Text.Trim + "'")
            ElseIf BarcodeBox.Text.Length = 4 Then
                ' Excute Query
                db.read("Barcodes.[Barcode No_],Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code],Barcodes.[Variant Code], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                        "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + _
                        Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "Barcodes.[PLU] = " + "'" + BarcodeBox.Text.Trim + "'")
            End If
            If DataGrid1.CurrentRowIndex <> -1 Then
                DataGrid1.UnSelect(DataGrid1.CurrentRowIndex)
            End If
            BarcodeBox.Enabled = False
            'Barcode100.EnableScanner = False
            InializeNewLine()
            If dr.Read Then
                FillCurrLineBcode()
                Get_OtherUOMs()
            ElseIf Not dr.Read And BarcodeBox.Text.Length >= 8 And Type <> "3" And Code <> "5" Then
                FillCurrLineNewItem()
            Else
                MessageBox("Invalid Input")
                ClearLineDisplayInfo()
            End If
            DBClose(False)
        Else
            BarcodeBox.Enabled = True
            'Barcode100.EnableScanner = True
            BarcodeBox.Text = String.Empty
            Return
        End If
    End Sub
    Private Sub Get_OtherUOMs()
        UOM.Items.Clear()
        Dim ScaleUse As Boolean = False
        If CurrLine.ItemNo <> "NEW" Then
            db.read("[Scale Use]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", CurrLine.ItemNo))

            If dr.Read Then
                ScaleUse = dr.GetValue(0)
                DBClose(False)
                If ScaleUse Then
                    db.read("[Base Unit of Measure],[Purch_ Unit of Measure]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", CurrLine.ItemNo))
                    While dr.Read
                        UOM.Items.Add(dr.GetValue(0))
                        If dr.GetValue(0) = "KG" Then
                            DBClose(False)
                            UOM.Text = CurrLine.UOMCode
                            Return
                        End If
                        If dr.GetValue(1) <> dr.GetValue(0) Then
                            UOM.Items.Add(dr.GetValue(1))
                        End If
                    End While
                    DBClose(False)
                Else
                    db.read("U.[UOM Code]", "[" + CompanyName.Replace(".", "_") + "$Variant unit Of Measure] AS U INNER JOIN [" + CompanyName.Replace(".", "_") + "$Unit Of Measure] AS Q ON " + _
                           "U.[UOM Code] = Q.[Code]", String.Format("U.[Item No_] = '{0}' and U.[Variant Code] = '{1}' ORDER BY Q.[Default Qty Per] ASC", CurrLine.ItemNo, CurrLine.VarCode))
                    While dr.Read
                        UOM.Items.Add(dr.GetValue(0))
                    End While
                    UOM.Text = CurrLine.UOMCode
                    DBClose(False)
                End If
            End If
            Try
                If UOM.Items.Count > 1 Then
                    If UOM.SelectedItem <> Nothing Then
                        If UOM.Items(UOM.SelectedIndex + 1) <> Nothing Then
                            CurrLine.Pack = Get_DefaultQtyPer(UOM.Items(UOM.SelectedIndex + 1)) / Get_DefaultQtyPer(UOM.SelectedItem)
                        End If
                    Else
                        CurrLine.Pack = 1
                    End If
                Else
                    CurrLine.Pack = 1
                End If
            Catch ex As Exception
                CurrLine.Pack = 1
            End Try
            UOM.Text = CurrLine.UOMCode
            Me.Pack.Text = CStr(CurrLine.Pack)
        End If
    End Sub
    Private Sub InializeNewLine()
        'Inialize a New line structure 
        'Zero Curr
        CurrLine = New Line
        CurrLine.EnteredQty1 = 1
        CurrLine.EnteredQty1 = 1
        CurrLine.HandHeldUser = Login.UserId
        CurrLine.VendorCustomerNo = ReferenceNo
        CurrLine.AddQty = False
        CurrLine.QtyPerScannedUnit = 1
    End Sub
    Private Sub Inialize_Datagrid()
        DT.Columns.Add("Barcode")
        DT.Columns.Add("Description")
        DT.Columns.Add("Qty")

        DataGrid1.DataSource = DT
        SetDataGridColumnSize(DataGrid1, 81, 156, 50, 0)
    End Sub
    Private Sub FillCurrLineBcode()
        ' Info From Scanned Bcode or Selected Vitems (Existing)

        CurrLine.BarcodeNo = dr.GetValue(0)

        ' Check Dictionary for existing barcode
        If CheckFlow() Then
            CurrLine.NewLine = 1
        Else
            Dim Info() As Integer = Get_FirstBarcodeInfo()
            UpdateLineIndex = Info(0)
            CurrLine.LineNo = Info(1)
            CurrLine.NewLine = 0
            Datagrid_Selection(UpdateLineIndex, True, False)
            CurrLine = ComittedLines(UpdateLineIndex)
            EditMode = False
            FillForm_FromCommitedLines()
            InializeTimer()
            Delete.Enabled = True
            DBClose(False)
            Return
        End If
        ' Fill CurrLine
        CurrLine.ItemNo = dr.GetValue(1)
        CurrLine.Desc = dr.GetValue(2)
        CurrLine.ARDesc = dr.GetValue(3)
        CurrLine.UOMCode = dr.GetValue(4)
        CurrLine.VarCode = dr.GetValue(5)
        CurrLine.Price = dr.GetValue(6)
        CurrLine.ScannedUOM = dr.GetValue(4)

        CurrLine.NewItem = 0
        CurrLine.Brand = ""
        CurrLine.NewDesc = ""
        CurrLine.QtyPerBaseCompUnit = ""
        CurrLine.BaseCompUnit = ""
        CurrLine.NewPurchaseUOM = "0"
        CurrLine.WeightItem = 0

        CurrLine.HandHeldStartTime = DateTime.Now

        ' Weight Item Entry
        If CurrLine.UOMCode = "KG" Then
            Dim WeightInput As New WeightInput
            ThreadTimer.Dispose()
            WeightInput.Desc.Text = CurrLine.Desc
            Barcode100.EnableScanner = False
            If WeightInput.ShowDialog = Windows.Forms.DialogResult.OK Then
                CurrLine.Multiply = WeightInput.Multiple.Text
                If WeightInput.GramRadio.Checked = False Then
                    CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text) * CurrLine.Multiply)
                    CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text) * CurrLine.Multiply)
                    If WeightInput.PackWeight.Text <> "0" Then
                        CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text) * CurrLine.Multiply)
                    Else
                        CurrLine.PackagingWeight = "0"
                    End If
                Else
                    CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text.Trim / 1000) * CurrLine.Multiply)
                    CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text.Trim / 1000) * CurrLine.Multiply)
                    If WeightInput.PackWeight.Text <> "0" Then
                        CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text.Trim / 1000) * CurrLine.Multiply)
                    Else
                        CurrLine.PackagingWeight = "0"
                    End If
                End If
                InializeTimer()
                CurrLine.KG = True
                CurrLine.WeightItem = 1
                CurrLine.NewWeightItem = 1

                CurrLine.EnteredQty1 = 0
                CurrLine.EnteredQty2 = 0
                WeightInput.Dispose()
                Barcode100.EnableScanner = True
            Else
                WeightInput.Dispose()
                Barcode100.EnableScanner = True
                InializeTimer()
                ClearLineDisplayInfo()
                Return
            End If
        Else
            CurrLine.Multiply = 1
        End If

        Fill_Labels()
    End Sub

    Private Sub FillCurrLineNewItem()
        CurrLine.BarcodeNo = BarcodeBox.Text

        ' Check Dictionary for existing barcode
        If CheckFlow() Then
            CurrLine.NewLine = 1
        Else
            Dim Info() As Integer = Get_FirstBarcodeInfo()
            UpdateLineIndex = Info(0)
            CurrLine.LineNo = Info(1)
            CurrLine.NewLine = 0
            CurrLine.AddQty = True
            Datagrid_Selection(UpdateLineIndex, True, False)
            CurrLine = ComittedLines(UpdateLineIndex)
            FillForm_FromCommitedLines()
            InializeTimer()
            Return
        End If

        CurrLine.HandHeldStartTime = DateTime.Now

        ' New Item Entry
        Dim NewItem As New NewItem(CurrLine.BarcodeNo)
        ThreadTimer.Dispose()
        Barcode100.EnableScanner = False
        If NewItem.ShowDialog = Windows.Forms.DialogResult.OK Then
            'FillAllNewDataOnLine
            CurrLine.Desc = String.Format("{0} {1} {2}", NewItem.Desc.Text.Trim, NewItem.QtyBaseComp.Text.Trim, NewItem.CompUOM.Text)
            CurrLine.QtyPerBaseCompUnit = NewItem.QtyBaseComp.Text
            CurrLine.BaseCompUnit = NewItem.CompUOM.Text
            CurrLine.UOMCode = NewItem.BaseUOM.Text
            CurrLine.NewPurchaseUOM = NewItem.PurchUnit.Text
            CurrLine.ScannedUOM = NewItem.BaseUOM.Text
            CurrLine.NewDesc = NewItem.Desc.Text
            CurrLine.QtyPerScannedUnit = 1
            If CurrLine.UOMCode = "KG" Then
                Dim WeightInput As New WeightInput
                If WeightInput.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CurrLine.Multiply = WeightInput.Multiple.Text
                    If WeightInput.GramRadio.Checked = False Then
                        CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text) * CurrLine.Multiply)
                        CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text) * CurrLine.Multiply)
                        If WeightInput.PackWeight.Text <> "0" Then
                            CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text) * CurrLine.Multiply)
                        Else
                            CurrLine.PackagingWeight = "0"
                        End If
                    Else
                        CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text.Trim / 1000) * CurrLine.Multiply)
                        CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text.Trim / 1000) * CurrLine.Multiply)
                        If WeightInput.PackWeight.Text <> "0" Then
                            CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text.Trim / 1000) * CurrLine.Multiply)
                        Else
                            CurrLine.PackagingWeight = "0"
                        End If
                    End If
                    CurrLine.EnteredQty1 = 0
                    CurrLine.EnteredQty2 = 0
                    CurrLine.WeightItem = 1
                Else
                    WeightInput.Dispose()
                    NewItem.Dispose()
                    Barcode100.EnableScanner = True
                    InializeTimer()
                    ClearLineDisplayInfo()
                    Return
                End If
                WeightInput.Dispose()
            Else
                CurrLine.Multiply = 1
            End If
            InializeTimer()
            CurrLine.ARDesc = ""
            CurrLine.Price = "0"
            CurrLine.Brand = ""
            CurrLine.ItemNo = "NEW"
            CurrLine.NewItem = 1

            NewItem.Dispose()
            Barcode100.EnableScanner = True
        Else
            NewItem.Dispose()
            Barcode100.EnableScanner = True
            InializeTimer()
            ClearLineDisplayInfo()
            Return
        End If

        Fill_Labels()
    End Sub
    Private Sub Fill_Labels()
        Clear_Labels()

        'Fill Form From CurrLine
        Desc.Text = CurrLine.Desc
        ARB.Text = crAr.DisplayArabic(Remove_Leading_Numbers(CurrLine.ARDesc))

        If CurrLine.Price <> "0" Then
            Price.Text = Cultural(CurrLine.Price, False) + " L.L"
        Else
            Price.Text = "NEW"
        End If

        If CurrLine.WeightItem = 1 Or CurrLine.NewWeightItem = 1 Then
            Qty.Enabled = False
            Qty2.Enabled = False
            Qty.Text = CStr(CDec(CurrLine.TotalWeight) / CurrLine.Multiply)
            If CurrLine.PackagingWeight <> "0" Then
                Qty2.Text = CStr(CDec(CurrLine.PackagingWeight) / CurrLine.Multiply)
            Else
                Qty2.Text = "0"
            End If
            Pack.Text = "X" + CStr(CurrLine.Multiply)
            EditWeight.Enabled = True
            EditWeight.Visible = True
            NetWeight.Text = Cultural(CurrLine.Quantity, True)
        Else
            Qty.Enabled = True
            Qty2.Enabled = True
            Qty.Focus()
        End If
        If CurrLine.NewItem = 1 Then
            UOM.Items.Add(CurrLine.UOMCode)
            UOM.Text = CurrLine.UOMCode
            UOM.Enabled = False
        Else
            UOM.Enabled = True
        End If

        Clear.Enabled = True
        VendorIt.Enabled = False
        Submit.Enabled = True
    End Sub
    Private Sub FillForm_FromCommitedLines()
        Clear_Labels()
        Desc.Text = CurrLine.Desc
        ARB.Text = crAr.DisplayArabic(Remove_Leading_Numbers(CurrLine.ARDesc))

        If CurrLine.NewItem = 1 Then
            UOM.Items.Add(CurrLine.UOMCode)
            UOM.Text = CurrLine.UOMCode
        Else
            Get_OtherUOMs()
            UOM.Text = CurrLine.UOMCode
        End If
        UOM.Enabled = False

        If CurrLine.Price <> "0" Then
            Price.Text = Cultural(CurrLine.Price, False) + " L.L"
        Else
            Price.Text = "NEW"
        End If
        BarcodeBox.Text = CurrLine.BarcodeNo
        CurrLine.NewLine = 0

        If CurrLine.WeightItem = 1 Or CurrLine.NewWeightItem = 1 Then
            Qty.Text = CStr(CDec(CurrLine.TotalWeight) / CurrLine.Multiply)
            Qty2.Text = CStr(CDec(CurrLine.PackagingWeight) / CurrLine.Multiply)
            Qty.Enabled = False
            Qty2.Enabled = False
            Pack.Text = "X" + CStr(CurrLine.Multiply)

            EditWeight.Enabled = True
            EditWeight.Visible = True

            NetWeight.Text = Cultural(CurrLine.Quantity, True)
        Else
            Qty.Enabled = True
            Qty2.Enabled = True
            Qty.Text = ""
            Qty2.Text = ""
            Qty.Focus()
            Pack.Text = CStr(CurrLine.Pack)
            NetWeight.Text = Cultural(CurrLine.Quantity, True)
        End If
        QtyDifference = CurrLine.ScannedUnitQty

        db.DBClose(False)
        BarcodeBox.Enabled = False
        'Barcode100.EnableScanner = False
        Clear.Enabled = True
        VendorIt.Enabled = False
        Submit.Enabled = True
    End Sub

    Private Sub Validate_Structure()
        ' Fill Unused Fields
        If CurrLine.QtyPUOM = String.Empty Then
            CurrLine.QtyPUOM = "0"
        End If
        If CurrLine.QtyBase = String.Empty Then
            CurrLine.QtyBase = "0"
        End If
        If CurrLine.PostingAction = String.Empty Then
            CurrLine.PostingAction = "0"
        End If
        If CurrLine.QtyPerBaseCompUnit = String.Empty Then
            CurrLine.QtyPerBaseCompUnit = "0"
        End If
        If CurrLine.PackagingWeight = String.Empty Then
            CurrLine.PackagingWeight = "0"
        End If
        If CurrLine.TotalWeight = String.Empty Then
            CurrLine.TotalWeight = "0"
        End If
        If CurrLine.PrintedQty = String.Empty Then
            CurrLine.PrintedQty = "0"
        End If
    End Sub

    Private Sub NewHeader()
        ' Get a new session ID
        SessionID = SessId(Type)

        ' Update Last Session ID No
        AddCounter(Type)

        Dim Param1 As String = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',", SessionID, "0", "0", DateTime.Now.ToShortDateString, ReferenceNo, _
                                             CountingType.ToString, RefNo, VendorName.Replace("'", "''"), Picking, Receiving, Store)
        Dim Param2 As String = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", Store, Login.UserId, RFstat, DateTime.Now, _
                                             DateTime.Now, DeviceID, "", "", "0", InvoiceNo, ExpectedDate)

        db.Insert("[P/R Header]", Param1 + Param2)

    End Sub
    Private Sub Insert_Line()

        Dim Param1 As String = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',", SessionID, CurrLine.LineNo, CurrLine.ItemNo, CurrLine.Desc.Replace("'", "''"), _
                                           CurrLine.VarCode, CurrLine.BarcodeNo, CurrLine.Quantity, CurrLine.UOMCode, CurrLine.QtyPUOM, CurrLine.QtyBase, CurrLine.ShortcutDimenion)
        Dim Param2 As String = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',", CurrLine.VendorCustomerNo, CurrLine.VendorItemNo, CurrLine.PostingAction, _
                                             CurrLine.ReasonCode, CurrLine.ToLocation, CurrLine.HandHeldUser, CurrLine.HandHeldStartTime, CurrLine.UOMBase, CurrLine.NewItem, CurrLine.Brand)
        Dim Param3 As String = String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'", CurrLine.NewDesc.Replace("'", "''"), CurrLine.QtyPerBaseCompUnit, CurrLine.BaseCompUnit, CurrLine.WeightItem, _
                                            CurrLine.PackagingWeight, CurrLine.TotalWeight, CurrLine.EnteredQty1, CurrLine.EnteredQty2, CurrLine.ARDesc, CurrLine.Printed, CurrLine.PrintedQty, CurrLine.NewPurchaseUOM, CurrLine.Price, CurrLine.ScannedUOM, _
                                            CurrLine.QtyPerScannedUnit, CurrLine.ScannedUnitQty, CurrLine.Pack, CurrLine.Multiply)

        db.Insert("[P/R Line]", Param1 + Param2 + Param3)

        ReDim Preserve ComittedLines(LineIndex)

        ComittedLines(LineIndex) = CurrLine
    End Sub
    Private Sub Update_Line()
        db.Update("[P/R Line]", String.Format("[Quantity] = '{0}' , [Packaging Weight] = '{1}' , [Total Weight] = '{2}' , [Entered Quantity 1] = '{3}' , [Entered Quantity 2] = '{4}' , [Qty Per Scanned Unit] = '{5}' , [Scanned Unit Qty] = '{6}' , [Pack] = '{7}' , [Multiply] = '{8}'", CurrLine.Quantity, _
                                               CurrLine.PackagingWeight, CurrLine.TotalWeight, CurrLine.EnteredQty1, CurrLine.EnteredQty2, CurrLine.QtyPerScannedUnit, CurrLine.ScannedUnitQty, CurrLine.Pack, CurrLine.Multiply), String.Format("[Document No.] = '{0}' AND [Line No.] = '{1}'", SessionID, CurrLine.LineNo))

        ComittedLines(UpdateLineIndex) = CurrLine
    End Sub
    Private Sub Edit_WeightInput()
        ' Edits Weight Item Quantity
        Dim WeightInput As New WeightInput

        WeightInput.Desc.Text = CurrLine.Desc
        WeightInput.TotalWeight.Text = CStr(CDec(CurrLine.TotalWeight) / CurrLine.Multiply)
        WeightInput.PackWeight.Text = CStr(CDec(CurrLine.PackagingWeight) / CurrLine.Multiply)
        WeightInput.NetWeight.Text = CStr(CDec(CurrLine.Quantity) / CurrLine.Multiply)
        WeightInput.Multiple.Text = CStr(CurrLine.Multiply)

        ThreadTimer.Dispose()
        If WeightInput.ShowDialog = Windows.Forms.DialogResult.OK Then
            CurrLine.Multiply = WeightInput.Multiple.Text
            If WeightInput.GramRadio.Checked = False Then
                CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text) * CurrLine.Multiply)
                CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text) * CurrLine.Multiply)
                If WeightInput.PackWeight.Text <> "0" Then
                    CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text) * CurrLine.Multiply)
                Else
                    CurrLine.PackagingWeight = "0"
                End If
                CurrLine.KG = 1
            Else
                CurrLine.Quantity = CStr(CDec(WeightInput.NetWeight.Text.Trim / 1000) * CurrLine.Multiply)
                CurrLine.TotalWeight = CStr(CDec(WeightInput.TotalWeight.Text.Trim / 1000) * CurrLine.Multiply)
                If WeightInput.PackWeight.Text <> "0" Then
                    CurrLine.PackagingWeight = CStr(CDec(WeightInput.PackWeight.Text.Trim / 1000) * CurrLine.Multiply)
                Else
                    CurrLine.PackagingWeight = "0"
                End If
                CurrLine.KG = 0
            End If

            Qty.Text = CStr(CDec(CurrLine.TotalWeight) / CurrLine.Multiply)
            If CurrLine.PackagingWeight <> "0" Then
                Qty2.Text = CStr(CDec(CurrLine.PackagingWeight) / CurrLine.Multiply)
            Else
                Qty2.Text = "0"
            End If
            Pack.Text = "X" + CStr(CurrLine.Multiply)
            NetWeight.Text = Cultural(CurrLine.Quantity, True)
        End If
        WeightInput.Dispose()
        InializeTimer()
    End Sub
    Private Function Get_FirstBarcodeInfo() As Integer()
        ' Gets the first matching barcode and gets its index and line No
        Dim Info(1) As Integer

        For i As Integer = 0 To ComittedLines.Length
            If ComittedLines(i).BarcodeNo = CurrLine.BarcodeNo Then
                Info(0) = i
                Info(1) = ComittedLines(i).LineNo
                Exit For
            End If
        Next

        Return Info
    End Function
    Private Function Get_DefaultQtyPer(ByVal UOM As String) As Decimal
        db.read("CONVERT(DECIMAL(9, 0), [Default Qty per])", "[" + CompanyName.Replace(".", "_") + "$Unit of Measure]", String.Format("[Code] = '{0}'", UOM))

        If dr.Read Then
            Return dr.GetValue(0)
        End If
        DBClose(False)
    End Function
    Private Sub Submit_Handle()
        If CurrLine.WeightItem = 0 Then
            If Qty2.Text.Trim = "0" Or Qty2.Text.Trim = String.Empty Then
                Qty2.Text = "1"
            End If
            If Qty.Text.Trim = "0" Or Qty.Text.Trim = String.Empty Then
                Qty.Text = "1"
            End If
        End If
        If SpecialCaseQty Then
            If Not Check_SpecialQty() Then
                MessageBox("Quantity entered is invalid")
                Qty.Text = String.Empty
                Qty2.Text = String.Empty
                Return
            End If
        End If
        Submit_Form()
    End Sub

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Submit_Handle()
    End Sub
    Private Sub Submit_Form()
        Form_Submitting = True
        If SessionID = String.Empty Then
            NewHeader()
        End If
        CurrLine.DocumentNo = SessionID

        If CurrLine.WeightItem = 1 Or CurrLine.NewWeightItem = 1 Then
            CurrLine.EnteredQty1 = 0
            CurrLine.EnteredQty2 = 0
            CurrLine.TotalWeight = CDec(Qty.Text * CurrLine.Multiply)
            CurrLine.PackagingWeight = CDec(Qty2.Text * CurrLine.Multiply)
            Calculate_Quantity()
        ElseIf CurrLine.NewLine = 0 And CurrLine.WeightItem = 0 And EditMode = False Then
            CurrLine.EnteredQty1 = CDec(CurrLine.Quantity)
            CurrLine.EnteredQty2 = 1
            CurrLine.TotalWeight = 0
            CurrLine.PackagingWeight = 0
            'Calculate_Quantity()
        Else
            CurrLine.EnteredQty1 = Qty.Text.Trim
            CurrLine.EnteredQty2 = Qty2.Text.Trim
            CurrLine.TotalWeight = 0
            CurrLine.PackagingWeight = 0
            Calculate_Quantity()
        End If

        If CurrLine.NewLine = 1 Then
            LineCount += 1
            CurrLine.LineNo = LineCount

            LineIndex += 1
            Validate_Structure()
            Insert_Line()
            AddToFlow()
            AddDatagridLine()
            Datagrid_Selection(LineIndex, True)
        Else
            Update_Line()
            Calculate_QtyDifference(QtyDifference)
            UpdateFlow(QtyDifference)
            UpdateDatagridLine()
            Datagrid_Selection(UpdateLineIndex, True)
        End If
        Form_Submitting = False
        ClearLineDisplayInfo()
    End Sub
    Private Sub Calculate_QtyDifference(ByVal Inial As Decimal)
        QtyDifference = CurrLine.ScannedUnitQty - QtyDifference
    End Sub
    Private Sub Get_SessLines()
        ' Fills committed Line array on edit mode
        Dim I As Integer = 0
        db.read("*", "[P/R Line]", String.Format("[Document No.] = '{0}'", SessionID))

        Dim P As String
        Try
            While dr.Read
                ReDim Preserve ComittedLines(I)
                ComittedLines(I).DocumentNo = SessionID
                ComittedLines(I).LineNo = dr.GetValue(1)
                ComittedLines(I).ItemNo = dr.GetValue(2)
                ComittedLines(I).Desc = dr.GetValue(3)
                ComittedLines(I).VarCode = dr.GetValue(4)
                ComittedLines(I).BarcodeNo = dr.GetValue(5)
                ComittedLines(I).Quantity = CStr(CDec(dr.GetValue(6)))
                ComittedLines(I).UOMCode = dr.GetValue(7)
                ComittedLines(I).QtyPUOM = CStr(dr.GetValue(8))
                ComittedLines(I).QtyBase = CStr(dr.GetValue(9))
                ComittedLines(I).ShortcutDimenion = dr.GetValue(10)
                ComittedLines(I).VendorCustomerNo = dr.GetValue(11)
                ComittedLines(I).VendorItemNo = dr.GetValue(12)
                ComittedLines(I).PostingAction = CStr(dr.GetValue(13))
                ComittedLines(I).ReasonCode = dr.GetValue(14)
                ComittedLines(I).ToLocation = dr.GetValue(15)
                ComittedLines(I).HandHeldUser = dr.GetValue(16)
                ComittedLines(I).HandHeldStartTime = dr.GetValue(17)
                ComittedLines(I).UOMBase = dr.GetValue(18)
                ComittedLines(I).NewItem = dr.GetValue(19)
                ComittedLines(I).Brand = dr.GetValue(20)
                ComittedLines(I).NewDesc = dr.GetValue(21)
                ComittedLines(I).QtyPerBaseCompUnit = CStr(dr.GetValue(22))
                ComittedLines(I).BaseCompUnit = dr.GetValue(23)
                ComittedLines(I).WeightItem = dr.GetValue(24)
                ComittedLines(I).PackagingWeight = CStr(dr.GetValue(25))
                ComittedLines(I).TotalWeight = CStr(dr.GetValue(26))
                ComittedLines(I).EnteredQty1 = dr.GetValue(27)
                ComittedLines(I).EnteredQty2 = dr.GetValue(28)
                ComittedLines(I).ARDesc = dr.GetValue(29)
                ComittedLines(I).Printed = dr.GetValue(30)
                ComittedLines(I).PrintedQty = CStr(dr.GetValue(31))
                ComittedLines(I).NewPurchaseUOM = dr.GetValue(32)
                ComittedLines(I).KG = True
                P = CStr(dr.GetValue(33))
                ComittedLines(I).Price = P.Substring(0, P.IndexOf("."))
                ComittedLines(I).QtyPerScannedUnit = dr.GetValue(35)
                ComittedLines(I).ScannedUnitQty = dr.GetValue(36)
                ComittedLines(I).Pack = dr.GetValue(37)
                ComittedLines(I).Multiply = dr.GetValue(38)
                I += 1
            End While
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub Datagrid_Selection(ByVal RowIndex As Integer, ByVal SelectCell As Boolean, Optional ByVal NewLine As Boolean = True)

        If DataGrid1.CurrentRowIndex <> -1 Then
            DataGrid1.UnSelect(DataGrid1.CurrentRowIndex)
        End If
        DataGrid1.CurrentCell = New DataGridCell(RowIndex, 1)
        If SelectCell Then
            DataGrid1.Select(RowIndex)
        End If
        If Not NewLine Then
            DataGrid1.SelectionBackColor = Color.Green
        Else
            DataGrid1.SelectionBackColor = Color.DarkBlue
        End If
    End Sub
    Private Sub AddDatagridLine()
        Dim dp As DataRow = DT.NewRow
        dp("Barcode") = CurrLine.BarcodeNo
        dp("Description") = CurrLine.Desc
        dp("Qty") = Cultural(CurrLine.ScannedUnitQty, True)

        DT.Rows.Add(dp)

        If DT.Rows.Count > 5 Then
            SetDataGridColumnSize(DataGrid1, 81, 160, 36, 0)
        End If
    End Sub
    Private Sub UpdateDatagridLine()
        DT.Rows(UpdateLineIndex)("Barcode") = CurrLine.BarcodeNo
        DT.Rows(UpdateLineIndex)("Description") = CurrLine.Desc
        DT.Rows(UpdateLineIndex)("Qty") = Cultural(CurrLine.ScannedUnitQty, True)
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        DataGrid1.Select(DataGrid1.CurrentRowIndex)
    End Sub
    Private Sub DataGrid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Try
            If DataGrid1.CurrentCell.RowNumber <> -1 Then
                DataGrid1.Select(DataGrid1.CurrentRowIndex)
                UpdateLineIndex = DataGrid1.CurrentCell.RowNumber
                CurrLine = ComittedLines(UpdateLineIndex)
                FillForm_FromCommitedLines()
                EditMode = True
                Delete.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Manipulate_ComittedLines(ByVal DeletedIndex As Integer)
        ' Transfering data inside array so we can delete the last index 
        Dim ArrLen As Integer = ComittedLines.Length - 1
        If DeletedIndex < ArrLen Then
            For i As Integer = DeletedIndex To ArrLen - 1
                ComittedLines(i) = ComittedLines(i + 1)
            Next
        End If
        Array.Resize(ComittedLines, ArrLen)
    End Sub
    Private Function Get_ReferenceNo() As String
        Dim ReferenceNo As String = ""
        db.read("[No_]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] = '{0}'", VendorName.Replace("'", "''")))
        Try
            If dr.Read Then
                ReferenceNo = dr.GetValue(0)
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try

        Return ReferenceNo
    End Function
    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Try
            ClearLineDisplayInfo()

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BarcodeBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarcodeBox.KeyUp
        If e.KeyValue = 13 And BarcodeBox.Enabled = True Then
            Read_BarcodeData()
        End If
    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click
        ClearLineDisplayInfo()
    End Sub
    Private Sub FillGrid_CommittedLines()
        If ComittedLines(0).BarcodeNo <> "" Then
            For i As Integer = 0 To ComittedLines.Length - 1
                If ComittedLines(i).BarcodeNo <> Nothing Then
                    Dim dp As DataRow = DT.NewRow
                    dp("Barcode") = ComittedLines(i).BarcodeNo
                    dp("Description") = ComittedLines(i).Desc
                    dp("Qty") = Cultural(ComittedLines(i).ScannedUnitQty, True)

                    DT.Rows.Add(dp)
                End If
            Next
        End If

        DataGrid1.DataSource = DT
    End Sub
    Private Sub Delete_Line()
        If DT.Rows.Count = 1 Then
            DataGrid1.Select(0)
            UpdateLineIndex = 0
            CurrLine.BarcodeNo = ComittedLines(0).BarcodeNo
            CurrLine.LineNo = ComittedLines(0).LineNo
        ElseIf DT.Rows.Count = 0 Then
            Return
        End If
        ThreadTimer.Dispose()
        Dim ans As MsgBoxResult
        ans = MsgBox("Delete Line With Barcode " + "(" + CurrLine.BarcodeNo + ")", MsgBoxStyle.YesNo, Nothing)
        If ans = vbYes Then
            db.Delete("[P/R Line]", String.Format("[Document No.] = '{0}' and [Line No.] = '{1}'", SessionID, CurrLine.LineNo))
            Manipulate_ComittedLines(UpdateLineIndex)
            DT.Rows(UpdateLineIndex).Delete()
            LineIndex -= 1
        End If
        InializeTimer()
    End Sub
    Private Sub UOM_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UOM.SelectedValueChanged
        If UOM.Focused And CurrLine.WeightItem = 0 Then
            Qty.Text = ""
            Qty2.Text = ""
            NetWeight.Text = ""
            CurrLine.QtyPerScannedUnit = Get_DefaultQtyPer(UOM.Text) / Get_DefaultQtyPer(CurrLine.ScannedUOM)
            If CurrLine.QtyPerScannedUnit < 1 And CurrLine.QtyPerScannedUnit > 0 Then
                SpecialCaseQty = True
            End If
            CurrLine.UOMCode = UOM.Text
        End If
    End Sub
    Private Function No_CodeCount() As Integer
        Dim Count As Integer = 0
        db.read("COUNT([Barcode])", "[P/R Line]", String.Format("[Document No.] = '{0}' AND [Barcode] like 'NO_CODE%'", SessionID))
        If dr.Read Then
            Count = dr.GetValue(0)
        End If
        Return Count
    End Function
    Private Sub Calculate_Quantity()
        Try
            If CurrLine.WeightItem = 1 Or CurrLine.NewWeightItem = 1 Then
                CurrLine.ScannedUnitQty = CDec(CurrLine.Quantity * CurrLine.QtyPerScannedUnit)
                Return
            End If
            If Qty.Text.Trim = "0" Or Qty.Text.Trim = String.Empty Then
                CurrLine.Quantity = 1 * CInt(Qty2.Text.Trim)
            ElseIf Qty2.Text.Trim = "0" Or Qty2.Text.Trim = String.Empty Then
                CurrLine.Quantity = CInt(Qty.Text.Trim) * 1
            ElseIf (Qty.Text.Trim = "0" Or Qty.Text.Trim = String.Empty) And (Qty2.Text.Trim = "0" Or Qty2.Text.Trim = String.Empty) Then
                CurrLine.Quantity = "1"
            Else
                CurrLine.Quantity = CInt(Qty.Text.Trim) * CInt(Qty2.Text.Trim)
            End If

            If CurrLine.NewLine = 0 And CurrLine.WeightItem = 0 And EditMode = False And Qty.Text.Trim <> String.Empty Then
                CurrLine.Quantity += CDec(CurrLine.EnteredQty1 * CurrLine.EnteredQty2)
            ElseIf CurrLine.NewLine = 0 And CurrLine.WeightItem = 0 And EditMode = False And Qty.Text.Trim = String.Empty Then
                CurrLine.Quantity = Flow(CurrLine.BarcodeNo)
            End If

            CurrLine.ScannedUnitQty = CDec(CurrLine.Quantity * CurrLine.QtyPerScannedUnit)
        Catch ex As Exception
            CurrLine.Quantity = "1"
            If CurrLine.NewLine = 0 And CurrLine.WeightItem = 0 And EditMode = False And Qty.Text.Trim <> String.Empty Then
                CurrLine.Quantity += CDec(CurrLine.EnteredQty1 * CurrLine.EnteredQty2)
            ElseIf CurrLine.NewLine = 0 And CurrLine.WeightItem = 0 And EditMode = False And Qty.Text.Trim = String.Empty Then
                CurrLine.Quantity = Flow(CurrLine.BarcodeNo)
            End If
            CurrLine.ScannedUnitQty = CDec(CurrLine.QtyPerScannedUnit * CurrLine.Quantity)
        End Try
    End Sub
    Private Sub Calculate_QuantityMultiple()
        If CurrLine.WeightItem = 1 Or CurrLine.NewWeightItem = 1 Then
            CurrLine.Quantity = CStr(CDec(CurrLine.Quantity) * CurrLine.Multiply)
            CurrLine.TotalWeight = CStr(CDec(CurrLine.TotalWeight) * CurrLine.Multiply)
            If CurrLine.PackagingWeight <> "0" Then
                CurrLine.PackagingWeight = CStr(CDec(CurrLine.PackagingWeight) * CurrLine.Multiply)
            End If
        End If
    End Sub
    Private Function Check_SpecialQty() As Boolean
        Dim Calc As Integer = CurrLine.Quantity Mod (1 / CurrLine.QtyPerScannedUnit)
        If Calc <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Edit_RfEndTime()
        db.Update("[P/R Header]", "[RF End Time] = '" + DateTime.Now + "'", String.Format("[No.] = '{0}'", SessionID))
        DBClose(False)
    End Sub
    Private Function CheckFlow() As Boolean
        If Not Flow.ContainsKey(CurrLine.BarcodeNo) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Fill_Flow()
        If ComittedLines(0).BarcodeNo <> "" Then
            For i As Integer = 0 To ComittedLines.Length - 1
                If Not Flow.ContainsKey(ComittedLines(i).BarcodeNo) Then
                    Flow.Add(ComittedLines(i).BarcodeNo, CDec(ComittedLines(i).ScannedUnitQty))
                Else
                    Flow(ComittedLines(i).BarcodeNo) = Flow(ComittedLines(i).BarcodeNo) + CDec(ComittedLines(i).ScannedUnitQty)
                End If
            Next
        End If
    End Sub
    Private Sub AddToFlow()
        If Not Flow.ContainsKey(CurrLine.BarcodeNo) Then
            Flow.Add(CurrLine.BarcodeNo, CDec(CurrLine.ScannedUnitQty))
        Else
            Flow(CurrLine.BarcodeNo) = Flow(CurrLine.BarcodeNo) + CDec(CurrLine.ScannedUnitQty)
        End If
    End Sub
    Private Sub UpdateFlow(ByVal Difference As Decimal)
        If Not Flow.ContainsKey(CurrLine.BarcodeNo) And Difference = 0 Then
            Flow(CurrLine.BarcodeNo) = CDec(CurrLine.ScannedUnitQty)
        ElseIf QtyDifference > 0 Then
            Flow(CurrLine.BarcodeNo) = Flow(CurrLine.BarcodeNo) + QtyDifference
        ElseIf QtyDifference < 0 Then
            Flow(CurrLine.BarcodeNo) = Flow(CurrLine.BarcodeNo) - Math.Abs(QtyDifference)
        End If
    End Sub
    Private Sub DeleteFlow()
        If Flow.ContainsKey(CurrLine.BarcodeNo) Then
            Flow(CurrLine.BarcodeNo) = Flow(CurrLine.BarcodeNo) - CDec(CurrLine.ScannedUnitQty)
            If Flow(CurrLine.BarcodeNo) <= 0 Then
                Flow.Remove(CurrLine.BarcodeNo)
            End If
        End If
    End Sub
    Private Sub Restrict_Alpha(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If CurrLine.WeightItem = 1 Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Convert.ToChar(8))
        Else
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(8))
        End If
    End Sub
    Private Sub Qty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Qty.KeyPress
        Restrict_Alpha(e)
    End Sub

    Private Sub Qty2_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Qty2.KeyPress
        Restrict_Alpha(e)
    End Sub
    Private Sub Qty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Qty.TextChanged
        Try
            If Form_Submitting = False Then
                Calculate_Quantity()
                NetWeight.Text = Cultural(CurrLine.Quantity, True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Qty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Qty2.TextChanged
        Try
            If Form_Submitting = False Then
                Calculate_Quantity()
                NetWeight.Text = Cultural(CurrLine.Quantity, True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rectra_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If SessionID <> String.Empty Then
            Edit_RfEndTime()
        End If
        Clear_VendorDataTable()
        Barcode100.EnableScanner = False
        ThreadTimer.Dispose()
    End Sub

    Private Sub EditWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditWeight.Click
        Edit_WeightInput()
    End Sub
    Private Sub Qty_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Qty.KeyUp
        If e.KeyValue = 13 And Qty.Text.Trim <> String.Empty And Qty.Text.Trim <> "0" Then
            Qty2.Focus()
        End If
    End Sub

    Private Sub Qty2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Qty2.KeyUp
        If e.KeyValue = 13 Then
            Submit_Handle()
        End If
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Delete_Line()
        DeleteFlow()
        ClearLineDisplayInfo()
    End Sub

    Private Sub Rectra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyValue = 125 Then
                If Clear.Enabled = True Then
                    ClearLineDisplayInfo()
                Else
                    ClearLineDisplayInfo()

                    Me.Close()
                End If
            ElseIf e.KeyValue = 13 And CurrLine.WeightItem = 1 And BarcodeBox.Enabled = False Then
                Submit_Handle()
            ElseIf e.KeyValue = 112 Then
                If Type = "2" And Code = "3" Then
                    ClearLineDisplayInfo()
                    Dim No_Code As Integer = No_CodeCount()
                    If No_Code = 0 Then
                        BarcodeBox.Text = "NO_CODE_1"
                    Else
                        BarcodeBox.Text = "NO_CODE_" + CStr(No_Code + 1)
                    End If

                    If DataGrid1.CurrentRowIndex <> -1 Then
                        DataGrid1.UnSelect(DataGrid1.CurrentRowIndex)
                    End If
                    BarcodeBox.Enabled = False
                    'Barcode100.EnableScanner = False
                    InializeNewLine()
                    FillCurrLineNewItem()
                End If
            ElseIf e.KeyValue = 113 Then
                If CurrLine.BarcodeNo <> String.Empty And CurrLine.NewItem = 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    Barcode100.EnableScanner = False
                    ThreadTimer.Dispose()
                    PrintBarcodeHandle()
                    InializeTimer()
                    Barcode100.EnableScanner = True
                    Cursor.Current = Cursors.Default
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UOM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UOM.KeyDown
        If e.KeyValue = 13 And UOM.Text <> "" Then
            Qty.Focus()
        End If
    End Sub

    Private Sub VednorIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorIt.Click
        Cursor.Current = Cursors.WaitCursor
        If Type = "2" And Code = "3" Then
            Fill_VendorDataTable(RefNo)
        ElseIf Type = "3" And Code = "5" Then
            Fill_BarcodeDataTable()
        End If

        ThreadTimer.Dispose()
        Dim VendorItem As VendorItem = New VendorItem(Code)
        If VendorItem.ShowDialog = Windows.Forms.DialogResult.OK Then
            BarcodeBox.Text = VendorItem.Barcode
            Read_BarcodeData()
        End If
        VendorItem.Dispose()
        InializeTimer()
    End Sub
    Private Sub PrintBarcodeHandle()
        If CurrLine.UOMCode <> CurrLine.ScannedUOM Then
            db.read("[Barcode No_]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Item No_] = '{0}' AND [Variant Code] = '{1}' AND [Unit Of Measure Code] = '{2}' AND [Default Barcode] = '{3}'", CurrLine.ItemNo, CurrLine.VarCode, CurrLine.UOMCode, "1"))

            If dr.Read Then
                Dim XLine As New Line

                XLine.BarcodeNo = dr.GetValue(0)
                XLine.Desc = CurrLine.Desc
                XLine.UOMCode = CurrLine.UOMCode
                PrintBarcode(XLine)
                DBClose(False)
            Else
                DBClose(False)
                db.read("[Barcode No_]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Item No_] = '{0}' AND [Variant Code] = '{1}' AND [Unit Of Measure Code] = '{2}' AND [Default Barcode] = '{3}'", CurrLine.ItemNo, CurrLine.VarCode, CurrLine.UOMCode, "0"))

                If dr.Read Then
                    Dim XLine As New Line

                    XLine.BarcodeNo = dr.GetValue(0)
                    XLine.Desc = CurrLine.Desc
                    XLine.UOMCode = CurrLine.UOMCode
                    PrintBarcode(XLine)
                Else
                    ThreadTimer.Dispose()
                    Dim ans As MsgBoxResult
                    ans = MsgBox(String.Format("Unit of Measure ({0}) for Item No ({1}) doesn't have a barcode, Proceed with printing?"), MsgBoxStyle.YesNo, Nothing)
                    If ans = vbYes Then
                        PrintBarcode(CurrLine)
                    Else
                        Exit Sub
                    End If
                End If
                DBClose(False)
                InializeTimer()
            End If
        Else
            PrintBarcode(CurrLine)
        End If
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
    Private Sub PrintBarcode(ByVal Line As Line)
        Dim Info(1) As Integer

        Info = Print_HandleDirect("1", "SMALL", Line)
        If Info(0) = 1 Then
            Print_Register(CInt(Info(1)))
            MessageBox("Printed")
        End If
    End Sub
    Private Sub Print_Register(ByVal Qty As Integer)
        If CurrLine.Printed = 0 Then
            CurrLine.Printed = 1
            CurrLine.PrintedQty = Qty
            db.Update("[P/R Line]", String.Format("[Printed] = '{0}' , [Printed Qty] = '{1}'", "1", Qty), String.Format("[Document No.] = '{0}' AND [Line No.] = '{1}'", SessionID, CurrLine.LineNo))

            DBClose(True)
            ComittedLines(UpdateLineIndex).Printed = 1
            ComittedLines(UpdateLineIndex).PrintedQty = CurrLine.PrintedQty
        Else
            CurrLine.PrintedQty = CStr(CInt(CurrLine.PrintedQty) + Qty)
            db.Update("[P/R Line]", String.Format("[Printed Qty] = '{0}'", CurrLine.PrintedQty), String.Format("[Document No.] = '{0}' AND [Line No.] = '{1}'", SessionID, CurrLine.LineNo))

            DBClose(True)
            ComittedLines(UpdateLineIndex).PrintedQty = CurrLine.PrintedQty
        End If
    End Sub
    Private Sub Barcode21_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection) Handles Barcode100.OnScan
        Try
            If BarcodeBox.Enabled = True Then
                Dim Barcode As String = ""
                For Each D As ScanData In scanDataCollection
                    Barcode = D.Text
                Next

                If Barcode <> String.Empty Then
                    BarcodeBox.Text = Barcode
                    Read_BarcodeData()
                End If
            Else
                MessageBox("Clear form to scan barcode")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
