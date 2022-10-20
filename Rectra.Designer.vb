<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Rectra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rectra))
        Me.Vendor = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Qty = New System.Windows.Forms.TextBox
        Me.Qty2 = New System.Windows.Forms.TextBox
        Me.VendorIt = New System.Windows.Forms.PictureBox
        Me.Back = New System.Windows.Forms.PictureBox
        Me.Delete = New System.Windows.Forms.PictureBox
        Me.Submit = New System.Windows.Forms.PictureBox
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.BarcodeBox = New System.Windows.Forms.TextBox
        Me.Desc = New System.Windows.Forms.Label
        Me.ARB = New System.Windows.Forms.Label
        Me.Price = New System.Windows.Forms.Label
        Me.Invoice = New System.Windows.Forms.Label
        Me.Clear = New System.Windows.Forms.PictureBox
        Me.NetWeight = New System.Windows.Forms.Label
        Me.EditWeight = New System.Windows.Forms.PictureBox
        Me.UOM = New System.Windows.Forms.ComboBox
        Me.Barcode100 = New Symbol.Barcode2.Design.Barcode2
        Me.Pack = New System.Windows.Forms.Label
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Vendor
        '
        Me.Vendor.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Vendor.Location = New System.Drawing.Point(12, 0)
        Me.Vendor.Name = "Vendor"
        Me.Vendor.Size = New System.Drawing.Size(175, 20)
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGrid1.Location = New System.Drawing.Point(12, 23)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(296, 125)
        Me.DataGrid1.TabIndex = 2
        Me.DataGrid1.TableStyles.Add(Me.DataGridTableStyle1)
        Me.DataGrid1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Barcode"
        Me.DataGridTextBoxColumn1.NullText = "Barcode"
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "UOM"
        Me.DataGridTextBoxColumn2.NullText = "UOM"
        '
        'Qty
        '
        Me.Qty.Location = New System.Drawing.Point(132, 240)
        Me.Qty.Name = "Qty"
        Me.Qty.Size = New System.Drawing.Size(47, 23)
        Me.Qty.TabIndex = 1
        '
        'Qty2
        '
        Me.Qty2.Location = New System.Drawing.Point(187, 240)
        Me.Qty2.Name = "Qty2"
        Me.Qty2.Size = New System.Drawing.Size(47, 23)
        Me.Qty2.TabIndex = 2
        '
        'VendorIt
        '
        Me.VendorIt.Image = CType(resources.GetObject("VendorIt.Image"), System.Drawing.Image)
        Me.VendorIt.Location = New System.Drawing.Point(274, 0)
        Me.VendorIt.Name = "VendorIt"
        Me.VendorIt.Size = New System.Drawing.Size(32, 20)
        Me.VendorIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Back
        '
        Me.Back.Image = CType(resources.GetObject("Back.Image"), System.Drawing.Image)
        Me.Back.Location = New System.Drawing.Point(12, 240)
        Me.Back.Name = "Back"
        Me.Back.Size = New System.Drawing.Size(34, 25)
        Me.Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Delete
        '
        Me.Delete.Enabled = False
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.Location = New System.Drawing.Point(52, 240)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(33, 23)
        Me.Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Submit
        '
        Me.Submit.Image = CType(resources.GetObject("Submit.Image"), System.Drawing.Image)
        Me.Submit.Location = New System.Drawing.Point(274, 240)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(34, 23)
        Me.Submit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4})
        Me.DataTable1.DisplayExpression = ""
        Me.DataTable1.Prefix = ""
        Me.DataTable1.TableName = "Table1"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnMapping = System.Data.MappingType.Element
        Me.DataColumn1.ColumnName = "Barcode"
        Me.DataColumn1.DataType = GetType(String)
        Me.DataColumn1.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal
        Me.DataColumn1.Expression = ""
        Me.DataColumn1.Prefix = ""
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnMapping = System.Data.MappingType.Element
        Me.DataColumn2.ColumnName = "Desc"
        Me.DataColumn2.DataType = GetType(String)
        Me.DataColumn2.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal
        Me.DataColumn2.Expression = ""
        Me.DataColumn2.Prefix = ""
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnMapping = System.Data.MappingType.Element
        Me.DataColumn3.ColumnName = "UOM"
        Me.DataColumn3.DataType = GetType(String)
        Me.DataColumn3.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal
        Me.DataColumn3.Expression = ""
        Me.DataColumn3.Prefix = ""
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnMapping = System.Data.MappingType.Element
        Me.DataColumn4.ColumnName = "Qty"
        Me.DataColumn4.DataType = GetType(Decimal)
        Me.DataColumn4.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal
        Me.DataColumn4.Expression = ""
        Me.DataColumn4.Prefix = ""
        '
        'BarcodeBox
        '
        Me.BarcodeBox.Location = New System.Drawing.Point(12, 211)
        Me.BarcodeBox.Name = "BarcodeBox"
        Me.BarcodeBox.Size = New System.Drawing.Size(110, 23)
        Me.BarcodeBox.TabIndex = 0
        '
        'Desc
        '
        Me.Desc.BackColor = System.Drawing.Color.DarkGray
        Me.Desc.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Desc.Location = New System.Drawing.Point(12, 151)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(296, 20)
        Me.Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ARB
        '
        Me.ARB.BackColor = System.Drawing.Color.DarkGray
        Me.ARB.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ARB.Location = New System.Drawing.Point(12, 181)
        Me.ARB.Name = "ARB"
        Me.ARB.Size = New System.Drawing.Size(175, 20)
        Me.ARB.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Price
        '
        Me.Price.BackColor = System.Drawing.Color.DarkGray
        Me.Price.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Price.Location = New System.Drawing.Point(191, 181)
        Me.Price.Name = "Price"
        Me.Price.Size = New System.Drawing.Size(117, 20)
        Me.Price.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Invoice
        '
        Me.Invoice.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Invoice.Location = New System.Drawing.Point(193, 0)
        Me.Invoice.Name = "Invoice"
        Me.Invoice.Size = New System.Drawing.Size(75, 20)
        '
        'Clear
        '
        Me.Clear.Enabled = False
        Me.Clear.Image = CType(resources.GetObject("Clear.Image"), System.Drawing.Image)
        Me.Clear.Location = New System.Drawing.Point(91, 240)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(31, 23)
        Me.Clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'NetWeight
        '
        Me.NetWeight.BackColor = System.Drawing.Color.DarkGray
        Me.NetWeight.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NetWeight.Location = New System.Drawing.Point(127, 210)
        Me.NetWeight.Name = "NetWeight"
        Me.NetWeight.Size = New System.Drawing.Size(60, 24)
        Me.NetWeight.Text = "0"
        Me.NetWeight.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'EditWeight
        '
        Me.EditWeight.Enabled = False
        Me.EditWeight.Image = CType(resources.GetObject("EditWeight.Image"), System.Drawing.Image)
        Me.EditWeight.Location = New System.Drawing.Point(239, 240)
        Me.EditWeight.Name = "EditWeight"
        Me.EditWeight.Size = New System.Drawing.Size(31, 23)
        Me.EditWeight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'UOM
        '
        Me.UOM.Enabled = False
        Me.UOM.Location = New System.Drawing.Point(193, 211)
        Me.UOM.Name = "UOM"
        Me.UOM.Size = New System.Drawing.Size(67, 23)
        Me.UOM.TabIndex = 13
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
        'Pack
        '
        Me.Pack.BackColor = System.Drawing.Color.DarkGray
        Me.Pack.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Pack.Location = New System.Drawing.Point(266, 210)
        Me.Pack.Name = "Pack"
        Me.Pack.Size = New System.Drawing.Size(42, 24)
        Me.Pack.Text = "0"
        Me.Pack.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Rectra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Pack)
        Me.Controls.Add(Me.UOM)
        Me.Controls.Add(Me.EditWeight)
        Me.Controls.Add(Me.NetWeight)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Invoice)
        Me.Controls.Add(Me.Price)
        Me.Controls.Add(Me.ARB)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.BarcodeBox)
        Me.Controls.Add(Me.Submit)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.VendorIt)
        Me.Controls.Add(Me.Qty2)
        Me.Controls.Add(Me.Qty)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Vendor)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Rectra"
        Me.Text = "P/R"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Vendor As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Qty As System.Windows.Forms.TextBox
    Friend WithEvents Qty2 As System.Windows.Forms.TextBox
    Friend WithEvents VendorIt As System.Windows.Forms.PictureBox
    Friend WithEvents Back As System.Windows.Forms.PictureBox
    Friend WithEvents Delete As System.Windows.Forms.PictureBox
    Friend WithEvents Submit As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents BarcodeBox As System.Windows.Forms.TextBox
    Friend WithEvents Desc As System.Windows.Forms.Label
    Friend WithEvents ARB As System.Windows.Forms.Label
    Friend WithEvents Price As System.Windows.Forms.Label
    Friend WithEvents Invoice As System.Windows.Forms.Label
    Friend WithEvents Clear As System.Windows.Forms.PictureBox
    Friend WithEvents NetWeight As System.Windows.Forms.Label
    Friend WithEvents EditWeight As System.Windows.Forms.PictureBox
    Friend WithEvents UOM As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode100 As Symbol.Barcode2.Design.Barcode2
    Friend WithEvents Pack As System.Windows.Forms.Label
End Class
