Imports Symbol.Barcode2

Public Class TransferIn
    Shadows Validated As Boolean = False
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub TransferIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Cursor.Current = Cursors.Default
        Tittle.Text = "Store To: " + Store
        Barcode100.EnableScanner = True
    End Sub
    Private Function Validate() As Boolean
        Dim Fetched As Boolean = False
        Dim OrderInfo As String = ""
        If OrderNo.Text <> String.Empty Then
            OrderInfo = Get_TransferInDetails(OrderNo.Text.Trim)
            If OrderInfo.Substring(0, 1) = "0" Then
                OrderInfo = OrderInfo.Remove(0, 2)

                StoreFrom.Text = OrderInfo.Substring(0, OrderInfo.IndexOf(","))
                OrderInfo = OrderInfo.Remove(0, OrderInfo.IndexOf(",") + 1)

                FromName.Text = OrderInfo.Substring(0, OrderInfo.IndexOf(","))
                OrderInfo = OrderInfo.Remove(0, OrderInfo.IndexOf(",") + 1)

                ShippedDate.Text = OrderInfo.Substring(0, OrderInfo.IndexOf(","))
                OrderInfo = OrderInfo.Remove(0, OrderInfo.IndexOf(",") + 1)

                ItemCount.Text = OrderInfo

                Clear.Enabled = True
                OrderNo.Enabled = False
                Fetched = True
            ElseIf OrderInfo.Substring(0, 1) = "1" Then
                MessageBox(OrderInfo.Substring(2))
                Clear_Form()
            End If
        End If

        Return Fetched
    End Function
    Private Sub ConfirmOrder()
        Dim Confirmed As Boolean = ConfirmTransIN(OrderNo.Text.Trim, CheckBox1.CheckState)
        If Confirmed Then
            MessageBox("Transfer Arrival Confirmed")
            Clear_Form()
        Else
            MessageBox("Error Confirming Transfer Arrival")
        End If
    End Sub
    Private Sub Clear_Form()
        OrderNo.Text = ""
        StoreFrom.Text = ""
        FromName.Text = ""
        ShippedDate.Text = ""
        ItemCount.Text = ""
        CheckBox1.Checked = False
        OrderNo.Enabled = True

        Clear.Enabled = False
    End Sub
    Private Sub TransferIn_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Barcode100.EnableScanner = False
        ThreadTimer.Dispose()
    End Sub

    Private Sub Barcode21_OnScan(ByVal scanDataCollection As Symbol.Barcode2.ScanDataCollection) Handles Barcode100.OnScan
        Try
            Dim Barcode As String = ""
            For Each D As ScanData In scanDataCollection
                Barcode = D.Text
            Next

            If Barcode <> String.Empty Then
                If Validated Then
                    Clear_Form()
                End If
                Barcode = Barcode.Replace("*", "")
                OrderNo.Text = Barcode
                Cursor.Current = Cursors.WaitCursor
                Validated = Validate()
                Cursor.Current = Cursors.Default
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If OrderNo.Text.Trim <> String.Empty And Validated = True Then
            Cursor.Current = Cursors.WaitCursor
            ConfirmOrder()
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Sub OrderNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OrderNo.KeyDown
        If e.KeyValue = 13 Then
            If OrderNo.Text.Trim <> String.Empty Then
                Cursor.Current = Cursors.WaitCursor
                Validated = Validate()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.Close()
    End Sub

    Private Sub Clear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click
        Clear_Form()
    End Sub

    Private Sub TransferIn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyValue = 125 Then
                If Clear.Enabled = True Then
                    Clear_Form()
                Else
                    Clear_Form()

                    Me.Close()
                End If
            ElseIf e.KeyValue = 13 Then
                If OrderNo.Text.Trim <> String.Empty And Validated = True Then
                    Cursor.Current = Cursors.WaitCursor
                    ConfirmOrder()
                    Cursor.Current = Cursors.Default
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class