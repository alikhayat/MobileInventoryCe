<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainMen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMen))
        Me.PriceButton = New System.Windows.Forms.Button
        Me.logoutButton = New System.Windows.Forms.Button
        Me.LabelingBtn = New System.Windows.Forms.Button
        Me.SyncButton = New System.Windows.Forms.PictureBox
        Me.TransferInBtn = New System.Windows.Forms.Button
        Me.ReceivingBtn = New System.Windows.Forms.Button
        Me.TransferOutBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PriceButton
        '
        Me.PriceButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PriceButton.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PriceButton.Location = New System.Drawing.Point(73, 7)
        Me.PriceButton.Name = "PriceButton"
        Me.PriceButton.Size = New System.Drawing.Size(174, 34)
        Me.PriceButton.TabIndex = 0
        Me.PriceButton.Text = "Price Check"
        '
        'logoutButton
        '
        Me.logoutButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.logoutButton.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.logoutButton.Location = New System.Drawing.Point(3, 225)
        Me.logoutButton.Name = "logoutButton"
        Me.logoutButton.Size = New System.Drawing.Size(56, 20)
        Me.logoutButton.TabIndex = 5
        Me.logoutButton.Text = "Logout"
        '
        'LabelingBtn
        '
        Me.LabelingBtn.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelingBtn.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelingBtn.Location = New System.Drawing.Point(73, 57)
        Me.LabelingBtn.Name = "LabelingBtn"
        Me.LabelingBtn.Size = New System.Drawing.Size(174, 34)
        Me.LabelingBtn.TabIndex = 1
        Me.LabelingBtn.Text = "Labeling"
        '
        'SyncButton
        '
        Me.SyncButton.Image = CType(resources.GetObject("SyncButton.Image"), System.Drawing.Image)
        Me.SyncButton.Location = New System.Drawing.Point(262, 3)
        Me.SyncButton.Name = "SyncButton"
        Me.SyncButton.Size = New System.Drawing.Size(47, 38)
        Me.SyncButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'TransferInBtn
        '
        Me.TransferInBtn.BackColor = System.Drawing.Color.DimGray
        Me.TransferInBtn.Enabled = False
        Me.TransferInBtn.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TransferInBtn.Location = New System.Drawing.Point(73, 152)
        Me.TransferInBtn.Name = "TransferInBtn"
        Me.TransferInBtn.Size = New System.Drawing.Size(174, 34)
        Me.TransferInBtn.TabIndex = 3
        Me.TransferInBtn.Text = "Transfer In"
        '
        'ReceivingBtn
        '
        Me.ReceivingBtn.BackColor = System.Drawing.Color.DimGray
        Me.ReceivingBtn.Enabled = False
        Me.ReceivingBtn.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ReceivingBtn.Location = New System.Drawing.Point(73, 106)
        Me.ReceivingBtn.Name = "ReceivingBtn"
        Me.ReceivingBtn.Size = New System.Drawing.Size(174, 34)
        Me.ReceivingBtn.TabIndex = 2
        Me.ReceivingBtn.Text = "Receiving"
        '
        'TransferOutBtn
        '
        Me.TransferOutBtn.BackColor = System.Drawing.Color.DimGray
        Me.TransferOutBtn.Enabled = False
        Me.TransferOutBtn.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TransferOutBtn.Location = New System.Drawing.Point(75, 197)
        Me.TransferOutBtn.Name = "TransferOutBtn"
        Me.TransferOutBtn.Size = New System.Drawing.Size(172, 34)
        Me.TransferOutBtn.TabIndex = 4
        Me.TransferOutBtn.Text = "Transfer Out"
        '
        'MainMen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.TransferOutBtn)
        Me.Controls.Add(Me.ReceivingBtn)
        Me.Controls.Add(Me.TransferInBtn)
        Me.Controls.Add(Me.SyncButton)
        Me.Controls.Add(Me.LabelingBtn)
        Me.Controls.Add(Me.logoutButton)
        Me.Controls.Add(Me.PriceButton)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainMen"
        Me.Text = "Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PriceButton As System.Windows.Forms.Button
    Friend WithEvents logoutButton As System.Windows.Forms.Button
    Friend WithEvents LabelingBtn As System.Windows.Forms.Button
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
    Friend WithEvents SyncButton As System.Windows.Forms.PictureBox
    Friend WithEvents TransferInBtn As System.Windows.Forms.Button
    Friend WithEvents ReceivingBtn As System.Windows.Forms.Button
    Friend WithEvents TransferOutBtn As System.Windows.Forms.Button
End Class
