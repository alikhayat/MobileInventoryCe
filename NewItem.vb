Public Class NewItem
    Private Bcode As String
    Public Sub New(ByVal _Bcode As String)
        InitializeComponent()
        Bcode = _Bcode
    End Sub
    
    Private Sub NewItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        BarcodeLbl.Text = "Barcode: " + Bcode

        BaseUOM.Items.Clear()
        CompUOM.Items.Clear()
        Fill_CompUOMBox()
        Fill_BasePurchUOMBoxes()
        'BaseUOM.SelectedItem = "EACH"
    End Sub
    Private Sub Fill_BasePurchUOMBoxes()
        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Unit Of Measure]", "([Code] like '%EACH%' or [Code] like 'KG' OR [Code] like '%Assortd%' or [Code] like '%OFF%' or [Code] like 'VP%' or [Code] like 'PK%') and ([Code] NOT like '%X%') ORDER BY [Default Qty Per] ASC")
        Try
            While dr.Read
                BaseUOM.Items.Add(dr.GetValue(0))
                'PurchUOM.Items.Add(dr.GetValue(0))
            End While

        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub

    Private Sub Fill_CompUOMBox()
        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Comparison Unit of Measure]", "")
        Try
            While dr.Read
                CompUOM.Items.Add(dr.GetValue(0))
            End While

        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        If PurchUnit.Text.Trim <> String.Empty And PurchUnit.Text.Trim <> "0" And BaseUOM.SelectedIndex <> -1 And Desc.Text.Trim <> String.Empty Then
            If QtyBaseComp.Text <> String.Empty And CompUOM.SelectedIndex = -1 Then
                MessageBox("Please choose Size Unit")
                Return
            End If
            Desc.Text = Desc.Text.ToUpper

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox("Invalid input Fill Base Unit of Measure and Quantity base comparison unit can't be empty ")
        End If
    End Sub
    Private Sub QtyBaseComp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles QtyBaseComp.KeyPress
        Restrict_Alpha(e)
    End Sub

    Private Sub BaseUOM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseUOM.TextChanged
        'If BaseUOM.Text <> String.Empty Then
        '    If BaseUOM.Text.Contains("Off") Or BaseUOM.Text = "EACH" Or BaseUOM.Text = "ASSORTD" Then
        '        Fill_PurchUOM("PK", "CS")
        '    ElseIf BaseUOM.Text.Contains("KG") Then
        '        Fill_PurchUOM("KG")
        '    ElseIf BaseUOM.Text.Contains("VP") Then
        '        Fill_PurchUOM(BaseUOM.Text)
        '    End If
        'End If
        'V.SelectedIndex = 0
    End Sub

    Private Sub NewItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyValue = 125 Then
                If Desc.Text.Trim <> String.Empty Then
                    Desc.Text = Desc.Text.ToUpper
                End If
                Me.DialogResult = Windows.Forms.DialogResult.Cancel

                Me.Close()
            ElseIf e.KeyValue = 13 Then
                Dim ctrl As Control
                ctrl = sender
                If PurchUnit.Focused Then
                    If PurchUnit.Text.Trim <> String.Empty And PurchUnit.Text.Trim <> "0" And BaseUOM.SelectedIndex <> -1 And Desc.Text.Trim <> String.Empty Then
                        If QtyBaseComp.Text <> String.Empty And CompUOM.SelectedIndex = -1 Then
                            MessageBox("Please choose Size Unit")
                            Return
                        End If
                        Desc.Text = Desc.Text.ToUpper

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        MessageBox("Invalid input Fill Base Unit of Measure and Quantity base comparison unit can't be empty ")
                    End If
                Else
                    ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
                End If               
            End If
        Catch ex As Exception

        End Try     
    End Sub
    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Restrict_Alpha(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Convert.ToChar(8))
    End Sub
    Private Sub Fill_PurchUOM(ByVal Filter1 As String, Optional ByVal Filter2 As String = "", Optional ByVal Filter3 As String = "")
        '    If Filter2 <> "" And Filter3 <> "" Then
        '        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Unit Of Measure]", String.Format("[Code] like '%{0}%' OR [Code] like '%{1}%' or [Code] like '%{2}%'", Filter1, Filter2, Filter3))
        '    ElseIf Filter2 <> "" Then
        '        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Unit Of Measure]", String.Format("[Code] like '%{0}%' OR [Code] like '%{1}%'", Filter1, Filter2))
        '    Else
        '        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Unit Of Measure]", String.Format("[Code] like '%{0}%'", Filter1))
        '    End If
        '    V.Items.Clear()
        '    Try
        '        While dr.Read
        '            V.Items.Add(dr.GetValue(0))
        '        End While
        '    Catch ex As Exception
        '    Finally
        '        DBClose(False)
        '    End Try
    End Sub

    Private Sub NewItem_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub
End Class