Imports System.Threading
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports Dc.SessionHeaderPage

Public Class PostLabels
    Dim SessionHeader As New SessionHeaderPage_Service
    Dim SessionLabelLine As New SessionLabelLinePage.SessionLabelLinePage_Service
    Dim Cred = GetCredentials()
    Shared UnConfirmedJobs As Integer = 0
    Dim PricingJobs() As String

    Public Sub postSessions(ByVal Sessions() As String, ByVal PricingJobs() As String)
        Me.PricingJobs = PricingJobs
        Sessions = CheckForUnsyncedSessions(Sessions)

        'Set web services properties
        'Accept all web Certificates
        System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy

        SessionHeader.Url = GetServiceURL(8, "50004")
        SessionHeader.Credentials = Cred
        SessionHeader.SoapVersion = Get_SoapVersion()

        SessionLabelLine.Url = GetServiceURL(8, "50005")
        SessionLabelLine.Credentials = Cred
        SessionLabelLine.SoapVersion = Get_SoapVersion()

        'If Ping(NavIp, "Cannot connect to NAV server") = True Then
        Dim Counter As Integer = 0
        UnConfirmedJobs = 0
        For Each ID As String In Sessions
            Dim Job As SessionJob = New SessionJob(ID, SessionHeader, SessionLabelLine, Me.PricingJobs(Counter))
            Job.Post()
            Counter += 1
        Next
        If UnConfirmedJobs > 0 Then
            Cursor.Current = Cursors.Default
            MessageBox(String.Format("Unable to confirm {0} Pricing Jobs", UnConfirmedJobs))
        End If
        'End If

        DBClose(True)
    End Sub
    Private Function CheckForUnsyncedSessions(ByVal Sessions() As String) As String()
        Dim i As Integer = 0

        If Not Sessions.Length = -1 Then
            i = Sessions.Length
        End If

        db.read("[ID]", "[Session Header]", "([Type Of Transaction] = 0 or [Type Of Transaction] = 1) and [Replicated] = 0 and [Printed] = 1")
        Try
            While dr.Read
                ReDim Preserve Sessions(i)
                Sessions(i) = dr.GetValue(0)

                ReDim Preserve PricingJobs(i)
                PricingJobs(i) = ""

                i += 1
            End While
        Catch ex As Exception
        Finally
            DBClose(True)
        End Try
        Return Sessions
    End Function
    Private Class SessionJob
        Private SessionID As String
        Private HeaderPosted As Boolean
        Private LinesPosted As Boolean
        Private Header_service As SessionHeaderPage_Service
        Private line_service As SessionLabelLinePage.SessionLabelLinePage_Service
        Private Header As New Dc.SessionHeaderPage.SessionHeaderPage
        Private Lines() As SessionLabelLinePage.SessionLabelLinePage
        Private PricingJobID As String
        Dim EmptyLines As Boolean = False
        'Constructor
        Public Sub New(ByVal ID As String, ByVal Header_Service As SessionHeaderPage_Service, ByVal Line_Service As SessionLabelLinePage.SessionLabelLinePage_Service, ByVal _PricingJobID As String)
            Me.SessionID = ID
            Me.Header_service = Header_Service
            Me.line_service = Line_Service
            Me.PricingJobID = _PricingJobID
        End Sub
        Public Sub Post()
            FillHeader()
            PostHeader()

            If HeaderPosted = True Then
                FillLines()
                PostLines()
                If LinesPosted = True Then
                    If Reconsile(SessionLineCount) = True Then
                        If PricingJobID <> "" Then
                            Get_UpdateReasonCodes()
                            Dim ConfirmResult As Integer = ConfirmPricingJob()
                            If ConfirmResult = 1 Then
                                UnConfirmedJobs += 1
                            ElseIf ConfirmResult = 2 Then
                                UnConfirmedJobs += 1
                                Header = Header_service.Read(SessionID, Login.UserId, Store, DeviceID)
                                Header_service.Delete(Header.Key)
                                Dim Count As Integer = Get_LinesCount(SessionID)
                                Dim Z As Integer = 0
                                For q As Integer = 1 To Count
                                    'Get Line(z) Data
                                    db.read("*", "[Session Label Line]", String.Format("[Session ID] = '{0}' and [Line No.] = '{1}'", SessionID, q))
                                    Z = q - 1
                                    If dr.Read Then
                                        Lines(Z) = line_service.Read(dr.GetValue(0), Login.UserId, Store, DeviceID, dr.GetValue(4))
                                        line_service.Delete(Lines(Z).Key)
                                    End If
                                Next
                                DBClose(True)
                                Return
                            End If
                        End If
                        Set_Replicated(SessionID)
                        Delete_HeaderData(SessionID)
                        Delete_LineData(SessionID)
                        If PricingJobID <> "" Then
                            Delete_UnscannedLines(PricingJobID)
                        End If
                    Else
                        Header = Header_service.Read(SessionID, Login.UserId, Store, DeviceID)
                        Header_service.Delete(Header.Key)

                        Dim Filter() As SessionLabelLinePage.SessionLabelLinePage_Filter
                        ReDim Preserve Filter(0)
                        Filter(0) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                        Filter(0).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Session_ID
                        Filter(0).Criteria = SessionID
                        ReDim Preserve Filter(1)
                        Filter(1) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                        Filter(1).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.User_ID
                        Filter(1).Criteria = Login.UserId
                        ReDim Preserve Filter(2)
                        Filter(2) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                        Filter(2).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Store_No
                        Filter(2).Criteria = Store
                        ReDim Preserve Filter(3)
                        Filter(3) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                        Filter(3).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Device_ID
                        Filter(3).Criteria = DeviceID

                        Lines = line_service.ReadMultiple(Filter, Nothing, 0)
                        For i As Integer = 0 To Lines.Length - 1
                            line_service.Delete(Lines(i).Key)
                        Next
                        MessageBox("Invalid attempt, try again")
                        Return
                    End If
                    'Set_Replicated(SessionID)
                    'Delete_HeaderData(SessionID)
                    'Delete_LineData(SessionID)
                    'If PricingJobID <> String.Empty Then
                    '    Delete_JobLines(PricingJobID)
                    'End If
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
                If EmptyLines Then
                    LinesPosted = True
                    Exit Sub
                Else
                    line_service.CreateMultiple(Lines)
                End If

                LinesPosted = True
            Catch ex As Exception
                Header = Header_service.Read(SessionID, Login.UserId, Store, DeviceID)
                Header_service.Delete(Header.Key)

                If ex.ToString.Contains("already exists") Then
                    Dim Filter() As SessionLabelLinePage.SessionLabelLinePage_Filter
                    ReDim Preserve Filter(0)
                    Filter(0) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                    Filter(0).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Session_ID
                    Filter(0).Criteria = ""
                    ReDim Preserve Filter(1)
                    Filter(1) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                    Filter(1).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.User_ID
                    Filter(1).Criteria = ""
                    ReDim Preserve Filter(2)
                    Filter(2) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                    Filter(2).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Store_No
                    Filter(2).Criteria = ""
                    ReDim Preserve Filter(3)
                    Filter(3) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                    Filter(3).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Device_ID
                    Filter(3).Criteria = ""
                    ReDim Preserve Filter(4)
                    Filter(4) = New SessionLabelLinePage.SessionLabelLinePage_Filter
                    Filter(4).Field = SessionLabelLinePage.SessionLabelLinePage_Fields.Line_No
                    Filter(4).Criteria = "0"

                    Lines = line_service.ReadMultiple(Filter, Nothing, 0)
                    For i As Integer = 0 To Lines.Length - 1
                        line_service.Delete(Lines(i).Key)
                    Next
                    MessageBox("Invalid attempt, try again")
                    Return
                End If
                LinesPosted = False                
            End Try
        End Sub
        Private Function ConfirmPricingJob() As Integer
            Dim Result As String = Complete_PricingJob(PricingJobID, SessionID)
            If Result.Substring(0, 1) = "0" Then
                Return 0
            ElseIf Result.Substring(0, 1) = "1" Then
                Return 1
            ElseIf Result.Substring(0, 1) = "2" Then
                Return 2
            End If
        End Function
        Private Sub FillHeader()
            'Get Header data
            Dim TOT As Type_Of_Transaction
            Dim UTCDate As DateTime
            db.read("*", "[Session Header]", String.Format("ID = '{0}'", SessionID))
            Try
                If dr.Read Then
                    Header.ID = dr.GetValue(0).ToString
                    Header.User_ID = dr.GetValue(1).ToString
                    Header.Store_No = dr.GetValue(2).ToString
                    Header.Device_ID = dr.GetValue(3).ToString
                    Header.Type_Of_TransactionSpecified = True
                    If dr.GetValue(4).ToString = "0" Then
                        TOT = Dc.SessionHeaderPage.Type_Of_Transaction.Shelf
                    Else
                        TOT = Dc.SessionHeaderPage.Type_Of_Transaction.Item
                    End If
                    Header.Brand_NameSpecified = True
                    If dr.GetValue(8).ToString <> "0" Then
                        If dr.GetValue(8).ToString = "1" Then
                            Header.Brand_Name = Brand_Name.Redy
                        Else
                            Header.Brand_Name = Brand_Name.Bsat
                        End If
                    Else
                        Header.Brand_Name = Brand_Name._blank_
                    End If
                    Header.Type_Of_Transaction = TOT
                    Header.DateSpecified = True
                    UTCDate = CDate(dr.GetValue(5)).ToUniversalTime
                    UTCDate = DateTime.SpecifyKind(UTCDate, DateTimeKind.Unspecified)
                    Header.Date = UTCDate
                    Header.Label_Code = dr.GetValue(7).ToString
                    Header.PrintedSpecified = True
                    Header.Printed = CInt(dr.GetValue(9))
                    Header.Pricing_Job_No = dr.GetValue(10)
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub FillLines()
            Try
                Dim Z As Integer = 0
                'Get Session Lines count
                Dim Count As Integer = Get_LinesCount(SessionID)
                Dim UTCDate As DateTime

                'inialize Lines
                If Count = 0 Then
                    EmptyLines = True
                    Exit Sub
                Else
                    ReDim Preserve Lines(Count - 1)
                End If


                For q As Integer = 1 To Count

                    'Get Line(z) Data
                    db.read("*", "[Session Label Line]", String.Format("[Session ID] = '{0}' and [Line No.] = '{1}'", SessionID, q))

                    Z = q - 1
                    Lines(Z) = New SessionLabelLinePage.SessionLabelLinePage

                    If dr.Read Then
                        Lines(Z).Session_ID = dr.GetValue(0).ToString
                        Lines(Z).Line_NoSpecified = True
                        Lines(Z).User_ID = dr.GetValue(1).ToString
                        Lines(Z).Store_No = dr.GetValue(2).ToString
                        Lines(Z).Device_ID = dr.GetValue(3).ToString
                        Lines(Z).Line_No = dr.GetValue(4).ToString
                        Lines(Z).Label_Code = dr.GetValue(5).ToString
                        Lines(Z).Barcode_No = dr.GetValue(6).ToString
                        Lines(Z).Description = dr.GetValue(7).ToString
                        Lines(Z).QuantitySpecified = True
                        Lines(Z).Quantity = dr.GetValue(8).ToString
                        Lines(Z).Item_No = dr.GetValue(9).ToString
                        Lines(Z).Unit_Of_Measure = dr.GetValue(10).ToString
                        Lines(Z).Variant = dr.GetValue(11).ToString
                        Lines(Z).Text_1 = dr.GetValue(12).ToString
                        Lines(Z).Text_2 = dr.GetValue(13).ToString
                        Lines(Z).Text_3 = dr.GetValue(14).ToString

                        ' check if date is specified
                        If dr.GetValue(15).ToString <> "" Then
                            Lines(Z).Packed_DateSpecified = True
                            UTCDate = CDate(dr.GetValue(15))
                            UTCDate = DateTime.SpecifyKind(UTCDate, DateTimeKind.Utc)
                            Lines(Z).Packed_Date = UTCDate
                        Else
                            Lines(Z).Packed_DateSpecified = False
                        End If
                        If dr.GetValue(16).ToString <> "" Then
                            Lines(Z).Expiry_DateSpecified = True
                            UTCDate = CDate(dr.GetValue(16))
                            UTCDate = DateTime.SpecifyKind(UTCDate, DateTimeKind.Utc)
                            Lines(Z).Expiry_Date = UTCDate
                        Else
                            Lines(Z).Expiry_DateSpecified = False
                        End If
                        Lines(Z).PrintedSpecified = True
                        If dr.GetValue(18) = "1" Then
                            Lines(Z).Printed = True
                            Lines(Z).Date_Last_PrintedSpecified = True
                            Lines(Z).Time_Last_PrintedSpecified = True
                            Lines(Z).Date_Last_Printed = CDate(dr.GetValue(19)).ToShortDateString
                            UTCDate = CDate(dr.GetValue(20))
                            UTCDate = DateTime.SpecifyKind(UTCDate, DateTimeKind.Utc)
                            Lines(Z).Time_Last_Printed = UTCDate.ToShortTimeString
                        Else
                            Lines(Z).Printed = False
                            Lines(Z).Date_Last_PrintedSpecified = False
                            Lines(Z).Time_Last_PrintedSpecified = False
                        End If

                        Lines(Z).Time_ScannedSpecified = True
                        UTCDate = CDate(dr.GetValue(17)).ToUniversalTime
                        UTCDate = DateTime.SpecifyKind(UTCDate, DateTimeKind.Unspecified)
                        Lines(Z).Time_Scanned = UTCDate
                    End If
                Next
            Catch ex As Exception

            End Try
        End Sub
        Private Function Get_LinesCount(ByVal sessID As String) As Integer
            Try
                Dim i As Integer = 0
                db.read("Max([Line No.]) as Count", "[Session Label Line]", String.Format("[Session ID] = '{0}'", sessID))
                If dr.Read Then
                    i = Convert.ToInt32(dr.GetValue(0).ToString)
                    Return i
                End If
            Catch ex As Exception
            End Try
        End Function
        Private Sub Get_UpdateReasonCodes()
            Dim LineNo(0) As Integer
            Dim ReasonCode(0) As String
            Dim ReasonCodesFound As Boolean = False
            Dim I As Integer = 0
            db.read("[Line No.],[Reason Code]", "[Pricing Job Lines]", String.Format("[Job No.] = '{0}' AND [Reason Code] <> '{1}'", PricingJobID, String.Empty))

            While dr.Read
                ReasonCodesFound = True
                ReDim Preserve LineNo(I)
                ReDim Preserve ReasonCode(I)
                LineNo(I) = dr.GetValue(0)
                ReasonCode(I) = dr.GetValue(1)
                I += 1
            End While

            DBClose(True)

            If ReasonCodesFound Then
                Update_ReasonCodes(PricingJobID, LineNo, ReasonCode)
            End If
        End Sub
        Private Sub Set_Replicated(ByVal SessID As String)
            db.Update("[Session Header]", "Replicated = '1'", String.Format("[ID] = '{0}'", SessID.ToString))
        End Sub
        Private Sub Delete_HeaderData(ByVal SessID As String)
            db.Delete("[Session Header]", String.Format("ID = '{0}'", SessID))
        End Sub
        Private Sub Delete_LineData(ByVal SessID As String)
            db.Delete("[Session Label Line]", String.Format("[Session ID] = '{0}'", SessID))
        End Sub
        Private Sub Delete_UnscannedLines(ByVal SessID As String)
            db.Delete("[Pricing Job Lines]", String.Format("[Job No.] = '{0}'", SessID))
        End Sub
        Private Function Reconsile(ByVal LinesCount As Integer) As Boolean
            System.Net.ServicePointManager.CertificatePolicy = New AcceptAllCertificatePolicy
            'Dim Filter() As SessionHeaderPage.SessionHeaderPage_Filter

            'ReDim Preserve Filter(1)
            'Filter(0) = New SessionHeaderPage.SessionHeaderPage_Filter
            'Filter(0).Field = SessionHeaderPage_Fields.ID
            'Filter(0).Criteria = SessionID
            'ReDim Preserve Filter(1)
            'Filter(1) = New SessionHeaderPage.SessionHeaderPage_Filter
            'Filter(1).Field = SessionHeaderPage_Fields.User_ID
            'Filter(1).Criteria = Login.UserId
            'ReDim Preserve Filter(2)
            'Filter(2) = New SessionHeaderPage.SessionHeaderPage_Filter
            'Filter(2).Field = SessionHeaderPage_Fields.Store_No
            'Filter(2).Criteria = Store
            'ReDim Preserve Filter(3)
            'Filter(3) = New SessionHeaderPage.SessionHeaderPage_Filter
            'Filter(3).Field = SessionHeaderPage_Fields.Device_ID
            'Filter(3).Criteria = DeviceID

            Dim Head As SessionHeaderPage.SessionHeaderPage = Header_service.Read(SessionID, Login.UserId, Store, DeviceID)
            If Head.No_of_Lines = LinesCount Then
                Return True
            Else
                Return False
            End If
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
        Private Function SessionLineCount() As Integer
            Dim Count As Integer = 0
            db.read("*", "[Session Label Line]", String.Format("[Session ID] = '{0}'", SessionID))
            While dr.Read
                Count += 1
            End While
            DBClose(False)
            Return Count
        End Function
    End Class
End Class

