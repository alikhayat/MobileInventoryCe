Partial Public Class Component1
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusTimer = New System.Windows.Forms.Timer
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        '
        'StatusTimer
        '
        Me.StatusTimer.Enabled = True
        Me.StatusTimer.Interval = 1000
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Text = "StatusBar1"

    End Sub
    Friend WithEvents StatusTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar

End Class
