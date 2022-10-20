Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Public Class PostPR
    Private PRH As New PRHead.PRHeadAPI_Service
    Private PRL As New PRLine.PRLineAPI_Service
    Private HandHeldUtil As New HandheldUtilCU.HandheldUtilCU

    Dim Cred = GetCredentials()
    Public Sub postSessions(ByVal Sessions() As String, ByVal Post As Boolean, ByVal Code As String, Optional ByVal Print As Boolean = False)
        'If NTPretrieved = False Then
        '    AdjustTime()
        'End If
        'Set web services properties
        'Accept all web Certificates
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy

        PRH.Url = GetServiceURL(8, "50033")
        PRH.Credentials = Cred
        PRH.SoapVersion = Get_SoapVersion()

        PRL.Url = GetServiceURL(8, "50034")
        PRL.Credentials = Cred
        PRL.SoapVersion = Get_SoapVersion()

        HandHeldUtil.Url = GetServiceURL(5, "50021")
        HandHeldUtil.Credentials = Cred
        HandHeldUtil.SoapVersion = Get_SoapVersion()

        'If Ping(NavIp, "Cannot connect to NAV server") = True Then
        For Each ID As String In Sessions
            Dim Job As SessionJob = New SessionJob(ID, PRH, PRL, HandHeldUtil, Code, Print)
            Job.Send(Post)
        Next
        'End If

        DBClose(True)
    End Sub
    Private Class SessionJob
        Private SessionID As String
        Private HeaderPosted As Boolean
        Private LinesPosted As Boolean
        Private Header_service As PRHead.PRHeadAPI_Service
        Private line_service As PRLine.PRLineAPI_Service
        Private Header As New PRHead.PRHeadAPI
        Private Lines() As PRLine.PRLineAPI
        Private HandHeldUtil As New HandheldUtilCU.HandheldUtilCU
        Private Code As String
        Private Print As Boolean

        'Constructor
        Public Sub New(ByVal ID As String, ByVal Header_Service As PRHead.PRHeadAPI_Service, ByVal Line_Service As PRLine.PRLineAPI_Service, ByVal HandHeldUtil As HandheldUtilCU.HandheldUtilCU, ByVal Code As String, ByVal Print As Boolean)
            Me.SessionID = ID
            Me.Header_service = Header_Service
            Me.line_service = Line_Service
            Me.HandHeldUtil = HandHeldUtil
            Me.Code = Code
            Me.Print = Print
        End Sub
        Public Sub Send(ByVal Post As Boolean)
            FillHeader()
            PostHeader()

            If HeaderPosted = True Then
                FillLines()
                PostLines()
                If LinesPosted = True Then
                    If Reconsile(SessionLineCount) = True Then
                        If PRConfirm() Then
                            If Post Then
                                If Not PRPost() Then
                                    MessageBox("Error posting PR Header " + SessionID)
                                End If
                            End If
                        Else
                            MessageBox("Error confirming PR Header " + SessionID)
                        End If
                        Delete_HeaderData(SessionID)
                        Delete_LineData(SessionID)
                    Else
                        Header = Header_service.Read(Store + SessionID)
                        Header_service.Delete(Header.Key)

                        Dim Filter As PRLine.PRLineAPI_Filter = New PRLine.PRLineAPI_Filter

                        Filter.Field = PRLine.PRLineAPI_Fields.Document_No
                        Filter.Criteria = Store + SessionID

                        Lines = line_service.ReadMultiple(New PRLine.PRLineAPI_Filter() {Filter}, Nothing, 0)
                        For i As Integer = 0 To Lines.Length - 1
                            line_service.Delete(Lines(i).Key)
                        Next
                        MessageBox("Invalid attempt, try again")
                        Return
                    End If
                Else
                    MessageBox("Some or all lines failed to post")
                End If
            Else
                MessageBox("Some or all headers failed to post")
            End If
        End Sub
        Private Sub PostHeader()
            Try
                Header_service.Create(Header)
                HeaderPosted = True
            Catch ex As Exception
                If ex.ToString.Contains("already exists") Then
                    HeaderPosted = True
                Else
                    HeaderPosted = RetryCreate()
                End If
            End Try
        End Sub
        Private Sub PostLines()
            Try
                line_service.CreateMultiple(Lines)
                LinesPosted = True
            Catch ex As Exception
                Header = Header_service.Read(Store + SessionID)
                Header_service.Delete(Header.Key)
                LinesPosted = False
            End Try
        End Sub
        Private Function PRConfirm() As Boolean
            Try
                Return HandHeldUtil.ConfirmPickingReceiving(Store + SessionID)
            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Function PRPost() As Boolean
            Try
                If Code = "3" Then
                    Return HandHeldUtil.PostPickingReceiving(Store + SessionID)
                ElseIf Code = "5" Then
                    Return HandHeldUtil.PostTransOut(Store + SessionID, Print)
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Sub FillHeader()
            'Get Header data
            'Dim TOT As Type_Of_Transaction
            Dim UTCDate As DateTime
            db.read("*", "[P/R Header]", String.Format("[No.] = '{0}'", SessionID))
            Try
                If dr.Read Then
                    Header.No = Store + dr.GetValue(0).ToString
                    If Code = "3" Then
                        Header.ReceivingSpecified = True
                        Header.Receiving = dr.GetValue(9)
                        Header.PickingSpecified = False
                    ElseIf Code = "5" Then
                        Header.PickingSpecified = True
                        Header.Picking = dr.GetValue(8)
                        Header.ReceivingSpecified = False
                    End If

                    Header.Counting_TypeSpecified = True
                    Header.Counting_Type = dr.GetValue(5)
                    Header.Reference_No = dr.GetValue(6)
                    Header.TypeSpecified = True
                    Header.Type = dr.GetValue(2)
                    Header.Store = dr.GetValue(11)
                    Header.RF_ID = dr.GetValue(12)
                    Header.RF_Start_TimeSpecified = True
                    Header.RF_End_TimeSpecified = True
                    Header.RF_StatusSpecified = True
                    UTCDate = CDate(dr.GetValue(14)).ToUniversalTime
                    Header.RF_Start_Time = UTCDate
                    UTCDate = CDate(dr.GetValue(15)).ToUniversalTime
                    Header.RF_End_Time = UTCDate
                    If dr.GetValue(21) = Nothing Then
                        Header.Expected_DateSpecified = False
                    Else
                        Header.Expected_DateSpecified = True
                        Header.Expected_Date = dr.GetValue(21)
                    End If
                    Header.Inventory_Terminal_Assigned = dr.GetValue(16)
                    Header.RF_Status = PRHead.RF_Status.Finished
                    Header.Location = dr.GetValue(10)
                    Header.Counted_DateSpecified = True
                    Header.Counted_Date = dr.GetValue(3)
                    Header.StatusSpecified = True
                    Header.Status = dr.GetValue(1)
                    Header.Vendor_Invoice_No = dr.GetValue(20)
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub FillLines()
            Dim UTCDate As DateTime
            Try
                Dim Z As Integer = 0

                db.read("*", "[P/R Line]", String.Format("[Document No.] = '{0}'", SessionID))

                While dr.Read
                    ReDim Preserve Lines(Z)
                    Lines(Z) = New PRLine.PRLineAPI
                    Lines(Z).Document_No = Store + dr.GetValue(0)
                    Lines(Z).Line_NoSpecified = True
                    Lines(Z).Line_No = dr.GetValue(1)
                    Lines(Z).Barcode = dr.GetValue(5)
                    'Lines(Z).Item_No = dr.GetValue(2)

                    Lines(Z).Vendor_Item_No = dr.GetValue(12)
                    'Lines(Z).Variant_code = dr.GetValue(4)
                    Lines(Z).Description = dr.GetValue(3)
                    Lines(Z).QuantitySpecified = True
                    Lines(Z).Quantity = dr.GetValue(6)
                    Lines(Z).Unit_of_Measure_Code = dr.GetValue(7)
                    Lines(Z).Reason_Code = ""
                    Lines(Z).Handheld_User = dr.GetValue(16)
                    Lines(Z).Handheld_Start_TimeSpecified = True
                    UTCDate = CDate(dr.GetValue(17)).ToUniversalTime
                    Lines(Z).Handheld_Start_Time = UTCDate
                    Lines(Z).New_ItemSpecified = True
                    Lines(Z).New_Item = dr.GetValue(19)
                    Lines(Z).New_Description = dr.GetValue(21)
                    Lines(Z).Qty_Per_Base_Comp_UnitSpecified = True
                    Lines(Z).Qty_Per_Base_Comp_Unit = dr.GetValue(22)
                    Lines(Z).Base_Comp_Unit = dr.GetValue(23)
                    Lines(Z).Weight_ItemSpecified = False
                    Lines(Z).Weight_Item = False
                    Lines(Z).Packaging_WeightSpecified = True
                    Lines(Z).Packaging_Weight = dr.GetValue(25)
                    Lines(Z).Total_WeightSpecified = True
                    Lines(Z).Total_Weight = dr.GetValue(26)
                    Lines(Z).Entered_Quantity_1Specified = True
                    Lines(Z).Entered_Quantity_1 = dr.GetValue(27)
                    Lines(Z).Entered_Quantity_2Specified = True
                    Lines(Z).Entered_Quantity_2 = dr.GetValue(28)
                    Lines(Z).PrintedSpecified = True
                    Lines(Z).Printed = dr.GetValue(30)
                    Lines(Z).Printed_QuantitySpecified = True
                    Lines(Z).Printed_Quantity = dr.GetValue(31)
                    If dr.GetValue(32) = "0" Then
                        Lines(Z).Purchase_PackSpecified = False
                    Else
                        Lines(Z).Purchase_PackSpecified = True
                        Lines(Z).Purchase_Pack = dr.GetValue(32)
                    End If
                    Lines(Z).Scanned_Unit_Of_Measure = dr.GetValue(34)
                    Lines(Z).Qty_Per_Scanned_UnitSpecified = True
                    Lines(Z).Qty_Per_Scanned_Unit = dr.GetValue(35)
                    Lines(Z).Scanned_Unit_QuantitySpecified = True
                    Lines(Z).Scanned_Unit_Quantity = dr.GetValue(36)

                    Z += 1
                End While
            Catch ex As Exception

            End Try
        End Sub
        Private Function Get_LinesCount(ByVal sessID As String) As Integer
            Try
                Dim i As Integer = 0
                db.read("Max([Line No.]) as Count", "[P/R Line]", String.Format("[Document No.] = '{0}'", sessID))
                If dr.Read Then
                    i = Convert.ToInt32(dr.GetValue(0).ToString)
                    Return i
                End If
            Catch ex As Exception
            End Try
        End Function
        Private Sub Delete_HeaderData(ByVal SessID As String)
            db.Delete("[P/R Header]", String.Format("[No.] = '{0}'", SessID))
        End Sub
        Private Sub Delete_LineData(ByVal SessID As String)
            db.Delete("[P/R Line]", String.Format("[Document No.] = '{0}'", SessID))
        End Sub
        Private Function Reconsile(ByVal LinesCount As Integer) As Boolean
            System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
            'Dim Filter As PRLine.PRLineAPI_Filter = New PRLine.PRLineAPI_Filter

            'Filter.Field = PRLine.PRLineAPI_Fields.Document_No
            'Filter.Criteria = SessionID

            Dim Head As PRHead.PRHeadAPI = Header_service.Read(Store + SessionID)
            If Head.No_of_Lines = LinesCount Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Function SessionLineCount() As Integer
            Dim Count As Integer = 0
            db.read("*", "[P/R Line]", String.Format("[Document No.] = '{0}'", SessionID))
            While dr.Read
                Count += 1
            End While
            DBClose(False)
            Return Count
        End Function
        'Private Function ModifyRecord() As Boolean
        '    Try
        '        Header_service.Update(Header)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'End Function
        Private Function RetryCreate() As Boolean
            Try
                Header_service.Create(Header)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Class

