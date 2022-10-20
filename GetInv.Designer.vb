<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class GetInv
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.InvoiceNo = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ReferenceNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.FromLoc = New System.Windows.Forms.Label
        Me.ToLoc = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(21, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.Text = "Vendor:"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(21, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.Text = "Invoice:"
        Me.Label3.Visible = False
        '
        'InvoiceNo
        '
        Me.InvoiceNo.Location = New System.Drawing.Point(93, 181)
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.Size = New System.Drawing.Size(191, 23)
        Me.InvoiceNo.TabIndex = 2
        Me.InvoiceNo.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DisplayMember = "Key"
        Me.ComboBox1.Location = New System.Drawing.Point(93, 114)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(191, 23)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.ValueMember = "Value"
        Me.ComboBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(212, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Submit"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(21, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 20)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        '
        'ReferenceNo
        '
        Me.ReferenceNo.Location = New System.Drawing.Point(93, 45)
        Me.ReferenceNo.Name = "ReferenceNo"
        Me.ReferenceNo.Size = New System.Drawing.Size(191, 23)
        Me.ReferenceNo.TabIndex = 0
        Me.ReferenceNo.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(21, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.Text = "Search:"
        Me.Label2.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(184, 111)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(100, 23)
        Me.ComboBox2.TabIndex = 7
        Me.ComboBox2.Visible = False
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(184, 45)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(100, 23)
        Me.ComboBox3.TabIndex = 7
        Me.ComboBox3.Visible = False
        '
        'FromLoc
        '
        Me.FromLoc.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.FromLoc.Location = New System.Drawing.Point(21, 48)
        Me.FromLoc.Name = "FromLoc"
        Me.FromLoc.Size = New System.Drawing.Size(51, 20)
        Me.FromLoc.Text = "From:"
        Me.FromLoc.Visible = False
        '
        'ToLoc
        '
        Me.ToLoc.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToLoc.Location = New System.Drawing.Point(21, 114)
        Me.ToLoc.Name = "ToLoc"
        Me.ToLoc.Size = New System.Drawing.Size(40, 20)
        Me.ToLoc.Text = "To:"
        Me.ToLoc.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(184, 167)
        Me.DateTimePicker1.MinDate = New Date(2020, 3, 6, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 24)
        Me.DateTimePicker1.TabIndex = 13
        Me.DateTimePicker1.Value = New Date(2020, 3, 6, 0, 0, 0, 0)
        Me.DateTimePicker1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(21, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 20)
        Me.Label4.Text = "Expected Date:"
        Me.Label4.Visible = False
        '
        'GetInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ToLoc)
        Me.Controls.Add(Me.FromLoc)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ReferenceNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.InvoiceNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GetInv"
        Me.Text = "Vendor/Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents InvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ReferenceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents FromLoc As System.Windows.Forms.Label
    Friend WithEvents ToLoc As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
