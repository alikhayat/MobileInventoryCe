<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PricingJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PricingJob))
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.MobileAssign = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(271, 237)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 25)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(15, 237)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.Location = New System.Drawing.Point(15, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.SelectionBackColor = System.Drawing.SystemColors.Desktop
        Me.DataGrid1.Size = New System.Drawing.Size(290, 192)
        Me.DataGrid1.TabIndex = 7
        '
        'MobileAssign
        '
        Me.MobileAssign.Image = CType(resources.GetObject("MobileAssign.Image"), System.Drawing.Image)
        Me.MobileAssign.Location = New System.Drawing.Point(218, 237)
        Me.MobileAssign.Name = "MobileAssign"
        Me.MobileAssign.Size = New System.Drawing.Size(34, 25)
        Me.MobileAssign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        '
        'PricingJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MobileAssign)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PricingJob"
        Me.Text = "PricingJob"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents MobileAssign As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
