'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.9136
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.9136.
'
Namespace HandheldUtilCU
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="HandheldUtilCU_Binding", [Namespace]:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU")>  _
    Partial Public Class HandheldUtilCU
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://10.1.100.22:7047/ABRWEB/WS/Bsat%20Supermarket%20S.A.L/Codeunit/HandheldUti"& _ 
                "lCU"
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:LastActionNo", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="LastActionNo_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LastActionNo() As <System.Xml.Serialization.XmlElementAttribute("return_value")> Integer
            Dim results() As Object = Me.Invoke("LastActionNo", New Object(-1) {})
            Return CType(results(0),Integer)
        End Function
        
        '''<remarks/>
        Public Function BeginLastActionNo(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LastActionNo", New Object(-1) {}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndLastActionNo(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:GetRetailPrice", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="GetRetailPrice_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetRetailPrice(ByVal itemNo As String, ByVal varCode As String, ByVal uOM As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Decimal
            Dim results() As Object = Me.Invoke("GetRetailPrice", New Object() {itemNo, varCode, uOM})
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Function BeginGetRetailPrice(ByVal itemNo As String, ByVal varCode As String, ByVal uOM As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetRetailPrice", New Object() {itemNo, varCode, uOM}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetRetailPrice(ByVal asyncResult As System.IAsyncResult) As Decimal
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:GetShelfLabel", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="GetShelfLabel_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetShelfLabel(ByVal bcode As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("GetShelfLabel", New Object() {bcode})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetShelfLabel(ByVal bcode As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetShelfLabel", New Object() {bcode}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetShelfLabel(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:GetDeviceCounters", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="GetDeviceCounters_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDeviceCounters(ByVal deviceID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("GetDeviceCounters", New Object() {deviceID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetDeviceCounters(ByVal deviceID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDeviceCounters", New Object() {deviceID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetDeviceCounters(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:GetDeviceCounters2", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="GetDeviceCounters2_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDeviceCounters2(ByVal deviceID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("GetDeviceCounters2", New Object() {deviceID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetDeviceCounters2(ByVal deviceID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDeviceCounters2", New Object() {deviceID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetDeviceCounters2(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:ConfirmPickingReceiving", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="ConfirmPickingReceiving_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ConfirmPickingReceiving(ByVal sessionID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("ConfirmPickingReceiving", New Object() {sessionID})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginConfirmPickingReceiving(ByVal sessionID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ConfirmPickingReceiving", New Object() {sessionID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndConfirmPickingReceiving(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:PostPickingReceiving", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="PostPickingReceiving_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function PostPickingReceiving(ByVal sessionID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("PostPickingReceiving", New Object() {sessionID})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginPostPickingReceiving(ByVal sessionID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("PostPickingReceiving", New Object() {sessionID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndPostPickingReceiving(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:PostTransOut", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="PostTransOut_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function PostTransOut(ByVal sessionID As String, ByVal print As Boolean) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("PostTransOut", New Object() {sessionID, print})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginPostTransOut(ByVal sessionID As String, ByVal print As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("PostTransOut", New Object() {sessionID, print}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndPostTransOut(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:GetTransferOrder", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="GetTransferOrder_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetTransferOrder(ByVal transferOrderNo As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("GetTransferOrder", New Object() {transferOrderNo})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetTransferOrder(ByVal transferOrderNo As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetTransferOrder", New Object() {transferOrderNo}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetTransferOrder(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:MarkTransferArrival", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="MarkTransferArrival_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function MarkTransferArrival(ByVal user As String, ByVal transferOrderNo As String, ByVal differenceExists As Boolean) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("MarkTransferArrival", New Object() {user, transferOrderNo, differenceExists})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginMarkTransferArrival(ByVal user As String, ByVal transferOrderNo As String, ByVal differenceExists As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("MarkTransferArrival", New Object() {user, transferOrderNo, differenceExists}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndMarkTransferArrival(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:LabelJobAssign", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="LabelJobAssign_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LabelJobAssign(ByVal jobNo As String, ByVal terminalAssigned As String, ByVal handheldUserID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("LabelJobAssign", New Object() {jobNo, terminalAssigned, handheldUserID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginLabelJobAssign(ByVal jobNo As String, ByVal terminalAssigned As String, ByVal handheldUserID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LabelJobAssign", New Object() {jobNo, terminalAssigned, handheldUserID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndLabelJobAssign(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:LabelJobComplete", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="LabelJobComplete_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LabelJobComplete(ByVal jobNo As String, ByVal labelSessionID As String, ByVal terminalAssigned As String, ByVal handheldUserID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> String
            Dim results() As Object = Me.Invoke("LabelJobComplete", New Object() {jobNo, labelSessionID, terminalAssigned, handheldUserID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginLabelJobComplete(ByVal jobNo As String, ByVal labelSessionID As String, ByVal terminalAssigned As String, ByVal handheldUserID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LabelJobComplete", New Object() {jobNo, labelSessionID, terminalAssigned, handheldUserID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndLabelJobComplete(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:LabelJobUnassign", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="LabelJobUnassign_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LabelJobUnassign(ByVal jobNo As String, ByVal terminalAssigned As String, ByVal handheldUserID As String) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Boolean
            Dim results() As Object = Me.Invoke("LabelJobUnassign", New Object() {jobNo, terminalAssigned, handheldUserID})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginLabelJobUnassign(ByVal jobNo As String, ByVal terminalAssigned As String, ByVal handheldUserID As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LabelJobUnassign", New Object() {jobNo, terminalAssigned, handheldUserID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndLabelJobUnassign(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU:LabelJobLineImplement", RequestNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", ResponseElementName:="LabelJobLineImplement_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/codeunit/HandheldUtilCU", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LabelJobLineImplement(ByVal jobNo As String, ByVal lineNo As Integer) As <System.Xml.Serialization.XmlElementAttribute("return_value")> Decimal
            Dim results() As Object = Me.Invoke("LabelJobLineImplement", New Object() {jobNo, lineNo})
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Function BeginLabelJobLineImplement(ByVal jobNo As String, ByVal lineNo As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LabelJobLineImplement", New Object() {jobNo, lineNo}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndLabelJobLineImplement(ByVal asyncResult As System.IAsyncResult) As Decimal
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Decimal)
        End Function
    End Class
End Namespace
