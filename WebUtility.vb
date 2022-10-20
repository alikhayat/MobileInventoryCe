Imports System.Net
Module WebUtility
    Public NavIp As String
    Private SoapPort As String, InstanceName As String, NavUsername As String, NavPassword As String, WebDomain As String
    Public Sub WebUtilInialize(ByVal _NavIp As String, ByVal _SoapPort As String, ByVal _InstanceName As String, ByVal _NavUsername As String, _
                               ByVal _NavPassword As String, ByVal _WebDomain As String)
        NavIp = _NavIp
        SoapPort = _SoapPort
        InstanceName = _InstanceName
        NavUsername = _NavUsername
        NavPassword = _NavPassword
        WebDomain = _WebDomain
    End Sub
    Public Function Last_Action() As Integer
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Dim Preaction As Integer
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()
        Try
            If Ping(NavIp, "") Then
                Preaction = Utility.LastActionNo()
            Else
                Preaction = -1
            End If
        Catch ex As Exception
        End Try
        Cursor.Current = Cursors.Default
        Return Preaction
    End Function
    Public Function GetCredentials() As System.Net.NetworkCredential
        Return New System.Net.NetworkCredential(NavUsername, NavPassword, WebDomain)
    End Function
    Public Function GetServiceURL(ByVal Type As Integer, ByVal ObjectID As String) As String
        Dim TypeS As String = String.Empty
        Dim URL As String = String.Empty
        Select Case Type
            Case 5
                TypeS = "Codeunit"
            Case 8
                TypeS = "Page"
            Case 9
                TypeS = "Query"
        End Select
        db.read("[Service Name]", "[Web Service]", String.Format("[Object Type] = '{0}' and [Object ID] = '{1}' and [Published] = '1'", Type, ObjectID))
        Try
            If dr.Read Then
                URL = String.Format("http://{0}:{1}/{2}/WS/{3}/{4}/{5}", NavIp, SoapPort, InstanceName, CompanyName, TypeS, CStr(dr.GetValue(0)))
            End If
        Catch ex As Exception
            MessageBox("Service is not published")
        Finally
            DBClose(True)
        End Try
        Return URL
    End Function
    Public Function GetRetailPrice(ByVal ItemNo As String, ByVal VarCode As String, ByVal UOM As String) As Decimal
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Dim RetailPrice As Decimal
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()
        Try
            RetailPrice = Utility.GetRetailPrice(ItemNo, VarCode, UOM)
        Catch ex As Exception
            RetailPrice = 0
        Finally
            Utility.Dispose()
            Cursor.Current = Cursors.Default
        End Try

        Return RetailPrice
    End Function
    Public Function GetShelf(ByVal Barcode As String) As String
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Info As String
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()
        Try
            Info = Utility.GetShelfLabel(Barcode)
        Catch ex As Exception
            Info = ""
        Finally
            Utility.Dispose()
            Cursor.Current = Cursors.Default
        End Try
        Return Info
    End Function
    Public Function Get_Counters() As String
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Dim Counters As String = ""
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Try
            Counters = Utility.GetDeviceCounters2(DeviceID)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try
        Cursor.Current = Cursors.Default
        Return Counters
    End Function
    Public Function ConfirmTransIN(ByVal OrderNo As String, ByVal Difference As Boolean) As Boolean
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Try
            Return Utility.MarkTransferArrival(Login.UserId, OrderNo, Difference)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try
    End Function
    Public Function Get_TransferInDetails(ByVal OrderNo As String) As String
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Dim OrderDetails As String = ""

        Try
            OrderDetails = Utility.GetTransferOrder(OrderNo)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try

        Return OrderDetails
    End Function
    Public Function Assign_PricingJob(ByVal JobID As String) As String
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Dim Result As String = ""

        Try
            Result = Utility.LabelJobAssign(JobID, DeviceID, Login.UserId)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try

        Return Result
    End Function
    Public Function Complete_PricingJob(ByVal JobID As String, ByVal SessionID As String) As String
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Dim Result As String = ""

        Try
            Result = Utility.LabelJobComplete(JobID, SessionID, DeviceID, Login.UserId)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try

        Return Result
    End Function
    Public Function UnAssign_PricingJob(ByVal JobID As String) As Boolean
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Dim Result As Boolean = False

        Try
            Result = Utility.LabelJobUnassign(JobID, DeviceID, Login.UserId)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try

        Return Result
    End Function
    Public Function BarcodeHasImage(ByVal Barcode As String) As Boolean
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Dim Result As Boolean = False

        Try
            'Result = Utility.LabelJobUnassign(Barcode)
        Catch ex As Exception
        Finally
            Utility.Dispose()
        End Try

        Return Result
    End Function
    Public Function Fetch_JobList() As PricingJobHeaderPage.PricingJobHeaderPage()
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim PricingHeaderAPI As New PricingJobHeaderPage.PricingJobHeaderPage_Service
        Dim PricingHeader As PricingJobHeaderPage.PricingJobHeaderPage() = Nothing
        PricingHeaderAPI.Url = GetServiceURL(8, "50038")
        PricingHeaderAPI.Credentials = GetCredentials()
        PricingHeaderAPI.SoapVersion = Get_SoapVersion()

        PricingHeader = PricingHeaderAPI.ReadMultiple(Nothing, Nothing, 0)

        Return PricingHeader
    End Function
    Public Function RetreivePricigJobLines(ByVal JobID As String) As PricingJobLines()
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim PricingLinesService As PricingJobLinePage.PricingJobLinePage_Service = New PricingJobLinePage.PricingJobLinePage_Service
        Dim Filter As PricingJobLinePage.PricingJobLinePage_Filter = New PricingJobLinePage.PricingJobLinePage_Filter
        Dim Index As Integer = 0
        Dim PriceingJobLines(0) As PricingJobLines

        PricingLinesService.Url = GetServiceURL(8, "50028")
        PricingLinesService.Credentials = GetCredentials()
        PricingLinesService.SoapVersion = Get_SoapVersion()

        Filter.Field = PricingJobLinePage.PricingJobLinePage_Fields.Job_No
        Filter.Criteria = JobID
        
        Dim PricingJobLines As PricingJobLinePage.PricingJobLinePage() = PricingLinesService.ReadMultiple(New PricingJobLinePage.PricingJobLinePage_Filter() {Filter}, Nothing, 0)
        Try
            For Each PricingLine As PricingJobLinePage.PricingJobLinePage In PricingJobLines
                If PricingLine.Job_No <> String.Empty Or PricingLine.Job_No <> Nothing Then
                    ReDim Preserve PriceingJobLines(Index)
                    PriceingJobLines(Index).JodNo = PricingLine.Job_No
                    PriceingJobLines(Index).LineNo = PricingLine.Line_No
                    PriceingJobLines(Index).ItemNo = PricingLine.Item_No
                    PriceingJobLines(Index).VarCode = PricingLine.Variant_Code
                    PriceingJobLines(Index).UOM = PricingLine.Unit_of_Measure
                    PriceingJobLines(Index).NewPrice = PricingLine.New_Price
                    PriceingJobLines(Index).OldPrice = PricingLine.Old_Price
                    PriceingJobLines(Index).Description = PricingLine.Description
                    PriceingJobLines(Index).ARDesc = PricingLine.Arabic_Description
                    PriceingJobLines(Index).BarcodeList = PricingLine.Barcode_List
                    If PricingLine.Scale_Item = True Then
                        PriceingJobLines(Index).ScaleItem = 1
                    Else
                        PriceingJobLines(Index).ScaleItem = 0
                    End If

                    PriceingJobLines(Index).ReasonCode = PricingLine.Reason_Code

                    Index += 1
                End If
            Next
        Catch ex As Exception

        Finally
            PricingLinesService.Dispose()
        End Try

        Return PriceingJobLines
    End Function
    Public Sub Update_ReasonCodes(ByVal JobNo As String, ByVal LineNo() As Integer, ByVal ReasonCodes() As String)
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim PricingLinesService As PricingJobLinePage.PricingJobLinePage_Service = New PricingJobLinePage.PricingJobLinePage_Service
        Dim Job(0) As PricingJobLinePage.PricingJobLinePage

        PricingLinesService.Url = GetServiceURL(8, "50028")
        PricingLinesService.Credentials = GetCredentials()
        PricingLinesService.SoapVersion = Get_SoapVersion()

        For i As Integer = 0 To LineNo.Length - 1
            ReDim Preserve Job(i)
            Job(i) = PricingLinesService.Read(JobNo, LineNo(i))
            Job(i).Reason_Code = ReasonCodes(i)
            PricingLinesService.UpdateMultiple(Job)
        Next
    End Sub
    Public Function ImplementPricingJobLine(ByVal JobNo As String, ByVal LineNo As Integer) As Decimal
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
        Dim Utility As New HandheldUtilCU.HandheldUtilCU
        Utility.Url = GetServiceURL(5, "50021")
        Utility.Credentials = GetCredentials()
        Utility.SoapVersion = Get_SoapVersion()

        Try
            Dim NewPrice As Decimal = Utility.LabelJobLineImplement(JobNo, LineNo)

            Return NewPrice
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function Get_SoapVersion() As Web.Services.Protocols.SoapProtocolVersion
        Return Web.Services.Protocols.SoapProtocolVersion.Default
    End Function
    Public NotInheritable Class AcceptAllCertificatePolicy
        Implements ICertificatePolicy

        Private Const CERT_E_UNTRUSTEDROOT As UInteger = 2048

        Public Function CheckValidationResult1(ByVal srvPoint As System.Net.ServicePoint, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal request As System.Net.WebRequest, ByVal certificateProblem As Integer) As Boolean Implements System.Net.ICertificatePolicy.CheckValidationResult
            Return True
        End Function
    End Class
End Module
