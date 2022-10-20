<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.user = New System.Windows.Forms.Label
        Me.Passs = New System.Windows.Forms.Label
        Me.Passbox = New System.Windows.Forms.TextBox
        Me.LoginBtn = New System.Windows.Forms.Button
        Me.popup = New System.Windows.Forms.Label
        Me.SyncButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.UserBox = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(227, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'user
        '
        Me.user.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.user.Location = New System.Drawing.Point(26, 92)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(100, 20)
        Me.user.Text = " Username :"
        '
        'Passs
        '
        Me.Passs.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Passs.Location = New System.Drawing.Point(26, 144)
        Me.Passs.Name = "Passs"
        Me.Passs.Size = New System.Drawing.Size(100, 20)
        Me.Passs.Text = " Password :"
        '
        'Passbox
        '
        Me.Passbox.Location = New System.Drawing.Point(132, 141)
        Me.Passbox.Name = "Passbox"
        Me.Passbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Passbox.Size = New System.Drawing.Size(155, 23)
        Me.Passbox.TabIndex = 1
        '
        'LoginBtn
        '
        Me.LoginBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LoginBtn.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LoginBtn.Location = New System.Drawing.Point(188, 202)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(72, 24)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "Login"
        '
        'popup
        '
        Me.popup.ForeColor = System.Drawing.Color.Red
        Me.popup.Location = New System.Drawing.Point(26, 167)
        Me.popup.Name = "popup"
        Me.popup.Size = New System.Drawing.Size(206, 20)
        Me.popup.Text = "Wrong username or password"
        Me.popup.Visible = False
        '
        'SyncButton
        '
        Me.SyncButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SyncButton.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SyncButton.Location = New System.Drawing.Point(54, 202)
        Me.SyncButton.Name = "SyncButton"
        Me.SyncButton.Size = New System.Drawing.Size(72, 24)
        Me.SyncButton.TabIndex = 3
        Me.SyncButton.Text = "Sync now"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(151, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 20)
        Me.Label1.Text = " - "
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 20)
        Me.Label2.Text = "Label2"
        '
        'UserBox
        '
        Me.UserBox.Location = New System.Drawing.Point(132, 92)
        Me.UserBox.Name = "UserBox"
        Me.UserBox.Size = New System.Drawing.Size(155, 23)
        Me.UserBox.TabIndex = 0
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.UserBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SyncButton)
        Me.Controls.Add(Me.popup)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.Passbox)
        Me.Controls.Add(Me.Passs)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.PictureBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents user As System.Windows.Forms.Label
    Friend WithEvents Passs As System.Windows.Forms.Label
    Friend WithEvents Passbox As System.Windows.Forms.TextBox
    Friend WithEvents LoginBtn As System.Windows.Forms.Button
    Friend WithEvents popup As System.Windows.Forms.Label
    Friend WithEvents SyncButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UserBox As System.Windows.Forms.ComboBox
End Class
