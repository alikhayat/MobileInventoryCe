Imports System.IO
Imports System.Reflection

Public Class PromptBrand
    Dim SessionID As String
    Public Sub New(ByVal _SessionID As String)
        InitializeComponent()
        SessionID = _SessionID
    End Sub
    Private Sub PromptBrand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InializeTimer()
        Try
            PictureBox1.Image = New Bitmap(Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase) + "\Logo's\S01.png")
            PictureBox2.Image = New Bitmap(Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase) + "\Logo's\S02.png")
            PictureBox1.Refresh()
            PictureBox2.Refresh()
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        db.Update("[Session Header]", "[Company] = 2", String.Format("[ID] = '{0}'", SessionID))
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        db.Update("[Session Header]", "[Company] = 1", String.Format("[ID] = '{0}'", SessionID))
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub PromptBrand_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ThreadTimer.Dispose()
    End Sub
End Class