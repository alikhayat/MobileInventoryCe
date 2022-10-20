<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class NewItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewItem))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Desc = New System.Windows.Forms.TextBox
        Me.QtyBaseComp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.BaseUOM = New System.Windows.Forms.ComboBox
        Me.CompUOM = New System.Windows.Forms.ComboBox
        Me.V = New System.Windows.Forms.ComboBox
        Me.BarcodeLbl = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PurchUnit = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 20)
        Me.Label2.Text = "Description:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(182, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 20)
        Me.Label4.Text = "Size. Unit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Desc
        '
        Me.Desc.Location = New System.Drawing.Point(20, 61)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(262, 23)
        Me.Desc.TabIndex = 0
        '
        'QtyBaseComp
        '
        Me.QtyBaseComp.Location = New System.Drawing.Point(20, 122)
        Me.QtyBaseComp.Name = "QtyBaseComp"
        Me.QtyBaseComp.Size = New System.Drawing.Size(100, 23)
        Me.QtyBaseComp.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.Text = "Size"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(248, 222)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 25)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(20, 222)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BaseUOM
        '
        Me.BaseUOM.Location = New System.Drawing.Point(20, 187)
        Me.BaseUOM.Name = "BaseUOM"
        Me.BaseUOM.Size = New System.Drawing.Size(100, 23)
        Me.BaseUOM.TabIndex = 3
        '
        'CompUOM
        '
        Me.CompUOM.Location = New System.Drawing.Point(182, 122)
        Me.CompUOM.Name = "CompUOM"
        Me.CompUOM.Size = New System.Drawing.Size(100, 23)
        Me.CompUOM.TabIndex = 2
        '
        'V
        '
        Me.V.Location = New System.Drawing.Point(182, 190)
        Me.V.Name = "V"
        Me.V.Size = New System.Drawing.Size(100, 23)
        Me.V.TabIndex = 5
        Me.V.Visible = False
        '
        'BarcodeLbl
        '
        Me.BarcodeLbl.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.BarcodeLbl.Location = New System.Drawing.Point(13, 8)
        Me.BarcodeLbl.Name = "BarcodeLbl"
        Me.BarcodeLbl.Size = New System.Drawing.Size(271, 20)
        Me.BarcodeLbl.Text = "Bcode"
        Me.BarcodeLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(171, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.Text = "Pack Qty"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(20, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.Text = "Base Unit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PurchUnit
        '
        Me.PurchUnit.Location = New System.Drawing.Point(182, 187)
        Me.PurchUnit.Name = "PurchUnit"
        Me.PurchUnit.Size = New System.Drawing.Size(100, 23)
        Me.PurchUnit.TabIndex = 4
        '
        'NewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.PurchUnit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BarcodeLbl)
        Me.Controls.Add(Me.V)
        Me.Controls.Add(Me.CompUOM)
        Me.Controls.Add(Me.BaseUOM)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.QtyBaseComp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewItem"
        Me.Text = "NewItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Desc As System.Windows.Forms.TextBox
    Friend WithEvents QtyBaseComp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents BaseUOM As System.Windows.Forms.ComboBox
    Friend WithEvents CompUOM As System.Windows.Forms.ComboBox
    Friend WithEvents V As System.Windows.Forms.ComboBox
    Friend WithEvents BarcodeLbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PurchUnit As System.Windows.Forms.TextBox
End Class
