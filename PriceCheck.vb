Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Arabic.Controls
Imports Symbol.Barcode2

Public Class PriceCheck
    Dim crAr As New Arabic.Controls.ArabicShape
    Dim Arrows As Boolean = False
    Dim Barcode As String = Nothing

    Public Sub New()
        InitializeComponent()
        InializeTimer()
    End Sub
    Private Sub PriceCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResetControls()
        BarcodeBox.Focus()

        Barcode211.Config.DecoderParameters.UPCE0Params.Preamble = Preambles.System
        Barcode211.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = True
        Barcode211.EnableScanner = True
    End Sub
    Private Sub PriceCheck_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
        ResetControls()
        DBClose(True)
    End Sub
    Private Sub Barcode21_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection) Handles Barcode211.OnScan
        Dim Barcode As String = ""
        For Each Data As ScanData In scanDataCollection
            Barcode = Data.Text
        Next
        If Barcode <> String.Empty Then
            BarcodeBox.Text = Barcode
            Read_Data()
        End If
    End Sub
    Private Sub Read_Data()
        If CheckBox1.Checked = True Then
            Label2.Text = ""
        End If
        If BarcodeBox.Text.Trim <> String.Empty And BarcodeBox.Text.Length > 4 Then
            ' Excute Query
            db.read("Barcodes.[Barcode No_], Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code], Barcodes.[Variant Code], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                    "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "[Barcode No_] = " + "'" + BarcodeBox.Text.Trim + "'")
        ElseIf BarcodeBox.Text.Trim <> String.Empty And BarcodeBox.Text.Length = 4 Then
            ' Excute Query
            db.read("Barcodes.[Barcode No_], Barcodes.[Item No_], Barcodes.[Description], Barcodes.[Arabic Description], Barcodes.[Unit of Measure Code], Barcodes.[Variant Code], CONVERT(DECIMAL(9, 0), dbprice.[Unit Price Including VAT]) AS Price ", _
                    "[" + CompanyName.Replace(".", "_") + "$Sales Price] AS dbprice INNER JOIN [" + CompanyName.Replace(".", "_") + "$Barcodes] AS Barcodes ON dbprice.[Item No_] = Barcodes.[Item No_] AND dbprice.[Sales Type] = '1' AND dbprice.[Sales Code] = '" + Store + "' AND dbprice.[Unit of Measure Code] = Barcodes.[Unit of Measure Code] AND dbprice.[Variant Code] = Barcodes.[Variant Code]", "Barcodes.[PLU] = " + "'" + BarcodeBox.Text.Trim + "'")
        Else
            MessageBox("Barcode Not Valid")
            Exit Sub
        End If
        Try
            If dr.Read Then
                Fill_Labels()
                clear_boxes()
                Get_Variants(ItemNo.Text.Trim, BarcodeBox.Text.Trim, UOM.Text.Trim, VarCode.Text.Trim)
            ElseIf dr.Read = False And CheckBox1.Checked = False Then
                clear_labels()
                MessageBox("Barcode not found")
            ElseIf dr.Read = False And CheckBox1.Checked = True Then
                clear_labels()
            End If
            If CheckBox1.Checked = True Then
                Cursor.Current = Cursors.WaitCursor
                Dim Result As Boolean = BarcodeHasImage(Barcode)
                Cursor.Current = Cursors.Default
                If Result = True Then
                    Label2.Text = "Has Image"
                    Label2.ForeColor = Color.LightGreen
                Else
                    Label2.Text = "No Image"
                    Label2.ForeColor = Color.Red
                End If
                If Label2.Visible = False Then
                    Label2.Visible = True
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub Fill_Labels()
        clear_labels()

        Barcode = dr("Barcode No_").ToString
        Desc.Text = dr("Description").ToString
        UOM.Text = dr("Unit of measure code").ToString
        VarCode.Text = dr("Variant code").ToString
        ItemNo.Text = dr("Item No_").ToString
        ArabicDesc.Text = crAr.DisplayArabic(dr("Arabic Description").ToString)
        If CheckBox1.Checked = True Then
            Price.Text = ""
        Else
            Cursor.Current = Cursors.WaitCursor
            Dim TmpPrice As Decimal = CStr(GetRetailPrice(dr("Item No_").ToString, dr("Variant code").ToString, dr("Unit of measure code").ToString))
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
        End If
    End Sub
    Private Sub Get_Variants(ByVal No As String, ByVal Barcode As String, ByVal UOM As String, ByVal Var As String)
        ResetControls()
        db.read("Distinct [Unit of Measure Code]", "[" + CompanyName.Replace(".", "_") + "$Barcodes]", String.Format("[Item No_] = '{0}' and [Barcode No_] <> '{1}' and [Unit of Measure Code] <> '{2}' and [Variant Code] = '{3}'", No, Barcode, UOM, Var))
        Try
            While dr.Read
                ListBox1.Items.Add(dr.GetValue(0).ToString)
            End While

            If ListBox1.Items.Count > 0 Then
                UnHideControls()
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub clear_boxes()
        BarcodeBox.Text = ""
        BarcodeBox.Focus()
    End Sub
    Private Sub clear_labels()
        Desc.Text = String.Empty
        ArabicDesc.Text = String.Empty
        UOM.Text = String.Empty
        VarCode.Text = String.Empty
        Price.Text = String.Empty
        Price.ForeColor = Color.Blue
        ItemNo.Text = String.Empty
        Label2.Text = ""
    End Sub
    Private Sub ResetControls()
        UOMs.Visible = False
        Button1.Visible = False
        Button1.Text = "Show"
        ListBox1.Visible = False
        ListBox1.Items.Clear()
    End Sub
    Private Sub UnHideControls()
        UOMs.Visible = True
        Button1.Visible = True
    End Sub
    Private Sub Back_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Barcode211.EnableScanner = False
        clear_boxes()
        clear_labels()
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Show_UOMs()
    End Sub
    Private Sub ListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged
        If Arrows = False Then
            Alter_UOM()
        End If
    End Sub
    Private Sub Show_UOMs()
        If Button1.Text = "Show" And ListBox1.Visible = False Then
            ListBox1.Visible = True
            Button1.Text = "Hide"
            ListBox1.Focus()
            Application.DoEvents()
        ElseIf Button1.Text = "Hide" And ListBox1.Visible = True Then
            ListBox1.Visible = False
            Button1.Text = "Show"
            Arrows = False
        End If
    End Sub
    Private Sub Alter_UOM()
        Try
            Dim UOM As String = ListBox1.SelectedItem.ToString
            Dim Barcode As String = Get_Barcode(UOM, ItemNo.Text.Trim)
            BarcodeBox.Text = Barcode
            Read_Data()
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
    Private Sub ListBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
        Try
            If Arrows = True And e.KeyValue = 13 Then
                Arrows = False
                Alter_UOM()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BarcodeBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BarcodeBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub BarcodeBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarcodeBox.KeyUp
        If BarcodeBox.Text.Trim <> String.Empty Then
            If e.KeyValue = 13 Then
                Read_Data()
            End If
        End If
    End Sub
    Private Sub PriceCheck_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyValue = 38 Or e.KeyValue = 40) And Button1.Visible = True And Button1.Text = "Show" Then
                Arrows = True
                Show_UOMs()
                If e.KeyValue = 38 Then
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
                ElseIf e.KeyValue = 40 Then
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                End If
            ElseIf e.KeyValue = 125 Then
                Barcode211.EnableScanner = False
                ResetControls()
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked = False Then
            Label2.Text = ""
            Label2.Visible = False
        End If
    End Sub
End Class