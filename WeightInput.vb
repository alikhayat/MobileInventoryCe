Public Class WeightInput
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub WeightInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
    End Sub
    Private Sub Restrict_Alpha(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Convert.ToChar(8))
    End Sub
    Private Sub Restrict_Alpha2(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Convert.ToChar(8))
    End Sub
    Private Sub KGRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KGRadio.CheckedChanged
        If KGRadio.Checked = True And GramRadio.Checked = False Then
            Dim Dec As Decimal
            If TotalWeight.Text <> String.Empty Then
                Dec = CDec(TotalWeight.Text.Trim)
                Dec = Decimal.Divide(Dec, 1000)
                TotalWeight.Text = Dec.ToString
            End If
            If PackWeight.Text <> String.Empty Then
                Dec = CDec(PackWeight.Text.Trim)
                Dec = Decimal.Divide(Dec, 1000)
                PackWeight.Text = Dec.ToString
            End If

            If PackWeight.Text <> String.Empty And TotalWeight.Text <> String.Empty Then
                NetWeight.Text = Calculate_NetWeight()
            End If
        End If
    End Sub

    Private Sub GramRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GramRadio.CheckedChanged
        If KGRadio.Checked = False And GramRadio.Checked = True Then
            Dim Dec As Decimal
            If TotalWeight.Text <> String.Empty Then
                Dec = CDec(TotalWeight.Text.Trim)
                Dec = Decimal.Multiply(Dec, 1000)
                TotalWeight.Text = Dec.ToString
            End If
            If PackWeight.Text <> String.Empty Then
                Dec = CDec(PackWeight.Text.Trim)
                Dec = Decimal.Multiply(Dec, 1000)
                PackWeight.Text = Dec.ToString
            End If

            If PackWeight.Text <> String.Empty And TotalWeight.Text <> String.Empty Then
                NetWeight.Text = Calculate_NetWeight()
            End If
        End If
    End Sub
    Private Function Calculate_NetWeight() As String
        Dim Net As Decimal = 0
        If PackWeight.Text.Trim = String.Empty Then
            Net = CDec(TotalWeight.Text.Trim) - 0
        Else
            Net = CDec(TotalWeight.Text.Trim) - CDec(PackWeight.Text.Trim)
        End If

        Return CStr(Net)
    End Function
    Private Sub WeightInput_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = 125 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel

            Me.Close()
        ElseIf e.KeyValue = 13 Then
            If Multiple.Focused Then
                Try
                    If PackWeight.Text.Trim = String.Empty Then
                        PackWeight.Text = "0"
                    End If
                    If Multiple.Text.Trim = String.Empty Or Multiple.Text.Trim = "0" Then
                        Multiple.Text = "1"
                    End If
                    If TotalWeight.Text.Trim <> String.Empty Then
                        NetWeight.Text = Cultural(Calculate_NetWeight(), True)
                        If Not (CDec(TotalWeight.Text.Trim) < CDec(PackWeight.Text.Trim)) Then
                            If CDec(NetWeight.Text.Trim) > 0.0 Then
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                            Else
                                MessageBox("Net weight can't be zero")
                            End If
                        Else
                            MessageBox("Total weight can't be less than package weight")
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub PackWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PackWeight.KeyUp
        If e.KeyValue = 13 Then
            Multiple.Focus()
        End If
        NetWeight.Text = Cultural(Calculate_NetWeight(), True)
    End Sub
    Private Sub PackWeight_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackWeight.LostFocus
        If PackWeight.Text.Trim = String.Empty Then
            PackWeight.Text = "0"
        Else
            PackWeight.Text = Cultural(PackWeight.Text, True)
        End If
    End Sub

    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub TotalWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TotalWeight.KeyPress
        Restrict_Alpha(e)
    End Sub

    Private Sub PackWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PackWeight.KeyPress
        Restrict_Alpha(e)
    End Sub

    Private Sub TotalWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalWeight.TextChanged
        If TotalWeight.Text <> String.Empty Then
            Try
                NetWeight.Text = Cultural(Calculate_NetWeight(), True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PackWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackWeight.TextChanged
        If TotalWeight.Text <> String.Empty And PackWeight.Text <> String.Empty Then
            Try
                NetWeight.Text = Cultural(Calculate_NetWeight(), True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TotalWeight_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalWeight.LostFocus
        If TotalWeight.Text.Trim <> String.Empty Then
            TotalWeight.Text = Cultural(TotalWeight.Text, True)
        End If
    End Sub
    Private Sub TotalWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TotalWeight.KeyUp
        If TotalWeight.Text <> String.Empty And e.KeyValue = 13 Then
            PackWeight.Focus()
        End If
    End Sub
    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Try
            If PackWeight.Text.Trim = String.Empty Then
                PackWeight.Text = "0"
            End If
            If Multiple.Text.Trim = String.Empty Or Multiple.Text.Trim = "0" Then
                Multiple.Text = "1"
            End If
            If TotalWeight.Text.Trim <> String.Empty Then
                NetWeight.Text = Cultural(Calculate_NetWeight(), True)
                If Not (CDec(TotalWeight.Text.Trim) < CDec(PackWeight.Text.Trim)) Then
                    If CDec(NetWeight.Text.Trim) > 0.0 Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        MessageBox("Net weight can't be zero")
                    End If
                Else
                    MessageBox("Total weight can't be less than package weight")
                End If
            End If
        Catch ex As Exception

        End Try      
    End Sub
    Private Sub Multiple_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Restrict_Alpha2(e)
    End Sub

    Private Sub WeightInput_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class