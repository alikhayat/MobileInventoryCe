Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Runtime.InteropServices
Imports OpenNETCF.Net.NetworkInformation
Imports OpenNETCF.Net
Imports OpenNETCF.WindowsCE
Imports Microsoft.Win32
Imports Symbol.Fusion
Imports Symbol.Fusion.WLAN
Imports System.Threading
Imports System.Threading.Timer

Public Module DeviceUtility
    Public time As DateTime
    Public DeviceID As String = ""
    Public NTPretrieved As Boolean
    
    Public Sub AdjustTime()
        Try
            time = GetNetworkTime(NavIp)
            Microsoft.VisualBasic.DateString = time.ToShortDateString
            Microsoft.VisualBasic.TimeOfDay = time.ToShortTimeString
        Catch ex As Exception
            NTPretrieved = False
        End Try
        time = Microsoft.VisualBasic.TimeOfDay
    End Sub
    Public Sub AdjustTimezone()
        Dim tzc As TimeZoneCollection = New TimeZoneCollection()
        Dim ListBox As New ListBox
        Dim tzi As TimeZoneInformation

        Try
            tzc.Initialize()

            For Each TZ As TimeZoneInformation In tzc
                ListBox.Items.Add(TZ)
            Next
            ListBox.SelectedIndex = 50
            If ListBox.SelectedItem.ToString <> "(GMT+02:00) Beirut" Then
                For i = 0 To ListBox.Items.Count - 1
                    ListBox.SelectedIndex = i
                    If ListBox.Text = "(GMT+02:00) Beirut" Then
                        Exit For
                    End If
                Next
            End If
            tzi = CType(ListBox.SelectedItem, TimeZoneInformation)
            
            DateTimeHelper.SetTimeZoneInformation(tzi)
        Catch ex As Exception
        Finally
            ListBox.Dispose()
            tzc.Clear()
        End Try

    End Sub
    Private Function GetNetworkTime(ByVal ntpServer As String) As DateTime
        If Ping(ntpServer, "Cannot update time from server") Then
            Dim NTPtime As DateTime
            Dim address As IPAddress = IPAddress.Parse(ntpServer)
            If address Is Nothing Then Throw New ArgumentException("Could not resolve ip address from '" & ntpServer & "'.", "ntpServer")
            Dim ep As IPEndPoint = New IPEndPoint(address, 123)
            NTPtime = GetNetworkTime(ep)
            NTPretrieved = True
            Return NTPtime
        Else
            NTPretrieved = False
            Return Microsoft.VisualBasic.TimeOfDay
        End If
    End Function
    Private Function GetNetworkTime(ByVal ep As IPEndPoint) As DateTime
        Dim s As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        s.Connect(ep)
        Dim ntpData As Byte() = New Byte(47) {}
        ntpData(0) = &H1B

        For i As Integer = 1 To 48 - 1
            ntpData(i) = 0
        Next
        s.Send(ntpData)
        s.Receive(ntpData)
        Dim offsetTransmitTime As Byte = 40
        Dim intpart As ULong = 0
        Dim fractpart As ULong = 0

        For i As Integer = 0 To 3
            intpart = 256 * intpart + ntpData(offsetTransmitTime + i)
        Next

        For i As Integer = 4 To 7
            fractpart = 256 * fractpart + ntpData(offsetTransmitTime + i)
        Next

        Dim milliseconds As ULong = (intpart * 1000 + (fractpart * 1000) / &H100000000L)
        s.Close()
        Dim timeSpan As TimeSpan = timeSpan.FromTicks(CLng(milliseconds) * timeSpan.TicksPerMillisecond)
        Dim dateTime As DateTime = New DateTime(1900, 1, 1)
        dateTime += timeSpan
        Dim offsetAmount As TimeSpan = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime)
        'TimeZone.CurrentTimeZone.
        Dim networkDateTime As DateTime = (dateTime + offsetAmount)

        Return networkDateTime
    End Function
    Public Function Ping(ByVal IP As String, ByVal Message As String) As Boolean
        Dim PingSend = New NetworkInformation.Ping
        Dim Reply As NetworkInformation.PingReply
        Dim buf() As Byte = New Byte((32) - 1) {}
        Dim options = New PingOptions
        Dim b As Boolean = False
        Try
            Reply = PingSend.Send(IP, buf, 2000, options)
            If Reply.Status = IPStatus.Success Then
                b = True
            Else
                b = False
            End If
        Catch ex As Exception
            If Message <> "" Then
                MessageBox(Message)
            End If
        Finally
            PingSend.Dispose()
        End Try

        Return b
    End Function
    Public Function Get_DeviceID() As String
        Return System.Net.Dns.GetHostName
    End Function
    Public Function ValidateDatetime() As Boolean
        Dim CompareDate As DateTime = "01-01-2020"
        If DateTime.Now < CompareDate Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub EnableWifi()
        Try
            Dim commandModeWLAN As WLAN = New WLAN(FusionAccessType.COMMAND_MODE)
            If commandModeWLAN.Adapters.Item(0).PowerState = Adapter.PowerStates.OFF Then
                commandModeWLAN.Adapters.Item(0).PowerState = Adapter.PowerStates.ON
            End If
            commandModeWLAN.Dispose()
        Catch ex As Exception
        Finally

        End Try
    End Sub   
End Module
Public Module PowerManagement
    'Const KEYEVENTF_KEYUP As Integer = 2
    'Const KEYEVENTF_KEYDOWN As Integer = 0
    'Const VK_NONAME As Byte = &HFC
    Dim CallBack As TimerCallback = New TimerCallback(AddressOf ResetIdleTimer)
    Public ThreadTimer As System.Threading.Timer
    'Public Sub InializeTimer()
    '    ThreadTimer = New System.Threading.Timer(CallBack, Nothing, 20000, 20000)
    'End Sub
    'Private Sub Virtual_KeyPress()
    '    keybd_event(VK_NONAME, 0, KEYEVENTF_KEYDOWN, 0)
    '    keybd_event(VK_NONAME, 0, KEYEVENTF_KEYUP, 0)
    'End Sub
    '<DllImport("coredll")> _
    'Private Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    'End Sub
    Public Sub InializeTimer()
        ThreadTimer = New System.Threading.Timer(CallBack, Nothing, 10000, 10000)
    End Sub
    Private Sub ResetIdleTimer()
        OpenNETCF.WindowsCE.PowerManagement.ResetSystemIdleTimer()
    End Sub
End Module
