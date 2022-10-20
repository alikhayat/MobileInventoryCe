<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PricingJobMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PricingJobMain))
        Me.NewPrice = New System.Windows.Forms.Label
        Me.ARB = New System.Windows.Forms.Label
        Me.Desc = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.JobTittle = New System.Windows.Forms.Label
        Me.BarcodeList = New System.Windows.Forms.ListBox
        Me.ReasonCodes = New System.Windows.Forms.ComboBox
        Me.Barcode21 = New Symbol.Barcode2.Design.Barcode2
        Me.BarcodeBox = New System.Windows.Forms.TextBox
        Me.UOM = New System.Windows.Forms.Label
        Me.Qty = New System.Windows.Forms.TextBox
        Me.Clear = New System.Windows.Forms.PictureBox
        Me.Mark = New System.Windows.Forms.PictureBox
        Me.OldPrice = New System.Windows.Forms.Label
        Me.LineCounter = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'NewPrice
        '
        Me.NewPrice.BackColor = System.Drawing.Color.DarkGray
        Me.NewPrice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.NewPrice.ForeColor = System.Drawing.Color.Green
        Me.NewPrice.Location = New System.Drawing.Point(191, 181)
        Me.NewPrice.Name = "NewPrice"
        Me.NewPrice.Size = New System.Drawing.Size(58, 20)
        Me.NewPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ARB
        '
        Me.ARB.BackColor = System.Drawing.Color.DarkGray
        Me.ARB.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ARB.Location = New System.Drawing.Point(12, 181)
        Me.ARB.Name = "ARB"
        Me.ARB.Size = New System.Drawing.Size(175, 20)
        Me.ARB.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Desc
        '
        Me.Desc.BackColor = System.Drawing.Color.DarkGray
        Me.Desc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Desc.Location = New System.Drawing.Point(12, 151)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(296, 27)
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.Location = New System.Drawing.Point(12, 23)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(296, 125)
        Me.DataGrid1.TabIndex = 5
        Me.DataGrid1.TableStyles.Add(Me.DataGridTableStyle1)
        Me.DataGrid1.TabStop = False
        '
        'Submit
        '
        Me.Submit.Enabled = False
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(274, 240)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 25)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(12, 240)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'JobTittle
        '
        Me.JobTittle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.JobTittle.Location = New System.Drawing.Point(12, 0)
        Me.JobTittle.Name = "JobTittle"
        Me.JobTittle.Size = New System.Drawing.Size(259, 20)
        Me.JobTittle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BarcodeList
        '
        Me.BarcodeList.Location = New System.Drawing.Point(52, 231)
        Me.BarcodeList.Name = "BarcodeList"
        Me.BarcodeList.Size = New System.Drawing.Size(97, 34)
        Me.BarcodeList.TabIndex = 12
        '
        'ReasonCodes
        '
        Me.ReasonCodes.Enabled = False
        Me.ReasonCodes.Location = New System.Drawing.Point(191, 204)
        Me.ReasonCodes.Name = "ReasonCodes"
        Me.ReasonCodes.Size = New System.Drawing.Size(117, 23)
        Me.ReasonCodes.TabIndex = 11
        '
        'Barcode21
        '
        Me.Barcode21.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.CODABARParams.ClsiEditing = False
        Me.Barcode21.Config.DecoderParameters.CODABARParams.NotisEditing = False
        Me.Barcode21.Config.DecoderParameters.CODABARParams.Redundancy = True
        Me.Barcode21.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.CODE128Params.EAN128 = True
        Me.Barcode21.Config.DecoderParameters.CODE128Params.ISBT128 = True
        Me.Barcode21.Config.DecoderParameters.CODE128Params.Other128 = True
        Me.Barcode21.Config.DecoderParameters.CODE128Params.Redundancy = False
        Me.Barcode21.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.CODE39Params.Code32Prefix = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.Concatenation = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.ConvertToCode32 = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.FullAscii = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.Redundancy = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.ReportCheckDigit = False
        Me.Barcode21.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = False
        Me.Barcode21.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.CODE93Params.Redundancy = False
        Me.Barcode21.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.D2OF5Params.Redundancy = True
        Me.Barcode21.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = False
        Me.Barcode21.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = False
        Me.Barcode21.Config.DecoderParameters.I2OF5Params.Redundancy = True
        Me.Barcode21.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = False
        Me.Barcode21.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.[Default]
        Me.Barcode21.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = True
        Me.Barcode21.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.[Default]
        Me.Barcode21.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.[Default]
        Me.Barcode21.Config.DecoderParameters.MSIParams.Redundancy = True
        Me.Barcode21.Config.DecoderParameters.MSIParams.ReportCheckDigit = False
        Me.Barcode21.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.[Default]
        Me.Barcode21.Config.DecoderParameters.UPCAParams.ReportCheckDigit = True
        Me.Barcode21.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Enabled
        Me.Barcode21.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = False
        Me.Barcode21.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.System
        Me.Barcode21.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = True
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.[DEFAULT]
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT
        Me.Barcode21.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.[Default]
        Me.Barcode21.Config.ScanParameters.BeepFrequency = 500
        Me.Barcode21.Config.ScanParameters.BeepTime = 100
        Me.Barcode21.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.[Default]
        Me.Barcode21.Config.ScanParameters.LedTime = 3000
        Me.Barcode21.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.[Default]
        Me.Barcode21.Config.ScanParameters.WaveFile = ""
        Me.Barcode21.DeviceType = Symbol.Barcode2.DEVICETYPES.INTERNAL_LASER1
        Me.Barcode21.EnableScanner = True
        '
        'BarcodeBox
        '
        Me.BarcodeBox.Location = New System.Drawing.Point(12, 204)
        Me.BarcodeBox.Name = "BarcodeBox"
        Me.BarcodeBox.Size = New System.Drawing.Size(107, 23)
        Me.BarcodeBox.TabIndex = 0
        '
        'UOM
        '
        Me.UOM.BackColor = System.Drawing.Color.DarkGray
        Me.UOM.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.UOM.Location = New System.Drawing.Point(122, 204)
        Me.UOM.Name = "UOM"
        Me.UOM.Size = New System.Drawing.Size(65, 23)
        Me.UOM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Qty
        '
        Me.Qty.Enabled = False
        Me.Qty.Location = New System.Drawing.Point(154, 240)
        Me.Qty.MaxLength = 3
        Me.Qty.Name = "Qty"
        Me.Qty.Size = New System.Drawing.Size(36, 23)
        Me.Qty.TabIndex = 1
        '
        'Clear
        '
        Me.Clear.Enabled = False
        Me.Clear.Image = CType(resources.GetObject("Clear.Image"), System.Drawing.Image)
        Me.Clear.Location = New System.Drawing.Point(197, 240)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(34, 25)
        Me.Clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Mark
        '
        Me.Mark.Image = CType(resources.GetObject("Mark.Image"), System.Drawing.Image)
        Me.Mark.Location = New System.Drawing.Point(237, 240)
        Me.Mark.Name = "Mark"
        Me.Mark.Size = New System.Drawing.Size(34, 25)
        Me.Mark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Mark.Visible = False
        '
        'OldPrice
        '
        Me.OldPrice.BackColor = System.Drawing.Color.DarkGray
        Me.OldPrice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OldPrice.ForeColor = System.Drawing.Color.Red
        Me.OldPrice.Location = New System.Drawing.Point(250, 181)
        Me.OldPrice.Name = "OldPrice"
        Me.OldPrice.Size = New System.Drawing.Size(58, 20)
        Me.OldPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LineCounter
        '
        Me.LineCounter.Location = New System.Drawing.Point(276, 0)
        Me.LineCounter.Name = "LineCounter"
        Me.LineCounter.Size = New System.Drawing.Size(32, 20)
        '
        'PricingJobMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.LineCounter)
        Me.Controls.Add(Me.OldPrice)
        Me.Controls.Add(Me.Mark)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Qty)
        Me.Controls.Add(Me.UOM)
        Me.Controls.Add(Me.BarcodeBox)
        Me.Controls.Add(Me.ReasonCodes)
        Me.Controls.Add(Me.BarcodeList)
        Me.Controls.Add(Me.JobTittle)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.NewPrice)
        Me.Controls.Add(Me.ARB)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.DataGrid1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PricingJobMain"
        Me.Text = "PricingJobMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewPrice As System.Windows.Forms.Label
    Friend WithEvents ARB As System.Windows.Forms.Label
    Friend WithEvents Desc As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents JobTittle As System.Windows.Forms.Label
    Friend WithEvents BarcodeList As System.Windows.Forms.ListBox
    Friend WithEvents ReasonCodes As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode21 As Symbol.Barcode2.Design.Barcode2
    Friend WithEvents BarcodeBox As System.Windows.Forms.TextBox
    Friend WithEvents UOM As System.Windows.Forms.Label
    Friend WithEvents Qty As System.Windows.Forms.TextBox
    Friend WithEvents Clear As System.Windows.Forms.PictureBox
    Friend WithEvents Mark As System.Windows.Forms.PictureBox
    Friend WithEvents OldPrice As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents LineCounter As System.Windows.Forms.Label
End Class
