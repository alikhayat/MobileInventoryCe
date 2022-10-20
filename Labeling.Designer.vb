<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Labeling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Labeling))
        Me.Back = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(3, 214)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(32, 26)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Labeling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Back)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Labeling"
        Me.Text = "Labeling"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    'Class SurroundingClass
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
    'End Class
End Class
