Public Class Counters
    Private DoNotOverwrite As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Counters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GenerateControls()
        DoNotOverwrite = False
    End Sub
    Private Sub GenerateControls()
        db.read("*", "[Counter]", "")
        Dim y As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim LabelLoc As Point
        Dim TextboxLoc1 As Point
        Dim TextboxLoc2 As Point

        While dr.Read
            y += 35
            LabelLoc = New Point(20, y)
            TextboxLoc1 = New Point(140, y)
            TextboxLoc2 = New Point(220, y)
            Dim Labels As New Windows.Forms.Label
            Dim textboxes1 As New Windows.Forms.TextBox
            Dim textboxes2 As New Windows.Forms.TextBox
            textboxes1.Size = New Size(40, 10)
            textboxes2.Size = New Size(60, 10)
            Labels.Font = New Font("tahoma", 10, FontStyle.Bold)


            Labels.Text = dr.GetValue(0)
            Labels.Location = LabelLoc
            Labels.Tag = "Sessions"
            Me.Controls.Add(Labels)

            textboxes1.Text = dr.GetValue(1)
            textboxes1.Location = TextboxLoc1
            textboxes1.Tag = dr.GetValue(0) + "-Prefix"
            Me.Controls.Add(textboxes1)

            textboxes2.Text = dr.GetValue(2)
            textboxes2.Location = TextboxLoc2
            textboxes2.Tag = dr.GetValue(0) + "-Value"
            Me.Controls.Add(textboxes2)
        End While
    End Sub

    Private Sub Counters_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Name As String = ""
        Dim Tg As String = ""
        Try
            If Not DoNotOverwrite Then
                For Each l As Control In Me.Controls
                    If l.Tag <> String.Empty Then
                        Tg = l.Tag
                    End If
                    If Tg.Contains("Prefix") And l.Text <> String.Empty Then
                        Name = Tg.Substring(0, Tg.LastIndexOf("-"))
                        db.Update("[Counter]", String.Format("[Prefix] = '{0}'", l.Text), String.Format("[Name] = '{0}'", Name))
                    End If
                    If Tg.Contains("Value") And l.Text <> String.Empty Then
                        Name = Tg.Substring(0, Tg.LastIndexOf("-"))
                        db.Update("[Counter]", String.Format("[lastValue] = '{0}'", l.Text), String.Format("[Name] = '{0}'", Name))
                    End If
                Next
            End If
        Catch ex As Exception
        Finally
            If Not DoNotOverwrite Then
                DBClose(True)
            End If
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Debug_New_Database()
        DoNotOverwrite = True
    End Sub
End Class