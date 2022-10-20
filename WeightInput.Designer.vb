<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class WeightInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WeightInput))
        Me.TotalWeight = New System.Windows.Forms.TextBox
        Me.PackWeight = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.KGRadio = New System.Windows.Forms.RadioButton
        Me.GramRadio = New System.Windows.Forms.RadioButton
        Me.NetWeight = New System.Windows.Forms.TextBox
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.Desc = New System.Windows.Forms.Label
        Me.Multiple = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TotalWeight
        '
        Me.TotalWeight.Location = New System.Drawing.Point(207, 80)
        Me.TotalWeight.Name = "TotalWeight"
        Me.TotalWeight.Size = New System.Drawing.Size(100, 23)
        Me.TotalWeight.TabIndex = 0
        '
        'PackWeight
        '
        Me.PackWeight.Location = New System.Drawing.Point(207, 120)
        Me.PackWeight.Name = "PackWeight"
        Me.PackWeight.Size = New System.Drawing.Size(100, 23)
        Me.PackWeight.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(15, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 20)
        Me.Label1.Text = "Total Weight"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 20)
        Me.Label2.Text = "Package Weight:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(15, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.Text = "Net Weight:"
        '
        'KGRadio
        '
        Me.KGRadio.Checked = True
        Me.KGRadio.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.KGRadio.Location = New System.Drawing.Point(109, 38)
        Me.KGRadio.Name = "KGRadio"
        Me.KGRadio.Size = New System.Drawing.Size(60, 20)
        Me.KGRadio.TabIndex = 8
        Me.KGRadio.Text = "KG"
        '
        'GramRadio
        '
        Me.GramRadio.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GramRadio.Location = New System.Drawing.Point(175, 38)
        Me.GramRadio.Name = "GramRadio"
        Me.GramRadio.Size = New System.Drawing.Size(100, 20)
        Me.GramRadio.TabIndex = 9
        Me.GramRadio.TabStop = False
        Me.GramRadio.Text = "Gram"
        '
        'NetWeight
        '
        Me.NetWeight.Enabled = False
        Me.NetWeight.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.NetWeight.Location = New System.Drawing.Point(207, 156)
        Me.NetWeight.Name = "NetWeight"
        Me.NetWeight.Size = New System.Drawing.Size(100, 26)
        Me.NetWeight.TabIndex = 3
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(273, 230)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 25)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(15, 230)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Desc
        '
        Me.Desc.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Desc.Location = New System.Drawing.Point(15, 9)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(292, 26)
        Me.Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Multiple
        '
        Me.Multiple.Location = New System.Drawing.Point(207, 194)
        Me.Multiple.Name = "Multiple"
        Me.Multiple.Size = New System.Drawing.Size(100, 23)
        Me.Multiple.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(15, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.Text = "Multiply By:"
        '
        'WeightInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Multiple)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.GramRadio)
        Me.Controls.Add(Me.KGRadio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NetWeight)
        Me.Controls.Add(Me.PackWeight)
        Me.Controls.Add(Me.TotalWeight)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WeightInput"
        Me.Text = "KGInput"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents PackWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents KGRadio As System.Windows.Forms.RadioButton
    Friend WithEvents GramRadio As System.Windows.Forms.RadioButton
    Friend WithEvents NetWeight As System.Windows.Forms.TextBox
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents Desc As System.Windows.Forms.Label
    Friend WithEvents Multiple As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
