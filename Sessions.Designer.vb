<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LabelSessions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabelSessions))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Edit = New System.Windows.Forms.PictureBox
        Me.Delete = New System.Windows.Forms.PictureBox
        Me.Plus = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.Sync_Nav = New System.Windows.Forms.PictureBox
        Me.SyncAll = New System.Windows.Forms.PictureBox
        Me.Print = New System.Windows.Forms.PictureBox
        Me.PlusJob = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.Location = New System.Drawing.Point(12, 49)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.SelectionBackColor = System.Drawing.SystemColors.Desktop
        Me.DataGrid1.Size = New System.Drawing.Size(295, 167)
        Me.DataGrid1.TabIndex = 0
        '
        'Edit
        '
        Me.Edit.Image = CType(resources.GetObject("Edit.Image"), System.Drawing.Image)
        Me.Edit.Location = New System.Drawing.Point(131, 13)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(53, 30)
        Me.Edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.Location = New System.Drawing.Point(202, 13)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(42, 30)
        Me.Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Plus
        '
        Me.Plus.Image = CType(resources.GetObject("Plus.Image"), System.Drawing.Image)
        Me.Plus.Location = New System.Drawing.Point(12, 13)
        Me.Plus.Name = "Plus"
        Me.Plus.Size = New System.Drawing.Size(45, 30)
        Me.Plus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(12, 229)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(32, 26)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Sync_Nav
        '
        Me.Sync_Nav.Image = CType(resources.GetObject("Sync_Nav.Image"), System.Drawing.Image)
        Me.Sync_Nav.Location = New System.Drawing.Point(260, 229)
        Me.Sync_Nav.Name = "Sync_Nav"
        Me.Sync_Nav.Size = New System.Drawing.Size(47, 30)
        Me.Sync_Nav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'SyncAll
        '
        Me.SyncAll.Image = CType(resources.GetObject("SyncAll.Image"), System.Drawing.Image)
        Me.SyncAll.Location = New System.Drawing.Point(197, 229)
        Me.SyncAll.Name = "SyncAll"
        Me.SyncAll.Size = New System.Drawing.Size(47, 30)
        Me.SyncAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Print
        '
        Me.Print.Image = CType(resources.GetObject("Print.Image"), System.Drawing.Image)
        Me.Print.Location = New System.Drawing.Point(260, 13)
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(47, 30)
        Me.Print.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PlusJob
        '
        Me.PlusJob.Image = CType(resources.GetObject("PlusJob.Image"), System.Drawing.Image)
        Me.PlusJob.Location = New System.Drawing.Point(72, 13)
        Me.PlusJob.Name = "PlusJob"
        Me.PlusJob.Size = New System.Drawing.Size(45, 30)
        Me.PlusJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PlusJob.Visible = False
        '
        'LabelSessions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.PlusJob)
        Me.Controls.Add(Me.Print)
        Me.Controls.Add(Me.SyncAll)
        Me.Controls.Add(Me.Sync_Nav)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.Plus)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.DataGrid1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LabelSessions"
        Me.Text = "Sessions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Edit As System.Windows.Forms.PictureBox
    Friend WithEvents Delete As System.Windows.Forms.PictureBox
    Friend WithEvents Plus As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents Sync_Nav As System.Windows.Forms.PictureBox
    Friend WithEvents SyncAll As System.Windows.Forms.PictureBox
    Friend WithEvents Print As System.Windows.Forms.PictureBox
    Friend WithEvents PlusJob As System.Windows.Forms.PictureBox
End Class
