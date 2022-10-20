Imports Symbol.WPAN.Bluetooth
Public Class Labeling
    Dim types(1) As String
    Dim Code(1) As String
    Dim Exp(1) As Boolean
    Dim MobilePrint(1) As Boolean
    Dim InitialRun As Boolean = True
    Private LabelSessions As LabelSessions
    Private bt As Bluetooth
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub ItemLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        'Add the global Statusbar
        If InitialRun = True Then
            Dim Comp = New Component1
            Controls.Add(Comp.StatusBar1)
            InitialRun = False
        End If

        Generate_Buttons()
    End Sub
    Private Sub Back_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        Me.Close()
    End Sub
    Private Sub Generate_Buttons()
        Cursor.Current = Cursors.WaitCursor

        Get_Functions()

        Dim Text As String
        Dim TabIndex As Integer = 0
        Dim y As Integer = 10

        For i As Int16 = 0 To types.Length - 2
            Dim DynButton As Button = New Button
            Dim loc As Point = New Point(69, y)
            y += 51

            'Get the button text
            Text = Code(i) + " Label"

            Dim Name As String = Text.Replace(" ", "") + "Btn"
            DynButton.Text = Text
            'Set other button properties
            'Set button tag as label Type and the Exp property
            DynButton.Tag = CStr(types(i)) + " " + Code(i) + " " + CStr(Exp(i))
            DynButton.Name = Text + "Btn"
            DynButton.TabIndex = TabIndex
            TabIndex += 1
            DynButton.Width = 174
            DynButton.Height = 34
            DynButton.Location = loc
            DynButton.Font = New Font("tahoma", 10, FontStyle.Bold)

            If Check_Permissions(CStr(types(i)), Code(i)) = True Then
                DynButton.Enabled = True
                DynButton.BackColor = Color.White
            Else
                DynButton.Enabled = False
                DynButton.BackColor = Color.DimGray
            End If

            AddHandler DynButton.Click, AddressOf DynamicButton_Click
            Me.Controls.Add(DynButton)
        Next
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub Get_Functions()
        db.read("*", "[" + CompanyName.Replace(".", "_") + "$Label Functions]", "")
        Try
            Dim index As Integer = -1
            While dr.Read
                index += 1

                'Fill Types array
                types(index) = CStr(dr.GetValue(0))
                ReDim Preserve types(index + 1)

                'Fill Codes array
                Code(index) = CStr(dr.GetValue(1))
                ReDim Preserve Code(index + 1)

                'Fill Exp array
                Exp(index) = CStr(dr.GetValue(2))
                ReDim Preserve Exp(index + 1)

                'FIll Mobile print
                MobilePrint(index) = dr.GetValue(4)
                ReDim Preserve MobilePrint(index + 1)

            End While
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub

    Private Sub DynamicButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpToDate()
        Dyna_Click(sender)
    End Sub

    Private Sub Labeling_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Dim ctrl As Control
            ctrl = sender
            If e.KeyValue = 13 Or e.KeyValue = 126 Then
                Dim c As Control = ActiveControl
                Dyna_Click(c)
            ElseIf e.KeyValue = 125 Then
                Me.Close()
            ElseIf e.KeyValue = 38 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), False, True, False, True)
            ElseIf e.KeyValue = 40 Then
                ctrl.SelectNextControl(FindFocusedControl(ctrl), True, True, False, True)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Dyna_Click(ByVal Sender As System.Object)
        'Fetch the clicked button
        'Get the tag field that contains our keys
        'Seperate the keys
        Cursor.Current = Cursors.WaitCursor

        ThreadTimer.Dispose()
        Dim SelectedBtn As Button = Sender
        Dim Tag As String = SelectedBtn.Tag
        Dim Index As Integer = SelectedBtn.TabIndex
        Try
            If MobilePrint(Index) = False Then
                LabelSessions = New LabelSessions(types(Index), Tag.Split(" ")(1), Tag.Split(" ")(2))
                LabelSessions.ShowDialog()
                LabelSessions.Dispose()
            Else
                Dim PrintDialog As New PrintDialog(types(Index), Code(Index), Exp(Index), True)
                PrintDialog.ShowDialog()
                PrintDialog.Dispose()
            End If
            InializeTimer()
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Function Check_Permissions(ByVal Func As String, ByVal Code As String) As Boolean
        If Func = "0" Then
            If Login.Permissions(1) = "1" Then
                If Login.Permissions(2).Contains(Code) Then
                    Return True
                End If
            Else
                Return False
            End If
        ElseIf Func = "1" Then
            If Login.Permissions(3) = "1" Then
                If Login.Permissions(4).Contains(Code) Then
                    Return True
                End If
            Else
                Return False
            End If
        End If
    End Function

    Private Sub Labeling_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class