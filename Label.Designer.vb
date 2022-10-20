<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Label))
        Me.ItemNo = New System.Windows.Forms.Label
        Me.Price = New System.Windows.Forms.Label
        Me.VarCode = New System.Windows.Forms.Label
        Me.UOM = New System.Windows.Forms.Label
        Me.ArabicDesc = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Desc = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BarcodeBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.QuantityBox = New System.Windows.Forms.TextBox
        Me.CancelLbl = New System.Windows.Forms.Label
        Me.Back = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Barcode21 = New Symbol.Barcode2.Design.Barcode2
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Submit = New System.Windows.Forms.Button
        Me.Reset = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.VendorIt = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'ItemNo
        '
        Me.ItemNo.BackColor = System.Drawing.Color.Silver
        Me.ItemNo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ItemNo.Location = New System.Drawing.Point(101, 140)
        Me.ItemNo.Name = "ItemNo"
        Me.ItemNo.Size = New System.Drawing.Size(65, 20)
        Me.ItemNo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Price
        '
        Me.Price.BackColor = System.Drawing.Color.Silver
        Me.Price.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Price.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Price.Location = New System.Drawing.Point(208, 170)
        Me.Price.Name = "Price"
        Me.Price.Size = New System.Drawing.Size(97, 20)
        Me.Price.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'VarCode
        '
        Me.VarCode.BackColor = System.Drawing.Color.Silver
        Me.VarCode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.VarCode.Location = New System.Drawing.Point(170, 140)
        Me.VarCode.Name = "VarCode"
        Me.VarCode.Size = New System.Drawing.Size(65, 20)
        Me.VarCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'UOM
        '
        Me.UOM.BackColor = System.Drawing.Color.Silver
        Me.UOM.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.UOM.Location = New System.Drawing.Point(240, 140)
        Me.UOM.Name = "UOM"
        Me.UOM.Size = New System.Drawing.Size(65, 20)
        Me.UOM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ArabicDesc
        '
        Me.ArabicDesc.BackColor = System.Drawing.Color.Silver
        Me.ArabicDesc.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ArabicDesc.Location = New System.Drawing.Point(101, 98)
        Me.ArabicDesc.Name = "ArabicDesc"
        Me.ArabicDesc.Size = New System.Drawing.Size(204, 33)
        Me.ArabicDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(6, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 20)
        Me.Label4.Text = " Arabic desc:"
        '
        'Desc
        '
        Me.Desc.BackColor = System.Drawing.Color.Silver
        Me.Desc.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Desc.Location = New System.Drawing.Point(101, 48)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(204, 33)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 20)
        Me.Label3.Text = " Description:"
        '
        'BarcodeBox
        '
        Me.BarcodeBox.Location = New System.Drawing.Point(86, 12)
        Me.BarcodeBox.Name = "BarcodeBox"
        Me.BarcodeBox.Size = New System.Drawing.Size(179, 23)
        Me.BarcodeBox.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 20)
        Me.Label1.Text = "Barcode:"
        '
        'QuantityBox
        '
        Me.QuantityBox.Enabled = False
        Me.QuantityBox.Location = New System.Drawing.Point(270, 197)
        Me.QuantityBox.Name = "QuantityBox"
        Me.QuantityBox.Size = New System.Drawing.Size(35, 23)
        Me.QuantityBox.TabIndex = 28
        '
        'CancelLbl
        '
        Me.CancelLbl.Enabled = False
        Me.CancelLbl.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.CancelLbl.Location = New System.Drawing.Point(214, 197)
        Me.CancelLbl.Name = "CancelLbl"
        Me.CancelLbl.Size = New System.Drawing.Size(50, 20)
        Me.CancelLbl.Text = "Qty :"
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(10, 236)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(32, 26)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(10, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.Text = "Expiry:"
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
        Me.Barcode21.EnableScanner = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(70, 197)
        Me.DateTimePicker1.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(97, 24)
        Me.DateTimePicker1.TabIndex = 42
        Me.DateTimePicker1.Visible = False
        '
        'Submit
        '
        Me.Submit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Submit.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Submit.Location = New System.Drawing.Point(241, 236)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(64, 24)
        Me.Submit.TabIndex = 59
        Me.Submit.Text = "Submit"
        '
        'Reset
        '
        Me.Reset.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Reset.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Reset.Location = New System.Drawing.Point(70, 236)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(66, 24)
        Me.Reset.TabIndex = 76
        Me.Reset.Text = "Clear"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ListBox1.Location = New System.Drawing.Point(225, 170)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(80, 92)
        Me.ListBox1.TabIndex = 94
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(153, 236)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 24)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "UOM"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(311, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(70, 170)
        Me.DateTimePicker2.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(97, 24)
        Me.DateTimePicker2.TabIndex = 112
        Me.DateTimePicker2.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(9, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 20)
        Me.Label5.Text = "Packed:"
        '
        'VendorIt
        '
        Me.VendorIt.Image = CType(resources.GetObject("VendorIt.Image"), System.Drawing.Image)
        Me.VendorIt.Location = New System.Drawing.Point(273, 12)
        Me.VendorIt.Name = "VendorIt"
        Me.VendorIt.Size = New System.Drawing.Size(32, 23)
        Me.VendorIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.VendorIt)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.CancelLbl)
        Me.Controls.Add(Me.QuantityBox)
        Me.Controls.Add(Me.ItemNo)
        Me.Controls.Add(Me.Price)
        Me.Controls.Add(Me.VarCode)
        Me.Controls.Add(Me.UOM)
        Me.Controls.Add(Me.ArabicDesc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BarcodeBox)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Label"
        Me.Text = "Labels"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemNo As System.Windows.Forms.Label
    Friend WithEvents Price As System.Windows.Forms.Label
    Friend WithEvents VarCode As System.Windows.Forms.Label
    Friend WithEvents UOM As System.Windows.Forms.Label
    Friend WithEvents ArabicDesc As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Desc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BarcodeBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QuantityBox As System.Windows.Forms.TextBox
    Friend WithEvents CancelLbl As System.Windows.Forms.Label
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Barcode21 As Symbol.Barcode2.Design.Barcode2
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Submit As System.Windows.Forms.Button
    Friend WithEvents Reset As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VendorIt As System.Windows.Forms.PictureBox
End Class
