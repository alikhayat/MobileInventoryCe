Imports Symbol.WPAN
Imports Symbol.WPAN.Bluetooth
Public Structure Printer
    Public Name As String
    Public IP As String
    Public Port As String
    Public Mobile As Boolean
    Public Valid As Boolean
End Structure
Module PrintUtility
    Private UserID, Type, Code As String
    Private DefaultPrinter As Printer
    Private AllPrinters() As Printer
    Private MobilePrinters() As Printer
    Private BluetoothPrinter As RemoteDevice
    Private bt As Bluetooth
    Public Sub Print_Handle(ByVal SessionID As String, ByVal _Type As String, ByVal _Code As String)
        Dim ans As New MsgBoxResult
        Dim Brand = New PromptBrand(SessionID)

        RefreshPrinters(_Type, _Code)

        Try
            Select Case BrandPrompt()
                Case True
                    ThreadTimer.Dispose()
                    If Brand.ShowDialog = DialogResult.OK Then
                        InializeTimer()
                        If DefaultPrinter.Valid Then
                            ans = MsgBox(String.Format("Use default printer {0}?", DefaultPrinter.Name), MsgBoxStyle.YesNo, Nothing)
                            If ans = vbYes Then
                                Print_Default(SessionID)
                            ElseIf ans = MsgBoxResult.No Then
                                Print_Nondefault(SessionID)
                            End If
                        Else
                            Print_Nondefault(SessionID)
                        End If
                    End If
                Case False
                    If DefaultPrinter.Valid Then
                        ans = MsgBox(String.Format("Use default printer {0}?", DefaultPrinter.Name), MsgBoxStyle.YesNo, Nothing)
                        If ans = vbYes Then
                            Print_Default(SessionID)
                        ElseIf ans = MsgBoxResult.No Then
                            Print_Nondefault(SessionID)
                        End If
                    Else
                        Print_Nondefault(SessionID)
                    End If
            End Select

        Catch ex As Exception
        Finally
            Brand.Dispose()
        End Try

        Cursor.Current = Cursors.Default
    End Sub
    Public Function Print_HandleDirect(ByVal _Type As String, ByVal _Code As String, ByVal Line As Line) As Integer()
        Dim Printer As Printer
        Dim Qty As String = ""
        Dim Printed As Boolean = False
        Dim Info(1) As Integer

        RefreshPrinters(_Type, _Code)
        ThreadTimer.Dispose()
        Dim PrintDialog As New PrintDialog(AllPrinters, True, Line.Desc + " " + Line.UOMCode)

        If PrintDialog.ShowDialog = DialogResult.OK Then
            Printer = PrintDialog.GetSelectedPrinter
            Qty = PrintDialog.Quantity.Text.Trim

            If Printer.Valid Then
                Printed = TCP_PrintEPL(Printer.IP, Printer.Port, LineToEPL(Line, Qty))
            Else
                MessageBox("No valid printer selected")
            End If
        End If
        PrintDialog.Dispose()
        InializeTimer()
        Cursor.Current = Cursors.Default

        If Printed Then
            Info(0) = 1
            Info(1) = CInt(Qty)
        Else
            Info(0) = 0
            Info(1) = 0
        End If
        Return Info
    End Function
    Private Sub RefreshPrinters(ByVal _Type As String, ByVal _Code As String)
        If (Login.UserId <> UserID) Or (Type <> _Type) Or (Code <> _Code) Then
            Type = _Type
            Code = _Code
            UserID = Login.UserId
            GetDefaultPrinter()
            GetAllPrinters()
        End If
    End Sub
    Private Sub GetDefaultPrinter()
        db.read("[Printer Name],[Printer Ip Address],[Printer Port],[Mobile Printer]", "[" + CompanyName.Replace(".", "_") + "$Label Printer Selection]", String.Format("[Handheld User] = '{0}' and [Label Function] = '{1}'", UserID, Code))
        Try
            If dr.Read() Then
                DefaultPrinter.Name = CStr(dr.GetValue(0))
                DefaultPrinter.IP = CStr(dr.GetValue(1))
                DefaultPrinter.Port = CStr(dr.GetValue(2))
                DefaultPrinter.Mobile = dr.GetValue(3)
                If DefaultPrinter.IP <> "" And DefaultPrinter.Port <> "" Then
                    DefaultPrinter.Valid = True
                Else
                    DefaultPrinter.Valid = False
                End If
            Else
                DefaultPrinter.Name = String.Empty
                DefaultPrinter.IP = String.Empty
                DefaultPrinter.Port = String.Empty
                DefaultPrinter.Valid = False
            End If
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub
    Public Function GetDefaultPrinterName() As String
        Dim DefaultPrinter As String
        db.read("[Printer Name]", "[" + CompanyName.Replace(".", "_") + "$Label Printer Selection]", String.Format("[Handheld User] = '{0}' and [Label Function] = '{1}'", UserID, Code))
        If dr.Read Then
            DefaultPrinter = dr.GetValue(0)
        Else
            DefaultPrinter = String.Empty
        End If
        DBClose(True)
        Return DefaultPrinter
    End Function
    Private Sub GetAllPrinters()
        db.read("[Printer Name],[Printer Ip Address],[Printer Port],[Mobile Printer]", "[" + CompanyName.Replace(".", "_") + "$Label Printer Selection]", String.Format("[Label Function] = '{0}' and [User ID] = '' and ([Handheld User] = '' OR [Handheld User] = '{1}')", Code, UserID))
        Try
            Dim i As Integer = 0
            While dr.Read
                ReDim Preserve AllPrinters(i)
                AllPrinters(i).Name = CStr(dr.GetValue(0))
                AllPrinters(i).IP = CStr(dr.GetValue(1))
                AllPrinters(i).Port = CStr(dr.GetValue(2))
                AllPrinters(i).Mobile = dr.GetValue(3)
                If AllPrinters(i).IP <> "" And AllPrinters(i).Port <> "" Then
                    AllPrinters(i).Valid = True
                Else
                    AllPrinters(i).Valid = False
                End If
                i += 1
            End While

        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
    End Sub
    Private Sub Print_Default(ByVal SessionID As String)
        Try
            PostSession(SessionID)
            WebPrintLabels(SessionID, DefaultPrinter)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Print_Nondefault(ByVal SessionID As String)
        Dim PrintDialog = New PrintDialog(AllPrinters)
        ThreadTimer.Dispose()
        PrintDialog.ShowDialog()
        Dim Printer = PrintDialog.GetSelectedPrinter()
        PrintDialog.Dispose()
        InializeTimer()
        If Printer.Valid Then
            PostSession(SessionID)
            WebPrintLabels(SessionID, Printer)
        Else
            MessageBox("No valid printer selected")
        End If
    End Sub
    Private Sub PostSession(ByVal SessionID As String)
        Try
            Dim Post As New PostLabels
            Dim sessID(0) As String
            Dim DummyArray(0) As String
            sessID(0) = SessionID
            DummyArray(0) = ""
            Post.postSessions(sessID, DummyArray)
        Catch ex As Exception
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Public Sub WebPrintLabels(ByVal Session As String, ByVal Printer As Printer)
        'Cursor.Current = Cursors.WaitCursor
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim WebPrint As New PrintUtilCU.PrintUtilCU
        Dim Printed As Integer = -1
        WebPrint.Url = GetServiceURL(5, "50020")
        WebPrint.Credentials = GetCredentials()
        WebPrint.SoapVersion = Get_SoapVersion()
        Try
            'If Ping(NavIp, "Cannot connect to print server") Then
            Printed = WebPrint.WebDevicePrint(Session, Login.UserId, Store, DeviceID, Printer.Name, Printer.IP, Printer.Port)
            If Printed = 0 Then
                MessageBox("Printed")
            ElseIf Printed < 0 Then
                MessageBox("Error Printing")
            Else
                MessageBox(String.Format("Partially printed. {0} labels are pending price change,print from PC", Printed))
            End If
            'End If
        Catch ex As Exception
            MessageBox("Can't print from device right now")
        Finally
            WebPrint.Dispose()
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Private Function BrandPrompt() As Boolean
        db.read("[Prompt for brand]", "[" + CompanyName.Replace(".", "_") + "$Label Functions]", String.Format("[Label Code] = '{0}'", Code))
        If dr.Read Then
            If dr.GetValue(0) = 0 Then
                Return False
            Else
                Return True
            End If
        End If
    End Function
    Public Function GetMobilePrinters() As Printer()
        db.read("[Printer Name],[Printer IP Address],[Printer Port],[Mobile Printer]", "[" + CompanyName.Replace(".", "_") + "$Label Printer Selection]", "[Mobile Printer] = '1'")
        Try
            Dim i As Integer = 0
            While dr.Read
                ReDim Preserve MobilePrinters(i)
                MobilePrinters(i).Name = CStr(dr.GetValue(0))
                MobilePrinters(i).IP = CStr(dr.GetValue(1))
                MobilePrinters(i).Port = CStr(dr.GetValue(2))
                MobilePrinters(i).Mobile = dr.GetValue(3)
                If MobilePrinters(i).IP <> "" And MobilePrinters(i).Port <> "" Then
                    MobilePrinters(i).Valid = True
                Else
                    MobilePrinters(i).Valid = False
                End If
                i += 1
            End While
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
        Return MobilePrinters
    End Function
    Public Function BluetoothEnable() As Boolean
        Try
            bt = New Bluetooth()
            bt.Enable()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function BluetoothConnect(ByVal MAC As String, ByVal Port As Integer) As Boolean
        Dim RFPort As UInteger = Port
        BluetoothPrinter = New RemoteDevice("", MAC, RFPort)
        bt.RemoteDevices.Add(BluetoothPrinter)
        Try
            If Not BluetoothPrinter.IsPaired Then
                BluetoothPrinter.Pair()
            End If
            If Not BluetoothPrinter.IsComPortOpened Then
                BluetoothPrinter.OpenPort()
            End If
            Return True
        Catch ex As Exception
            If BluetoothPrinter.IsPaired Then
                BluetoothPrinter.UnPair()
            End If
            'bt.RemoteDevices.DeleteAll()
            Return False
        End Try
    End Function
    Public Function BluetoothConnected() As Boolean
        Try
            If BluetoothPrinter.IsPaired Then
                If BluetoothPrinter.IsComPortOpened Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function BluetoothReconnect() As Boolean
        Try
            If Not BluetoothPrinter.IsPaired Then
                BluetoothPrinter.Pair()
            End If
            If Not BluetoothPrinter.IsComPortOpened Then
                BluetoothPrinter.OpenPort()
            End If
            Return True
        Catch ex As Exception
            If BluetoothPrinter.IsPaired Then
                BluetoothPrinter.UnPair()
            End If
            Return False
        End Try
    End Function
    Public Sub BluetoothDisable()
        Try
            bt.Disable()
            bt.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub BluetoothDisconnect()
        Try
            If BluetoothPrinter.IsPaired Then
                If BluetoothPrinter.IsComPortOpened Then
                    BluetoothPrinter.ClosePort()
                End If
                BluetoothPrinter.ReleaseConnection()
                BluetoothPrinter.UnPair()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function BluetoothPrint(ByVal Line As LabelLine) As Boolean
        Dim ZPL As String = ""

        ZPL = LineToZPL(Line)

        Try
            If BluetoothPrinter.IsComPortOpened() Then
                BluetoothPrinter.Write(System.Text.Encoding.UTF8.GetBytes(ZPL))
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function BluetoothPrintPricingJob(ByVal Line As PricingJobLines)
        Dim ZPL As String = ""

        ZPL = LineToZPL2(Line)

        Try
            If BluetoothConnected() Then
                BluetoothPrinter.Write(System.Text.Encoding.UTF8.GetBytes(ZPL))
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetReply() As Boolean
        Dim HU As String = "~HU"
        If BluetoothConnected() Then
            BluetoothPrinter.Write(System.Text.Encoding.UTF8.GetBytes(HU))
        End If
        BluetoothPrinter.ReadTimeout = 3000
        Dim Reply As Byte() = BluetoothPrinter.Read(31)
        If Reply.Length <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function LineToZPL(ByVal LabelLine As LabelLine) As String
        Dim ZPL As String = ""
        Dim TmpDesc As String = ""
        Dim Text1 As String = ""
        Dim Text2 As String = ""
        Dim Btype As String = ""
        Dim AR As String = ""
        Dim Desc As String = LabelLine.Desc
        LabelLine.Price = LabelLine.Price.Replace(" L.L", "")

        If LabelLine.ARDesc.Length > 30 Then
            AR = LabelLine.ARDesc.Substring(1, 30)
        Else
            AR = LabelLine.ARDesc
        End If

        ZPL += "^XA~JS20^XB^MNM^MTD^POI^CI28^LT30^XZ"
        ZPL += "^XA"

        TmpDesc = SplitDesc(Desc, Desc.Length, 31)
        Try
            Text1 = TmpDesc.Substring(0, TmpDesc.LastIndexOf(","))
            Text2 = TmpDesc.Substring(TmpDesc.LastIndexOf(",") + 1)
        Catch ex As Exception

        End Try

        ' Text 1
        If LabelLine.Desc.Length > 0 Then
            ZPL += "^FO30,30^A0,29,31^FD" + Text1 + "^FS"
        End If

        ' Text 2
        If Text2.Length > 0 Then
            ZPL += "^FO30,55^A0,29,31^FD" + Text2 + "^FS"
        End If

        ' Text 3
        If LabelLine.ARDesc.Length > 0 Then
            ZPL += "^FO150,75^CW1,E:TT0003M_.TTF^A134,36^FD" + AR + "^FS"
        End If

        ' Draw Line
        ZPL += "^FO10,115^GB550,0,2^FS"

        ' VAT
        Select Case LabelLine.VATGroup
            Case "G-VAT11"
                ZPL += "^FO" + AlignAmount(LabelLine.Price, 0) + ",123^A0,20,20^FDVAT %:11^FS"
                ZPL += "^FO" + AlignAmount(LabelLine.Price, 40) + ",145^A0,22,22^FDTTC^FS"
            Case "G-NOVAT"
                ZPL += "^FO" + AlignAmount(LabelLine.Price, 0) + ",123^A0,20,20^FDVAT %:0^FS"
                ZPL += "^FO" + AlignAmount(LabelLine.Price, 40) + ",145^A0,22,22^FDTTC^FS"
        End Select

        ' Price
        ZPL += "^FO" + AlignAmount(LabelLine.Price, 0) + ",153,^A0,65,62,^FD" + Cultural(LabelLine.Price, False) + "^FS"

        ' LL
        ZPL += "^FO" + AlignAmount(LabelLine.Price, 40) + ",184^A0,30,30^FDLL^FS"

        ' Mobile Printed identifier
        ZPL += "^FO5,165^GB20,0,5^FS"
        ZPL += "^FO13,155^GB0,25,5^FS"

        ' Barcode
        Btype = GetBarcodeTypeZPL(LabelLine.Barcode, ValidBarcode(LabelLine.Barcode))
        Select Case Btype
            Case "BC"
                ZPL += "^FO32,140^BY1^A0,25,20^" + Btype + ",70,Y^FD" + LabelLine.Barcode + "^FS"
            Case "B9"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.Barcode + "^FS"
            Case "BU"
                ZPL += "^FO32,140^BY1^A0,25,20^" + Btype + ",70,Y^FD" + LabelLine.Barcode + "^FS"
            Case "B8"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.Barcode + "^FS"
            Case "BE"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.Barcode + "^FS"
        End Select

        ' Item No, Variant, Unit Of Measure
        ZPL += "^FO10,247^A0,22,20^FD" + LabelLine.ItemNo + "-" + LabelLine.Var + "-" + LabelLine.UOM + "^FS"

        ' Dolphin
        ZPL += "^FO175,247^A0,22,20^FD" + LabelLine.DolphinNo + "^FS"

        ' Product group
        ZPL += "^FO285,247^A0,22,20^FD" + LabelLine.ProductGroup + "^FS"

        ' Date
        ZPL += "^FO475,247^A0,22,20^FD" + Date.Now.ToShortDateString + "^FS"

        ' Vendor
        ZPL += "^FO402,247^A0,22,20^FD" + LabelLine.Vendor + "^FS"

        ' Quantity
        ZPL += "^PQ" + LabelLine.Quantity.ToString + "^FS^XZ"

        Return ZPL
    End Function
    Private Function LineToZPL2(ByVal LabelLine As PricingJobLines) As String
        Dim ZPL As String = ""
        Dim TmpDesc As String = ""
        Dim Text1 As String = ""
        Dim Text2 As String = ""
        Dim Btype As String = ""
        Dim AR As String = ""
        Dim Desc As String = LabelLine.Description
        Dim Price As String = CStr(LabelLine.NewPrice)

        If LabelLine.ARDesc.Length > 30 Then
            AR = LabelLine.ARDesc.Substring(1, 30)
        Else
            AR = LabelLine.ARDesc
        End If

        ZPL += "^XA~JS20^XB^MNM^MTD^POI^CI28^LT30^XZ"
        ZPL += "^XA"

        TmpDesc = SplitDesc(Desc, Desc.Length, 31)
        Try
            Text1 = TmpDesc.Substring(0, TmpDesc.LastIndexOf(","))
            Text2 = TmpDesc.Substring(TmpDesc.LastIndexOf(",") + 1)
        Catch ex As Exception

        End Try

        ' Text 1
        If LabelLine.Description.Length > 0 Then
            ZPL += "^FO30,30^A0,29,31^FD" + Text1 + "^FS"
        End If

        ' Text 2
        If Text2.Length > 0 Then
            ZPL += "^FO30,55^A0,29,31^FD" + Text2 + "^FS"
        End If

        ' Text 3
        If LabelLine.ARDesc.Length > 0 Then
            ZPL += "^FO150,75^CW1,E:TT0003M_.TTF^A134,36^FD" + AR + "^FS"
        End If

        ' Draw Line
        ZPL += "^FO10,115^GB550,0,2^FS"

        ' VAT
        Select Case LabelLine.VATGroup
            Case "G-VAT11"
                ZPL += "^FO" + AlignAmount(Price, 0) + ",123^A0,20,20^FDVAT %:11^FS"
                ZPL += "^FO" + AlignAmount(Price, 40) + ",145^A0,22,22^FDTTC^FS"
            Case "G-NOVAT"
                ZPL += "^FO" + AlignAmount(Price, 0) + ",123^A0,20,20^FDVAT %:0^FS"
                ZPL += "^FO" + AlignAmount(Price, 40) + ",145^A0,22,22^FDTTC^FS"
        End Select

        ' Price
        ZPL += "^FO" + AlignAmount(Price, 0) + ",153,^A0,65,62,^FD" + Cultural(Price, False) + "^FS"

        ' LL
        ZPL += "^FO" + AlignAmount(Price, 40) + ",184^A0,30,30^FDLL^FS"

        ' Mobile Printed identifier
        ZPL += "^FO5,165^GB20,0,5^FS"
        ZPL += "^FO13,155^GB0,25,5^FS"

        ' Barcode
        Btype = GetBarcodeTypeZPL(LabelLine.BarcodeList, ValidBarcode(LabelLine.BarcodeList))
        Select Case Btype
            Case "BC"
                ZPL += "^FO32,140^BY1^A0,25,20^" + Btype + ",70,Y^FD" + LabelLine.BarcodeList + "^FS"
            Case "B9"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.BarcodeList + "^FS"
            Case "BU"
                ZPL += "^FO32,140^BY1^A0,25,20^" + Btype + ",70,Y^FD" + LabelLine.BarcodeList + "^FS"
            Case "B8"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.BarcodeList + "^FS"
            Case "BE"
                ZPL += "^FO32,140^BY2^A0,15,15^" + Btype + ",70,Y^FD" + LabelLine.BarcodeList + "^FS"
        End Select

        ' Item No, Variant, Unit Of Measure
        ZPL += "^FO10,247^A0,22,20^FD" + LabelLine.ItemNo + "-" + LabelLine.VarCode + "-" + LabelLine.UOM + "^FS"

        ' Dolphin
        ZPL += "^FO175,247^A0,22,20^FD" + LabelLine.DolphinNo + "^FS"

        ' Product group
        ZPL += "^FO285,247^A0,22,20^FD" + LabelLine.ProductGroup + "^FS"

        ' Date
        ZPL += "^FO475,247^A0,22,20^FD" + Date.Now.ToShortDateString + "^FS"

        ' Vendor
        ZPL += "^FO402,247^A0,22,20^FD" + LabelLine.Vendor + "^FS"

        ' Quantity
        ZPL += "^PQ" + LabelLine.Quantity.ToString + "^FS^XZ"

        Return ZPL
    End Function
    Private Function LineToEPL(ByVal Line As Line, ByVal Quantity As String) As String
        Dim EPL As String = ""
        Dim TmpDesc As String = ""
        Dim Text1 As String = ""
        Dim Text2 As String = ""
        Dim Btype As String = ""
        Dim LineEnd As String = CChar(ChrW(13)) + CChar(ChrW(10))

        If Line.Desc.Length <> 0 Then
            TmpDesc = SplitDesc(Line.Desc, Line.Desc.Length, 22)
            Try
                Text1 = TmpDesc.Substring(0, TmpDesc.LastIndexOf(","))
                Text2 = TmpDesc.Substring(TmpDesc.LastIndexOf(",") + 1)
            Catch ex As Exception

            End Try
        End If

        EPL += "N" + LineEnd
        EPL += "ZB" + LineEnd
        If Text1.Length > 0 Then
            EPL += "A20,10,0,2,1,1,N,""" + Text1 + """" + LineEnd
        End If

        Btype = GetBarcodeTypeEPL(Line.BarcodeNo, ValidBarcode(Line.BarcodeNo))
        Select Case Btype
            Case "1"
                If Line.BarcodeNo.Length < 9 Then
                    EPL += "B20,30,0," + Btype + ",2,2,50,B,""" + Line.BarcodeNo + """"
                Else
                    EPL += "B32,30,0," + Btype + ",2,2,50,B,""" + Line.BarcodeNo + """"
                End If
            Case "E80"
                EPL += "B55,40,0," + Btype + ",2,2,60,B,""" + Line.BarcodeNo + """"
            Case "E30"
                EPL += "B35,40,0," + Btype + ",2,2,60,B,""" + Line.BarcodeNo + """"
            Case "UA0"
                EPL += "B35,45,0," + Btype + ",2,2,60,B,""" + Line.BarcodeNo + """"
            Case "UE0"
                EPL += "B35,60,0," + Btype + ",1,2,60,B,""" + Line.BarcodeNo + """"
        End Select
        EPL += LineEnd

        EPL += "P" + Quantity + LineEnd
        EPL += "N" + LineEnd
        EPL += LineEnd

        Return EPL

    End Function
    Private Function AlignAmount(ByVal Lenght As Integer, ByVal Adjustment As Integer) As String
        Dim Align As Integer = 0
        Select Case Lenght
            Case 0 To 9
                Align = 490 - Adjustment
            Case 10 To 99
                Align = 470 - Adjustment
            Case 100 To 999
                Align = 420 - Adjustment
            Case 1000 To 9999
                Align = 380 - Adjustment
            Case 10000 To 99999
                Align = 370 - Adjustment
            Case 100000 To 999999
                Align = 330 - Adjustment
        End Select
        Return CStr(Align)
    End Function
    Private Function SplitDesc(ByVal FullDesc As String, ByVal DescLen As Integer, ByVal Length As Integer) As String
        Dim Text1 As String = ""
        Dim Text2 As String = ""
        Dim Pos As Integer = 0
        If DescLen < Length Then
            Return FullDesc + ","
        Else
            Text1 = FullDesc.Substring(0, Length)
            Pos = Length - 1
            For i As Integer = Length - 1 To 1 Step -1
                If Text1.Substring(i, 1) = " " Then
                    Pos = i
                    Exit For
                End If
            Next
        End If

        Text1 = FullDesc.Substring(0, Pos)
        Text2 = FullDesc.Substring(Pos + 1)
        If Text2.Length >= Length Then
            Text2.Substring(0, Length)
        End If

        Return Text1 + "," + Text2
    End Function
    Private Function GetBarcodeTypeZPL(ByVal Barcode As String, ByVal Valid As Boolean) As String
        Dim Type As String = ""
        If Not Valid Then
            Type = "BC"
        End If
        If Barcode.Substring(0) <> "2" Then
            Select Case Barcode.Length
                Case 8
                    If Barcode.Substring(0, 2) = "00" Then
                        Type = "B8"
                    ElseIf Barcode.Substring(0, 1) = "0" Then
                        Type = "B9"
                    Else
                        If CInt(Barcode.Substring(0, 2)) >= 30 Then
                            Type = "B8"
                        Else
                            Type = "BC"
                        End If
                    End If
                Case 11
                    If Barcode.Substring(0, 1) = "0" Then
                        Type = "BU"
                    Else
                        Type = "BC"
                    End If
                Case 12
                    Type = "BC"
                Case 13
                    If (CInt(Barcode.Substring(0, 2)) >= 30) Or (CInt(Barcode.Substring(0, 2)) <= 19) Then
                        Type = "BE"
                    Else
                        Type = "BC"
                    End If
                Case Else
                    Type = "BC"
            End Select
        ElseIf Barcode.Substring(0) = "2" Then
            If (Barcode.Length = 12) Or (Barcode.Length = 13) Then
                Type = "BE"
            Else
                Type = "BC"
            End If
        End If

        Return Type
    End Function
    Private Function GetBarcodeTypeEPL(ByVal Barcode As String, ByVal Valid As Boolean) As String
        Dim Type As String = ""

        If Not Valid Then
            Type = "1"
        End If

        If Barcode.Substring(0) <> "2" Then
            Select Case Barcode.Length
                Case 8
                    If Barcode.Substring(0, 2) = "00" Then
                        Type = "E80"
                    ElseIf Barcode.Substring(0, 1) = "0" Then
                        Type = "UE0"
                    Else
                        If CInt(Barcode.Substring(0, 2)) >= 30 Then
                            Type = "E80"
                        Else
                            Type = "1"
                        End If
                    End If
                Case 11
                    If Barcode.Substring(0, 1) = "0" Then
                        Type = "UA0"
                    Else
                        Type = "1"
                    End If
                Case 12
                    Type = "1"
                Case 13
                    If (CInt(Barcode.Substring(0, 2)) >= 30) Or (CInt(Barcode.Substring(0, 2)) <= 19) Then
                        Type = "E30"
                    Else
                        Type = "1"
                    End If
                Case Else
                    Type = "1"
            End Select
        ElseIf Barcode.Substring(0) = "2" Then
            If (Barcode.Length = 12) Or (Barcode.Length = 13) Then
                Type = "E30"
            Else
                Type = "1"
            End If
        End If

        Return Type
    End Function
    Private Function TCP_PrintEPL(ByVal IPAddress As String, ByVal Port As String, ByVal EPLCmd As String) As Boolean
        Dim l_EndPoint As System.Net.EndPoint
        Dim l_Socket As System.Net.Sockets.Socket
        l_EndPoint = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(IPAddress), System.Int32.Parse(Port))
        l_Socket = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
        Try
            l_Socket.Connect(l_EndPoint)
            If l_Socket.Connected Then
                l_Socket.Send(System.Text.Encoding.UTF8.GetBytes(EPLCmd))
                Return True
            End If
        Catch ex As Exception
            MessageBox("Check Printer Connection")
            Return False
        Finally
            l_Socket.Close()
        End Try
    End Function
End Module
