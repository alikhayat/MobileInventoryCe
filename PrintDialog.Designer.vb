<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PrintDialog
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
        Me.PrinterList = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Quantity = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PrinterList
        '
        Me.PrinterList.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        Me.PrinterList.Location = New System.Drawing.Point(15, 30)
        Me.PrinterList.Name = "PrinterList"
        Me.PrinterList.Size = New System.Drawing.Size(211, 137)
        Me.PrinterList.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(232, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Select"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(232, 125)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 39)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        '
        'Quantity
        '
        Me.Quantity.Location = New System.Drawing.Point(124, 215)
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Size = New System.Drawing.Size(50, 23)
        Me.Quantity.TabIndex = 3
        Me.Quantity.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(15, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.Text = "Print Quantity:"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 42)
        Me.Label2.Visible = False
        '
        'PrintDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Quantity)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PrinterList)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "PrintDialog"
        Me.Text = "PrintDialog"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrinterList As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Public Overridable Property ActiveControl() As Control
        Get
            Return GetFocusedControl(Me)
        End Get
        Set(ByVal value As Control)

            If Not value.Focused Then
                value.Focus()
            End If
        End Set
    End Property

    Private Function GetFocusedControl(ByVal parent As Control) As Control
        If parent.Focused Then
            Return parent
        End If

        For Each ctrl As Control In parent.Controls
            Dim temp As Control = GetFocusedControl(ctrl)

            If temp IsNot Nothing Then
                Return temp
            End If
        Next

        Return Nothing
    End Function
    Friend WithEvents Quantity As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
