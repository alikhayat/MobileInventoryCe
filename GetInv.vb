
Public Class GetInv
    Private RecTra As Rectra
    Private Shadows validated As Boolean = False
    Private SessionID As String
    Private Type As String
    Private Code As String
    Private i As Integer = 0
    Public Sub New(ByVal _SessionID As String, ByVal _Type As String, ByVal _Code As String)
        InitializeComponent()
        SessionID = _SessionID
        Type = _Type
        Code = _Code
    End Sub
    Private Sub GetInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        If Type = "2" And Code = "3" Then
            Label2.Visible = True
            ReferenceNo.Visible = True
            Label1.Visible = True
            ComboBox1.Visible = True
            Label3.Visible = True
            InvoiceNo.Visible = True
        ElseIf Type = "3" And Code = "5" Then
            FromLoc.Visible = True
            ToLoc.Visible = True
            ComboBox2.Visible = True
            ComboBox3.Visible = True
            Label4.Visible = True
            DateTimePicker1.Visible = True
            DateTimePicker1.Value = DateTime.Now.ToShortDateString
            TransOutHandle()
        End If
    End Sub
    Private Sub Search_ReferenceNo(ByVal ReferenceNo_ As String)

        db.read("[Name]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[No_] = '{0}'", ReferenceNo_))

        Try
            If dr.Read Then
                ComboBox1.Items.Clear()
                ComboBox1.Items.Add(dr.GetValue(0))
                ComboBox1.SelectedIndex = 0
            Else
                ReferenceNo.Text = String.Empty
                ComboBox1.Items.Clear()
            End If
        Catch ex As Exception
        Finally

            DBClose(False)
        End Try
    End Sub
    Private Sub Get_AllNames()
        db.read("[Name]", "[" + CompanyName.Replace(".", "_") + "$Vendor] Order By Name", "")

        ComboBox1.Items.Clear()
        Try
            Do While dr.Read
                ComboBox1.Items.Add(dr.GetValue(0))
            Loop
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub

    Private Sub Search_VendorName(ByVal Text As String)
        Dim i As Integer = 0

        db.read("Count([Name])", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] like '%{0}%'", Text))
        Try
            If dr.Read Then
                i = CInt(dr.GetValue(0))
                If i = 0 Then
                    ReferenceNo.Text = String.Empty
                ElseIf i = 1 Then
                    DBClose(False)
                    db.read("[No_],[Name]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] like '%{0}%' ORDER BY Name", Text.Replace("'", "''")))
                    Try
                        If dr.Read Then
                            ComboBox1.Items.Clear()
                            ReferenceNo.Text = dr.GetValue(0)
                            ComboBox1.Items.Add(dr.GetValue(1))
                            ComboBox1.SelectedIndex = 0
                            validated = True
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    DBClose(False)
                    db.read("[Name]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] like '%{0}%' ORDER BY Name", Text.Replace("'", "''")))

                    ComboBox1.Items.Clear()
                    While dr.Read
                        ComboBox1.Items.Add(dr.GetValue(0))
                    End While
                    validated = False
                    'ComboBox1.SelectedIndex = 0
                    ComboBox1.Focus()
                End If
            Else

            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub
    Private Sub Get_ReferenceNo_()
        db.read("[No_]", "[" + CompanyName.Replace(".", "_") + "$Vendor]", String.Format("[Name] like '%{0}%' ORDER BY Name", ComboBox1.Text.Replace("'", "''")))
        Try
            If dr.Read Then
                ReferenceNo.Text = dr.GetValue(0)
                validated = True
            End If
        Catch ex As Exception
        Finally
            DBClose(False)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Try
            If ComboBox1.Text <> String.Empty And ComboBox1.Items.Count <> 0 Then
                Get_ReferenceNo_()
                validated = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Main_Search()
        Try
            If ReferenceNo.Text.Trim <> String.Empty Then
                If IsNumeric(ReferenceNo.Text.Trim) Then
                    Search_ReferenceNo(ReferenceNo.Text.Trim)
                    InvoiceNo.Focus()
                Else
                    Search_VendorName(ReferenceNo.Text.Trim.ToUpper)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetInv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = 125 Then
            Clear()
            Me.Close()
        ElseIf e.KeyValue = 126 Then
            Cursor.Current = Cursors.WaitCursor
            If Type = "2" And Code = "3" Then
                Validate()
            ElseIf Type = "3" And Code = "5" Then
                Dim ExpectedDate As Date = DateTimePicker1.Value
                Dim RecTra As New Rectra(SessionID, Type, Code, ComboBox2.Text, "", "", ExpectedDate)
                ThreadTimer.Dispose()
                RecTra.ShowDialog()
                RecTra.Dispose()
                Me.Close()
            End If
            Cursor.Current = Cursors.Default
            InializeTimer()
        End If
    End Sub

    Private Sub Validate()
        If validated And InvoiceNo.Text <> String.Empty Then
            If Validate_InvoiceNo(ReferenceNo.Text, InvoiceNo.Text) Then
                ThreadTimer.Dispose()
                Dim ExpDate As Date = DateTime.Now.ToShortDateString
                RecTra = New Rectra(SessionID, Type, Code, ReferenceNo.Text.Trim, ComboBox1.Text.Trim, InvoiceNo.Text.Trim, ExpDate)
                RecTra.ShowDialog()
                RecTra.Dispose()
                Me.Close()
            ElseIf Not validated And ReferenceNo.Text = String.Empty Then
                Cursor.Current = Cursors.Default
                MsgBox("Select a vendor No. first")
            ElseIf Not validated And ReferenceNo.Text <> String.Empty Then
                Cursor.Current = Cursors.Default
                Main_Search()
            Else
                Cursor.Current = Cursors.Default
                MessageBox(String.Format("Duplicate Invoice {0} found for Vendor {1}", InvoiceNo.Text, ReferenceNo.Text))
            End If
        Else
            MessageBox("Fill Invoice no to proceed")
        End If
    End Sub
    Private Function Validate_InvoiceNo(ByVal VendorNo As String, ByVal InvoiceNo As String) As Boolean
        db.read("COUNT(*)", "[P/R Header]", String.Format("[Vendor No. / Customer No.] = '{0}' and [Vendor Invoice No.] = '{1}'", VendorNo, InvoiceNo))
        Try
            If dr.Read Then
                If CInt(dr.GetValue(0)) > 0 Then
                    Return False
                ElseIf CInt(dr.GetValue(0)) = 0 Then
                    Return True
                End If
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Function
    Private Sub TransOutHandle()
        Fill_ToLocation()

        ComboBox3.Items.Add(Store)
        ComboBox3.SelectedIndex = 0

        'If ComboBox2.Items.Count = 1 Then
        '    Dim RecTra As New Rectra(SessionID, Type, Code, ComboBox2.Text, "", "")
        '    ThreadTimer.Dispose()
        '    RecTra.ShowDialog()
        '    RecTra.Dispose()
        '    Me.Close()
        'End If
    End Sub
    Private Sub Fill_ToLocation()
        db.read("[Code]", "[" + CompanyName.Replace(".", "_") + "$Location]", String.Format("[Transfer Out Allowed] = 1"))

        While dr.Read
            ComboBox2.Items.Add(dr.GetValue(0))
        End While

        DBClose(True)
    End Sub
    Private Sub InvoiceNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles InvoiceNo.KeyDown
        Try
            If e.KeyValue = 13 Then
                Validate()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub VendorNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferenceNo.TextChanged
        Try
            validated = False
            If ReferenceNo.Text.Length = 0 Then
                ComboBox1.Items.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub VendorNo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ReferenceNo.KeyUp
        Try
            If e.KeyValue = 13 Then
                Main_Search()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComboBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        Try
            If ReferenceNo.Text.Trim = String.Empty And ComboBox1.Items.Count = 0 Then
                Get_AllNames()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        If Type = "2" And Code = "3" Then
            Validate()
        ElseIf Type = "3" And Code = "5" Then
            Dim ExpectedDate As Date = DateTimePicker1.Value
            Dim RecTra As New Rectra(SessionID, Type, Code, ComboBox2.Text, "", "", ExpectedDate)
            ThreadTimer.Dispose()
            RecTra.ShowDialog()
            RecTra.Dispose()
            Me.Close()
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Clear()
        ReferenceNo.Text = String.Empty
        InvoiceNo.Text = String.Empty
        ComboBox1.Items.Clear()
    End Sub

    Private Sub GetInv_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class