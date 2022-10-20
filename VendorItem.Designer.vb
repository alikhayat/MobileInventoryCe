<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class VendorItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorItem))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.Search = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Desc = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular)
        Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.Location = New System.Drawing.Point(12, 38)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(288, 161)
        Me.DataGrid1.TabIndex = 3
        Me.DataGrid1.TableStyles.Add(Me.DataGridTableStyle1)
        Me.DataGrid1.TabStop = False
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(266, 243)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 23)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(12, 243)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(12, 9)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(159, 23)
        Me.Search.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CheckBox1.Location = New System.Drawing.Point(177, 9)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(123, 20)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Vendor Items"
        Me.CheckBox1.Visible = False
        '
        'Desc
        '
        Me.Desc.Location = New System.Drawing.Point(12, 202)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(288, 38)
        '
        'VendorItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.DataGrid1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VendorItem"
        Me.Text = "VendorItem"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents Search As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Desc As System.Windows.Forms.Label
End Class
