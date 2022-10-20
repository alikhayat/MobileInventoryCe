Imports Arabic.Controls
Imports Symbol.Barcode2
Imports System.Threading
Public Structure LabelLine
    Public Desc As String
    Public ARDesc As String
    Public Barcode As String
    Public UOM As String
    Public ItemNo As String
    Public DolphinNo As String
    Public Price As String
    Public Var As String
    Public BestBefore As String
    Public Quantity As Integer
    Public Vendor As String
    Public ProductGroup As String
    Public VATGroup As String
    Public TimeScanned As DateTime
End Structure
Public Class Label
    Private SessionID As String
    Private Action As Integer
    Private Type As String
    Private Code As String
    Private Exp As Boolean
    Private MobilePrinitng As Boolean
    Private JobID As String


    Dim Preline As LabelLine
    Dim crAr As New Arabic.Controls.ArabicShape
    Dim LineNo As Integer
    Dim QTY As String
    Dim IntialRun As Integer = 0
    Dim SessionCreating As Boolean = False
    Dim Packed As String
    Dim Expiry As String
    Dim dt As Date = Date.Now.ToShortDateString
    Dim BestBefore As Integer = 0
    Dim Arrows As Boolean = False
    Dim TimeScanned As DateTime
    Dim DBAR As String = ""
    Dim ShowAR As String = ""
    Dim TrimmedDigitsL As String = ""
    Dim TrimmedDigitsF As String = ""
    Public Sub New(ByVal _SessionID As String, ByVal _Action As Integer, ByVal _Type As String, ByVal _Code As String, ByVal _Exp As Boolean, ByVal _MobilePrinting As Boolean, Optional ByVal _JobID As String = "")
        InitializeComponent()
        SessionID = _SessionID
        Action = _Action
        Type = _Type
        Code = _Code
        Exp = _Exp
        MobilePrinitng = _MobilePrinting
        JobID = _JobID
    End Sub
    
    Private Sub Label_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Cursor.Current = Cursors.Default
        LineNo = 0
        Clear_Labels()
        BarcodeBox.Text = ""
        QuantityBox.Text = ""
        Reset.Enabled = False
        Reset.Visible = False
        Submit.Enabled = False
        ResetUOMControls()
        '
        DateTimePicker1.Enabled = False
        BarcodeBox.Enabled = True
        BarcodeBox.Focus()
        IntialRun = 0
        Barcode21.EnableScanner = True
        SetExpiry()
        GetLastLine()
    End Sub
    Private Sub Clear_Labels()
        Desc.Text = String.Empty
        ArabicDesc.Text = String.Empty
        UOM.Text = String.Empty
        VarCode.Text = String.Empty
        Price.Text = String.Empty
        ItemNo.Text = String.Empty
    End Sub
    Private Sub Read_BarcodeData()
       
        If BarcodeBox.Text.Trim <> String.Empty And BarcodeBox.Text.Length > 4 Then
            ' Excute Query
            db.read("Barcodes.[Barcode No_], Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code], Barcodes.[Variant Code], Barcodes.[Dolphin Item No_], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                    "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "[Barcode No_] = " + "'" + BarcodeBox.Text.Trim + "'")

        ElseIf BarcodeBox.Text.Trim <> String.Empty And BarcodeBox.Text.Length = 4 Then
            ' Excute Query
            db.read("Barcodes.[Barcode No_], Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code], Barcodes.[Variant Code], Barcodes.[Dolphin Item No_], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                    "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "Barcodes.[PLU] = " + "'" + BarcodeBox.Text.Trim + "'")
        End If
        Fill_Labels()

        Get_Variants(ItemNo.Text.Trim, BarcodeBox.Text.Trim, UOM.Text.Trim, VarCode.Text.Trim)
    End Sub
    Private Function Read_BBD(ByVal ItemNo As String) As Integer
        Dim B As Integer = 0
        db.read("[Best Before Days]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", ItemNo))
        If dr.Read Then
            B = CInt(dr.GetValue(0))
            If B = 0 Then
                B = 30
            End If
        Else
            B = 30
        End If
        Return B
    End Function
    Private Sub Fill_Labels()
        SessionCreating = True
        ErrorOcurred = False
        Clear_Labels()

        Try
            If dr.Read And Not MobilePrinitng Then
                Desc.Text = dr.GetValue(2)
                UOM.Text = dr.GetValue(4)
                VarCode.Text = dr.GetValue(5)
                ItemNo.Text = dr.GetValue(1)

                Price.Text = Cultural(CStr(dr.GetValue(7)), False) + " L.L"

                DBAR = dr.GetValue(3)
            ElseIf MobilePrinitng Then
                FillLablesMobile()
            Else
                MessageBox("Barcode not found")
                Undo()
                ErrorOcurred = True
            End If
            If ErrorOcurred = False Then
                If DBAR <> String.Empty Then
                    ShowAR = crAr.DisplayArabic(Remove_Leading_Numbers(DBAR))
                    ShowAR = TrimmedDigitsL + ShowAR + TrimmedDigitsF
                    Preline.ARDesc = ShowAR
                Else
                    ShowAR = ""
                End If
                BestBefore = Read_BBD(ItemNo.Text)
                SetExpiry()
                ArabicDesc.Text = ShowAR
                Submit.Enabled = True
            End If        
        Catch ex As Exception
        Finally
            If ErrorOcurred = False Then
                db.DBClose(False)
                BarcodeBox.Enabled = False
                Reset.Enabled = True
                Reset.Visible = True
                CancelLbl.Enabled = True
                DateTimePicker1.Enabled = True
                QuantityBox.Enabled = True
                QuantityBox.Focus()
                Submit.Enabled = True
            End If
        End Try
    End Sub
    Private Sub FillLablesMobile()
        Cursor.Current = Cursors.WaitCursor
        Dim ShelfInfo = GetShelf(BarcodeBox.Text.Trim)
        Dim Shelf() As String
        If Not ShelfInfo = "" Then
            Shelf = ShelfInfo.Split(";")
            ItemNo.Text = Shelf(1)
            Desc.Text = Shelf(4)
            UOM.Text = Shelf(3)
            VarCode.Text = Shelf(2)
            DBAR = Shelf(10)
            Preline.Vendor = Shelf(5)
            Preline.ProductGroup = Shelf(6)
            Preline.DolphinNo = Shelf(9)
            Preline.VATGroup = Shelf(8)

            Try
                Dim TmpPrice As Decimal = Decimal.Parse(Shelf(7))

                If TmpPrice > 0 Then
                    Price.ForeColor = Color.Blue
                    Price.Text = Cultural(TmpPrice, False) + " L.L"
                ElseIf TmpPrice < 0 Then
                    Price.ForeColor = Color.Red
                    Price.Text = Cultural(Math.Abs(TmpPrice), False) + " L.L"
                    ErrorOcurred = True
                Else
                    Price.ForeColor = Color.Red
                    Price.Text = "Error"
                    ErrorOcurred = True
                End If
            Catch ex As Exception
                ErrorOcurred = True
            End Try
        Else
            ErrorOcurred = True
        End If

        'Preline.DolphinNo = dr.GetValue(6)
        '' Get Vendor, Product Group, VAT
        'DBClose(False)
        'Preline.Vendor = ""
        'db.read("[Vendor No_]", "[" + CompanyName.Replace(".", "_") + "$Stockkeeping Unit]", String.Format("[Item No_] = '{0}' and [Variant Code] = '{1}'", ItemNo.Text, VarCode.Text))
        'Try
        '    If dr.Read Then
        '        Preline.Vendor = dr.GetValue(0)
        '    End If
        'Catch ex As Exception
        'Finally
        '    DBClose(False)
        'End Try

        'db.read("[Vendor No_],[Product Group Code],[Gen_ Prod_ Posting Group]", "[" + CompanyName.Replace(".", "_") + "$Item]", String.Format("[No_] = '{0}'", ItemNo.Text))
        'Try
        '    If dr.Read Then
        '        If Preline.Vendor = "" Then
        '            Preline.Vendor = dr.GetValue(0)
        '        End If
        '        Preline.ProductGroup = dr.GetValue(1)
        '        Preline.VATGroup = dr.GetValue(2)
        '    End If
        'Catch ex As Exception
        'Finally
        '    DBClose(False)
        'End Try
    End Sub
    Private Sub QuantityBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles QuantityBox.KeyUp
        If e.KeyValue = 13 Then
            Session_Handling()
        End If
    End Sub
    Private Sub Session_Handling()
        If QuantityBox.Text.Trim = String.Empty Then
            QTY = "1"
        Else
            QTY = QuantityBox.Text.Trim
        End If

        Select Case Action
            Case 1
                If IntialRun = 0 And ErrorOcurred = False And MobilePrinitng = False Then
                    New_Session()
                    AddCounter(Type)
                    New_Line()
                    LineNo += 1
                    FillFromForm()
                    If ErrorOcurred = True Then
                        db.Delete("[Session Header]", String.Format("ID = '{0}'", SessionID))
                    End If
                ElseIf (IntialRun <> 0 And ErrorOcurred = False And MobilePrinitng = False) Then
                    LineNo = LabelLineNo(SessionID, Code)
                    New_Line()
                    LineNo += 1
                    FillFromForm()
                ElseIf IntialRun = 0 And ErrorOcurred = False And MobilePrinitng = True Then
                    MobilePrint(True)
                ElseIf IntialRun <> 0 And ErrorOcurred = False And MobilePrinitng = True Then
                    MobilePrint(False)
                End If
            Case 2
                LineNo = LabelLineNo(SessionID, Code)
                New_Line()
                LineNo += 1
                FillFromForm()
        End Select

        Undo()
    End Sub
    Private Sub New_Session()
        Dim printed As Integer = 0
        If MobilePrinitng Then
            printed = 1
        End If

        Try
            db.Insert("[Session Header]", String.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'", SessionID, Login.UserId, Store, DeviceID, Type, DateTime.Now.ToString, "0", Code, "0", printed.ToString, JobID, "", printed))
        Catch ex As Exception

        Finally
            If db.ErrorOcurred = False Then
                IntialRun = 1
                LineNo += 1
            End If
        End Try
    End Sub
    Private Sub New_Line()
        Dim printed As Integer = 0
        If MobilePrinitng Then
            printed = 1
        End If

        GetARB()

        If Not MobilePrinitng Then
            db.Insert("[Session Label Line]", String.Format(" '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'", SessionID, Login.UserId, Store, DeviceID, LineNo, Code, BarcodeBox.Text.Trim, Desc.Text.Replace("'", "''"), _
                                                    QTY, ItemNo.Text, UOM.Text, VarCode.Text, Desc.Text.Replace("'", "''"), "", DBAR, Packed, Expiry, DateTime.Now, printed.ToString, "", ""))
        Else
            db.Insert("[Session Label Line]", String.Format(" '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'", SessionID, Login.UserId, Store, DeviceID, LineNo, Code, BarcodeBox.Text.Trim, Desc.Text.Replace("'", "''"), _
                                                    QTY, ItemNo.Text, UOM.Text, VarCode.Text, Desc.Text.Replace("'", "''"), "", DBAR, Packed, Expiry, DateTime.Now, printed.ToString, Date.Now.ToShortDateString, DateTime.Now))
        End If

    End Sub

    Private Sub BarcodeBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarcodeBox.KeyUp
        If e.KeyValue = 13 And BarcodeBox.Text.Trim <> String.Empty Then
            If MobilePrinitng Then
                Price.Text = ""
            End If
            Read_BarcodeData()
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResetUOMControls()
        Undo()
    End Sub
    Private Sub Undo()
        If Code = "SHELF" Then
            ResetUOMControls()
        End If
        Clear_Labels()
        BarcodeBox.Enabled = True
        BarcodeBox.Text = ""
        QuantityBox.Text = ""
        Reset.Enabled = False
        Reset.Visible = False
        DateTimePicker1.Value = Date.Now.ToShortDateString
        DateTimePicker2.Value = Date.Now.ToShortDateString
        CancelLbl.Enabled = False
        QuantityBox.Enabled = False
        Submit.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        BarcodeBox.Focus()


        SessionCreating = False
        Barcode21.EnableScanner = True
    End Sub

    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        If SessionCreating = True Then
            Undo()
        Else
            Barcode21.EnableScanner = False
            Me.Close()
        End If
    End Sub

    Private Sub QuantityBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles QuantityBox.KeyPress
        Restrict_Alpha(e)
    End Sub

    Private Sub BarcodeBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BarcodeBox.KeyPress
        Restrict_Alpha(e)
    End Sub
    Private Sub Restrict_Alpha(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 13 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Barcode21_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection) Handles Barcode21.OnScan
        Dim Barcode As String = ""
        For Each Data As ScanData In scanDataCollection
            Barcode = Data.Text
        Next
        If Barcode <> String.Empty Then
            BarcodeBox.Text = Barcode
            Read_BarcodeData()
        End If
    End Sub
    Private Sub SetExpiry()
        'Set Packing and Expiry date 
        Try
            If Exp = True Then
                Label2.Visible = True
                Label5.Visible = True
                DateTimePicker1.Visible = True
                DateTimePicker1.Enabled = True
                DateTimePicker2.Visible = True
                DateTimePicker2.Enabled = True
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd/MM/yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd/MM/yyyy"
                DateTimePicker2.Value = Date.Now.ToShortDateString
                If BestBefore <> 0 Then
                    DateTimePicker1.Value = Date.Now.AddDays(BestBefore).ToShortDateString
                    DateTimePicker1.Text = Date.Now.AddDays(BestBefore).ToShortDateString
                Else
                    DateTimePicker1.Value = Date.Now.AddDays(30).ToShortDateString
                    DateTimePicker1.Text = Date.Now.AddDays(30).ToShortDateString
                End If
                Packed = DateTimePicker2.Value.ToShortDateString
                Expiry = DateTimePicker1.Value.ToShortDateString
            Else
                Label2.Visible = False
                Label5.Visible = False
                DateTimePicker1.Visible = False
                DateTimePicker1.Enabled = False
                DateTimePicker2.Visible = False
                DateTimePicker2.Enabled = False
                Packed = ""
                Expiry = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            If Exp = True Then
                Expiry = DateTimePicker1.Value.ToShortDateString
            Else
                Expiry = ""
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Try
            If Exp = True Then
                Packed = DateTimePicker2.Value.ToShortDateString
            Else
                Packed = Date.Now.ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If QuantityBox.Enabled = True Then
            Session_Handling()
        End If
    End Sub
    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click
        If SessionCreating = True Then
            Undo()
        End If
    End Sub

    Private Sub Label_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control
            ctrl = sender
            If e.KeyValue = 13 Or e.KeyValue = 126 Then

            ElseIf e.KeyValue = 125 Then
                If SessionCreating = True Then
                    Undo()
                Else
                    Barcode21.EnableScanner = False
                    Me.Close()
                End If
            ElseIf e.KeyValue = 38 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            ElseIf (e.KeyValue = 38 Or e.KeyValue = 40) And Button1.Visible = True Then
                Arrows = True
                Show_UOMs()
                If e.KeyValue = 38 Then
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
                ElseIf e.KeyValue = 40 Then
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Get_Variants(ByVal No As String, ByVal Barcode As String, ByVal UOM As String, ByVal Var As String)
        db.read("Distinct [Unit of Measure Code]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Item No_] = '{0}' and [Barcode No_] <> '{1}' and [Unit of Measure Code] <> '{2}' and [Variant Code] = '{3}'", No, Barcode, UOM, Var))
        ResetUOMControls()
        Try
            While dr.Read
                ListBox1.Items.Add(dr.GetValue(0).ToString)
            End While

            If ListBox1.Items.Count > 0 Then
                Button1.Visible = True
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub Show_UOMs()
        If ListBox1.Visible = False Then
            ListBox1.Visible = True
            ListBox1.Focus()
            Application.DoEvents()
        ElseIf ListBox1.Visible = True Then
            ListBox1.Visible = False
            Arrows = False
        End If
    End Sub
    Private Sub Alter_UOM()
        Try
            Dim UOM As String = ListBox1.SelectedItem.ToString
            Dim Barcode As String = Get_Barcode(UOM, ItemNo.Text.Trim)
            BarcodeBox.Text = Barcode
            Read_BarcodeData()
        Catch ex As Exception
        End Try
    End Sub
    Private Function Get_Barcode(ByVal UOM As String, ByVal ItemNo As String) As String
        Dim Barcode As String = String.Empty
        db.read("[Barcode No_]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Item No_] = '{0}' and [Unit of Measure Code] = '{1}'", ItemNo, UOM))

        If dr.Read Then
            Barcode = dr.GetValue(0).ToString
        End If
        Return Barcode
    End Function
    Private Sub Label_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
        DBClose(True)
    End Sub
    Private Sub BackButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        If SessionCreating = True Then
            Undo()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Show_UOMs()
    End Sub

    Private Sub ListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged
        If Arrows = False Then
            Alter_UOM()
        End If
    End Sub

    Private Sub ListBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
        Try
            If Arrows = True And e.KeyValue = 13 Then
                Arrows = False
                Alter_UOM()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ResetUOMControls()
        Button1.Visible = False
        ListBox1.Visible = False
        ListBox1.Items.Clear()
    End Sub
    Private Sub GetLastLine()
        Dim LineNo As String = String.Empty
        If Action <> 2 Then
            Return
        End If
        Try
            db.read("MAX([Line No.])", "[Session Label Line]", String.Format("[Session ID] = '{0}' and [User ID] = '{1}' and [Store No.] = '{2}' and [Device ID] = '{3}' and [Label Code] = '{4}'", SessionID, Login.UserId, Store, DeviceID, Code))
            If dr.Read Then
                LineNo = CStr(dr.GetValue(0))
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
        Try
            db.read("[Barcode],[Text 1],[Text 3],[Quantity],[Item No.],[Unit Of Measure Code],[Variant Code],[Expiry Date]", _
                "[Session Label Line]", String.Format("[Session ID] = '{0}' and [User ID] = '{1}' and [Store No.] = '{2}' and [Device ID] = '{3}' and [Line No.] = '{4}'", SessionID, Login.UserId, Store, DeviceID, LineNo))
            If dr.Read Then
                Preline.Barcode = CStr(dr.GetValue(0))
                Preline.Desc = CStr(dr.GetValue(1))
                'Preline.ARDesc = CStr(dr.GetValue(2)) 
                Preline.ARDesc = TrimmedDigitsL + crAr.DisplayArabic(Remove_Leading_Numbers(dr.GetValue(2))) + TrimmedDigitsF
                Preline.Quantity = CStr(dr.GetValue(3))
                Preline.ItemNo = CStr(dr.GetValue(4))
                Preline.UOM = CStr(dr.GetValue(5))
                Preline.Var = CStr(dr.GetValue(6))
                If Exp = True Then
                    Preline.BestBefore = CType(dr.GetValue(7), Date)
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
        Try
            db.read("CONVERT(DECIMAL(9, 0),[Unit Price Including VAT])", "[" + CompanyName.Replace(".", "_") + "$Sales Price]", String.Format("[Item No_] = '{0}' and [Sales Type] = '1' and [Sales Code] = '{1}' and [Unit Of Measure Code] = '{2}' and [Variant Code] = '{3}'", Preline.ItemNo, Store, Preline.UOM, Preline.Var))
            If dr.Read Then
                Preline.Price = CStr(dr.GetValue(0))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillFromForm()
        Preline.Desc = Desc.Text
        Preline.ARDesc = ShowAR
        Preline.Barcode = BarcodeBox.Text
        Preline.UOM = UOM.Text
        Preline.Var = VarCode.Text
        Preline.ItemNo = ItemNo.Text
        If QuantityBox.Text <> String.Empty Then
            Preline.Quantity = CInt(QuantityBox.Text)
        Else
            Preline.Quantity = 1
        End If

        Preline.Price = Price.Text
        If Exp = True Then
            Preline.BestBefore = DateTimePicker1.Value
        End If
    End Sub
    Private Sub FillFromPreline()
        If Preline.ItemNo <> "" Then
            Desc.Text = Preline.Desc
            ArabicDesc.Text = Preline.ARDesc
            BarcodeBox.Text = Preline.Barcode
            UOM.Text = Preline.UOM
            VarCode.Text = Preline.Var
            ItemNo.Text = Preline.ItemNo
            QuantityBox.Text = Preline.Quantity
            Price.Text = Preline.Price
            If Exp = True Then
                DateTimePicker1.Value = Preline.BestBefore
            End If
            BarcodeBox.Enabled = False
            Reset.Enabled = True
            Reset.Visible = True
            CancelLbl.Enabled = True
            DateTimePicker1.Enabled = True
            QuantityBox.Enabled = True
            QuantityBox.Focus()
            Submit.Enabled = True
        End If
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        FillFromPreline()
        SessionCreating = True
    End Sub
    Private Sub GetARB()
        'Try
        '    If Preline.ARDesc = String.Empty Then
        '        ARB = crAr.DisplayArabic(AR)
        '    ElseIf AR = String.Empty Then
        '        ARB = crAr.DisplayArabic(Preline.ARDesc)
        '        AR = ARB
        '    Else
        '        ARB = crAr.DisplayArabic(AR)
        '    End If
        'Catch ex As Exception

        'End Try      
    End Sub
    Private Sub MobilePrint(ByVal Inial As Boolean)
        Cursor.Current = Cursors.WaitCursor
        FillFromForm()
        If Not BluetoothPrint(Preline) Then
            Dim Result As New MsgBoxResult
            Result = MsgBox("Print failed, Do you want to retry?", MsgBoxStyle.RetryCancel, Nothing)
            If Result = MsgBoxResult.Retry Then
                Cursor.Current = Cursors.WaitCursor
                If BluetoothReconnect() Then
                    If Not BluetoothPrint(Preline) Then
                        Undo()
                        Cursor.Current = Cursors.Default
                        Me.Close()
                    Else
                        If Inial = True Then
                            New_Session()
                            AddCounter(Type)
                            New_Line()
                            LineNo += 1
                            FillFromForm()
                            Cursor.Current = Cursors.Default
                        Else
                            New_Line()
                            LineNo += 1
                            FillFromForm()
                            Cursor.Current = Cursors.Default
                        End If

                    End If
                Else
                    Undo()
                    Cursor.Current = Cursors.Default
                    Me.Close()
                End If
            End If
        Else
            If Inial = True Then
                New_Session()
                AddCounter(Type)
                New_Line()
                LineNo += 1
                FillFromForm()
                Cursor.Current = Cursors.Default
            Else
                New_Line()
                LineNo += 1
                FillFromForm()
                Cursor.Current = Cursors.Default
            End If
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
    'Private Sub HandleMobileSessions()
    '    If MobilePrinitng Then
    '        Dim thread As New Thread(AddressOf PostMobileSessions)
    '        thread.IsBackground = True
    '        thread.Start()
    '    End If
    'End Sub
    'Private Sub PostMobileSessions()
    '    Dim Post As New PostLabels
    '    Dim MobileSession(-1) As String
    '    Post.postSessions(MobileSession)
    'End Sub
    Private Sub VendorIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorIt.Click
        Cursor.Current = Cursors.WaitCursor
        Fill_SessionLinesDatatable(SessionID)
        ThreadTimer.Dispose()
        Dim VendorItem As VendorItem = New VendorItem()
        If VendorItem.ShowDialog = Windows.Forms.DialogResult.OK Then
            BarcodeBox.Text = VendorItem.Barcode
            Read_BarcodeData()
        End If
        VendorItem.Dispose()
        InializeTimer()
    End Sub
End Class