<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TransferIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransferIn))
        Me.Tittle = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.OrderNo = New System.Windows.Forms.TextBox
        Me.StoreFrom = New System.Windows.Forms.Label
        Me.FromName = New System.Windows.Forms.Label
        Me.ShippedDate = New System.Windows.Forms.Label
        Me.ItemCount = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Barcode100 = New Symbol.Barcode2.Design.Barcode2
        Me.Clear = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Tittle
        '
        Me.Tittle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Tittle.Location = New System.Drawing.Point(15, 14)
        Me.Tittle.Name = "Tittle"
        Me.Tittle.Size = New System.Drawing.Size(292, 20)
        Me.Tittle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(15, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.Text = "Order No:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.Text = "Store From:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(15, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.Text = "From Name:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(15, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.Text = "Shipped on:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(15, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.Text = "No of Items:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(15, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.Text = "Difference exists:"
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(273, 237)
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
        'OrderNo
        '
        Me.OrderNo.Location = New System.Drawing.Point(151, 52)
        Me.OrderNo.Name = "OrderNo"
        Me.OrderNo.Size = New System.Drawing.Size(156, 23)
        Me.OrderNo.TabIndex = 0
        '
        'StoreFrom
        '
        Me.StoreFrom.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.StoreFrom.Location = New System.Drawing.Point(151, 84)
        Me.StoreFrom.Name = "StoreFrom"
        Me.StoreFrom.Size = New System.Drawing.Size(156, 20)
        '
        'FromName
        '
        Me.FromName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FromName.Location = New System.Drawing.Point(151, 114)
        Me.FromName.Name = "FromName"
        Me.FromName.Size = New System.Drawing.Size(156, 20)
        '
        'ShippedDate
        '
        Me.ShippedDate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ShippedDate.Location = New System.Drawing.Point(151, 147)
        Me.ShippedDate.Name = "ShippedDate"
        Me.ShippedDate.Size = New System.Drawing.Size(156, 20)
        '
        'ItemCount
        '
        Me.ItemCount.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ItemCount.Location = New System.Drawing.Point(151, 178)
        Me.ItemCount.Name = "ItemCount"
        Me.ItemCount.Size = New System.Drawing.Size(156, 20)
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(151, 206)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(156, 20)
        Me.CheckBox1.TabIndex = 20
        '
        'Barcode100
        '
        Me.Barcode100.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.CODABARParams.ClsiEditing = False
        Me.Barcode100.Config.DecoderParameters.CODABARParams.NotisEditing = False
        Me.Barcode100.Config.DecoderParameters.CODABARParams.Redundancy = True
        Me.Barcode100.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.CODE128Params.EAN128 = True
        Me.Barcode100.Config.DecoderParameters.CODE128Params.ISBT128 = True
        Me.Barcode100.Config.DecoderParameters.CODE128Params.Other128 = True
        Me.Barcode100.Config.DecoderParameters.CODE128Params.Redundancy = False
        Me.Barcode100.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.CODE39Params.Code32Prefix = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.Concatenation = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.ConvertToCode32 = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.FullAscii = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.Redundancy = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.ReportCheckDigit = False
        Me.Barcode100.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = False
        Me.Barcode100.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.CODE93Params.Redundancy = False
        Me.Barcode100.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.D2OF5Params.Redundancy = True
        Me.Barcode100.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = False
        Me.Barcode100.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = False
        Me.Barcode100.Config.DecoderParameters.I2OF5Params.Redundancy = True
        Me.Barcode100.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = False
        Me.Barcode100.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.[Default]
        Me.Barcode100.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = True
        Me.Barcode100.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.[Default]
        Me.Barcode100.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.[Default]
        Me.Barcode100.Config.DecoderParameters.MSIParams.Redundancy = True
        Me.Barcode100.Config.DecoderParameters.MSIParams.ReportCheckDigit = False
        Me.Barcode100.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.[Default]
        Me.Barcode100.Config.DecoderParameters.UPCAParams.ReportCheckDigit = True
        Me.Barcode100.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Enabled
        Me.Barcode100.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = False
        Me.Barcode100.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.System
        Me.Barcode100.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = True
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.[DEFAULT]
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT
        Me.Barcode100.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode100.Config.ScanParameters.BeepFrequency = 500
        Me.Barcode100.Config.ScanParameters.BeepTime = 100
        Me.Barcode100.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.[Default]
        Me.Barcode100.Config.ScanParameters.LedTime = 3000
        Me.Barcode100.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.[Default]
        Me.Barcode100.Config.ScanParameters.WaveFile = ""
        Me.Barcode100.DeviceType = Symbol.Barcode2.DEVICETYPES.INTERNAL_LASER1
        Me.Barcode100.EnableScanner = False
        '
        'Clear
        '
        Me.Clear.Enabled = False
        Me.Clear.Image = CType(resources.GetObject("Clear.Image"), System.Drawing.Image)
        Me.Clear.Location = New System.Drawing.Point(111, 237)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(34, 25)
        Me.Clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'TransferIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ItemCount)
        Me.Controls.Add(Me.ShippedDate)
        Me.Controls.Add(Me.FromName)
        Me.Controls.Add(Me.StoreFrom)
        Me.Controls.Add(Me.OrderNo)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tittle)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransferIn"
        Me.Text = "TransferIn"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tittle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents OrderNo As System.Windows.Forms.TextBox
    Friend WithEvents StoreFrom As System.Windows.Forms.Label
    Friend WithEvents FromName As System.Windows.Forms.Label
    Friend WithEvents ShippedDate As System.Windows.Forms.Label
    Friend WithEvents ItemCount As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Barcode100 As Symbol.Barcode2.Design.Barcode2
    Friend WithEvents Clear As System.Windows.Forms.PictureBox
End Class
