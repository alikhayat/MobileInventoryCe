﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.9043
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
'This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.9043.
'
Namespace PRLine
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="PRLineAPI_Binding", [Namespace]:="urn:microsoft-dynamics-schemas/page/prlineapi")>  _
    Partial Public Class PRLineAPI_Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://10.1.100.22:7047/ABRWEB/WS/Bsat%20Supermarket%20S.A.L/Page/PRLineAPI"
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:Read", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="Read_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Read(ByVal Document_No As String, ByVal Line_No As Integer) As <System.Xml.Serialization.XmlElementAttribute("PRLineAPI")> PRLineAPI
            Dim results() As Object = Me.Invoke("Read", New Object() {Document_No, Line_No})
            Return CType(results(0),PRLineAPI)
        End Function
        
        '''<remarks/>
        Public Function BeginRead(ByVal Document_No As String, ByVal Line_No As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Read", New Object() {Document_No, Line_No}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndRead(ByVal asyncResult As System.IAsyncResult) As PRLineAPI
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PRLineAPI)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:ReadByRecId", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="ReadByRecId_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ReadByRecId(ByVal recId As String) As <System.Xml.Serialization.XmlElementAttribute("PRLineAPI")> PRLineAPI
            Dim results() As Object = Me.Invoke("ReadByRecId", New Object() {recId})
            Return CType(results(0),PRLineAPI)
        End Function
        
        '''<remarks/>
        Public Function BeginReadByRecId(ByVal recId As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ReadByRecId", New Object() {recId}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndReadByRecId(ByVal asyncResult As System.IAsyncResult) As PRLineAPI
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PRLineAPI)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:ReadMultiple", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="ReadMultiple_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ReadMultiple(<System.Xml.Serialization.XmlElementAttribute("filter")> ByVal filter() As PRLineAPI_Filter, ByVal bookmarkKey As String, ByVal setSize As Integer) As <System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result"), System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> PRLineAPI()
            Dim results() As Object = Me.Invoke("ReadMultiple", New Object() {filter, bookmarkKey, setSize})
            Return CType(results(0),PRLineAPI())
        End Function
        
        '''<remarks/>
        Public Function BeginReadMultiple(ByVal filter() As PRLineAPI_Filter, ByVal bookmarkKey As String, ByVal setSize As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ReadMultiple", New Object() {filter, bookmarkKey, setSize}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndReadMultiple(ByVal asyncResult As System.IAsyncResult) As PRLineAPI()
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PRLineAPI())
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:IsUpdated", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="IsUpdated_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function IsUpdated(ByVal Key As String) As <System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")> Boolean
            Dim results() As Object = Me.Invoke("IsUpdated", New Object() {Key})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginIsUpdated(ByVal Key As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("IsUpdated", New Object() {Key}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndIsUpdated(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:GetRecIdFromKey", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="GetRecIdFromKey_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetRecIdFromKey(ByVal Key As String) As <System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")> String
            Dim results() As Object = Me.Invoke("GetRecIdFromKey", New Object() {Key})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetRecIdFromKey(ByVal Key As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetRecIdFromKey", New Object() {Key}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetRecIdFromKey(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:Create", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="Create_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Create(ByRef PRLineAPI As PRLineAPI)
            Dim results() As Object = Me.Invoke("Create", New Object() {PRLineAPI})
            PRLineAPI = CType(results(0),PRLineAPI)
        End Sub
        
        '''<remarks/>
        Public Function BeginCreate(ByVal PRLineAPI As PRLineAPI, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Create", New Object() {PRLineAPI}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndCreate(ByVal asyncResult As System.IAsyncResult, ByRef PRLineAPI As PRLineAPI)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PRLineAPI = CType(results(0),PRLineAPI)
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:CreateMultiple", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="CreateMultiple_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub CreateMultiple(<System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> ByRef PRLineAPI_List() As PRLineAPI)
            Dim results() As Object = Me.Invoke("CreateMultiple", New Object() {PRLineAPI_List})
            PRLineAPI_List = CType(results(0),PRLineAPI())
        End Sub
        
        '''<remarks/>
        Public Function BeginCreateMultiple(ByVal PRLineAPI_List() As PRLineAPI, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CreateMultiple", New Object() {PRLineAPI_List}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndCreateMultiple(ByVal asyncResult As System.IAsyncResult, ByRef PRLineAPI_List() As PRLineAPI)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PRLineAPI_List = CType(results(0),PRLineAPI())
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:Update", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="Update_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update(ByRef PRLineAPI As PRLineAPI)
            Dim results() As Object = Me.Invoke("Update", New Object() {PRLineAPI})
            PRLineAPI = CType(results(0),PRLineAPI)
        End Sub
        
        '''<remarks/>
        Public Function BeginUpdate(ByVal PRLineAPI As PRLineAPI, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Update", New Object() {PRLineAPI}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndUpdate(ByVal asyncResult As System.IAsyncResult, ByRef PRLineAPI As PRLineAPI)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PRLineAPI = CType(results(0),PRLineAPI)
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:UpdateMultiple", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="UpdateMultiple_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub UpdateMultiple(<System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> ByRef PRLineAPI_List() As PRLineAPI)
            Dim results() As Object = Me.Invoke("UpdateMultiple", New Object() {PRLineAPI_List})
            PRLineAPI_List = CType(results(0),PRLineAPI())
        End Sub
        
        '''<remarks/>
        Public Function BeginUpdateMultiple(ByVal PRLineAPI_List() As PRLineAPI, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("UpdateMultiple", New Object() {PRLineAPI_List}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndUpdateMultiple(ByVal asyncResult As System.IAsyncResult, ByRef PRLineAPI_List() As PRLineAPI)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PRLineAPI_List = CType(results(0),PRLineAPI())
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/prlineapi:Delete", RequestNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", ResponseElementName:="Delete_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/prlineapi", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Delete(ByVal Key As String) As <System.Xml.Serialization.XmlElementAttribute("Delete_Result")> Boolean
            Dim results() As Object = Me.Invoke("Delete", New Object() {Key})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginDelete(ByVal Key As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Delete", New Object() {Key}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndDelete(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
    End Class
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/prlineapi")>  _
    Partial Public Class PRLineAPI
        
        Private keyField As String
        
        Private document_NoField As String
        
        Private line_NoField As Integer
        
        Private line_NoFieldSpecified As Boolean
        
        Private barcodeField As String
        
        Private item_NoField As String
        
        Private variant_codeField As String
        
        Private unit_of_Measure_CodeField As String
        
        Private packaging_WeightField As Decimal
        
        Private packaging_WeightFieldSpecified As Boolean
        
        Private total_WeightField As Decimal
        
        Private total_WeightFieldSpecified As Boolean
        
        Private entered_Quantity_1Field As Decimal
        
        Private entered_Quantity_1FieldSpecified As Boolean
        
        Private entered_Quantity_2Field As Decimal
        
        Private entered_Quantity_2FieldSpecified As Boolean
        
        Private descriptionField As String
        
        Private quantityField As Decimal
        
        Private quantityFieldSpecified As Boolean
        
        Private reason_CodeField As String
        
        Private handheld_UserField As String
        
        Private handheld_Start_TimeField As Date
        
        Private handheld_Start_TimeFieldSpecified As Boolean
        
        Private vendor_Item_NoField As String
        
        Private weight_ItemField As Boolean
        
        Private weight_ItemFieldSpecified As Boolean
        
        Private new_ItemField As Boolean
        
        Private new_ItemFieldSpecified As Boolean
        
        Private new_DescriptionField As String
        
        Private qty_Per_Base_Comp_UnitField As Decimal
        
        Private qty_Per_Base_Comp_UnitFieldSpecified As Boolean
        
        Private base_Comp_UnitField As String
        
        Private purchase_PackField As Decimal
        
        Private purchase_PackFieldSpecified As Boolean
        
        Private printedField As Boolean
        
        Private printedFieldSpecified As Boolean
        
        Private printed_QuantityField As Integer
        
        Private printed_QuantityFieldSpecified As Boolean
        
        Private scanned_Unit_Of_MeasureField As String
        
        Private qty_Per_Scanned_UnitField As Decimal
        
        Private qty_Per_Scanned_UnitFieldSpecified As Boolean
        
        Private scanned_Unit_QuantityField As Decimal
        
        Private scanned_Unit_QuantityFieldSpecified As Boolean
        
        '''<remarks/>
        Public Property Key() As String
            Get
                Return Me.keyField
            End Get
            Set
                Me.keyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Document_No() As String
            Get
                Return Me.document_NoField
            End Get
            Set
                Me.document_NoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Line_No() As Integer
            Get
                Return Me.line_NoField
            End Get
            Set
                Me.line_NoField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Line_NoSpecified() As Boolean
            Get
                Return Me.line_NoFieldSpecified
            End Get
            Set
                Me.line_NoFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Barcode() As String
            Get
                Return Me.barcodeField
            End Get
            Set
                Me.barcodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Item_No() As String
            Get
                Return Me.item_NoField
            End Get
            Set
                Me.item_NoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Variant_code() As String
            Get
                Return Me.variant_codeField
            End Get
            Set
                Me.variant_codeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Unit_of_Measure_Code() As String
            Get
                Return Me.unit_of_Measure_CodeField
            End Get
            Set
                Me.unit_of_Measure_CodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Packaging_Weight() As Decimal
            Get
                Return Me.packaging_WeightField
            End Get
            Set
                Me.packaging_WeightField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Packaging_WeightSpecified() As Boolean
            Get
                Return Me.packaging_WeightFieldSpecified
            End Get
            Set
                Me.packaging_WeightFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Total_Weight() As Decimal
            Get
                Return Me.total_WeightField
            End Get
            Set
                Me.total_WeightField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Total_WeightSpecified() As Boolean
            Get
                Return Me.total_WeightFieldSpecified
            End Get
            Set
                Me.total_WeightFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Entered_Quantity_1() As Decimal
            Get
                Return Me.entered_Quantity_1Field
            End Get
            Set
                Me.entered_Quantity_1Field = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Entered_Quantity_1Specified() As Boolean
            Get
                Return Me.entered_Quantity_1FieldSpecified
            End Get
            Set
                Me.entered_Quantity_1FieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Entered_Quantity_2() As Decimal
            Get
                Return Me.entered_Quantity_2Field
            End Get
            Set
                Me.entered_Quantity_2Field = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Entered_Quantity_2Specified() As Boolean
            Get
                Return Me.entered_Quantity_2FieldSpecified
            End Get
            Set
                Me.entered_Quantity_2FieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Quantity() As Decimal
            Get
                Return Me.quantityField
            End Get
            Set
                Me.quantityField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property QuantitySpecified() As Boolean
            Get
                Return Me.quantityFieldSpecified
            End Get
            Set
                Me.quantityFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Reason_Code() As String
            Get
                Return Me.reason_CodeField
            End Get
            Set
                Me.reason_CodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Handheld_User() As String
            Get
                Return Me.handheld_UserField
            End Get
            Set
                Me.handheld_UserField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Handheld_Start_Time() As Date
            Get
                Return Me.handheld_Start_TimeField
            End Get
            Set
                Me.handheld_Start_TimeField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Handheld_Start_TimeSpecified() As Boolean
            Get
                Return Me.handheld_Start_TimeFieldSpecified
            End Get
            Set
                Me.handheld_Start_TimeFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Vendor_Item_No() As String
            Get
                Return Me.vendor_Item_NoField
            End Get
            Set
                Me.vendor_Item_NoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Weight_Item() As Boolean
            Get
                Return Me.weight_ItemField
            End Get
            Set
                Me.weight_ItemField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Weight_ItemSpecified() As Boolean
            Get
                Return Me.weight_ItemFieldSpecified
            End Get
            Set
                Me.weight_ItemFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property New_Item() As Boolean
            Get
                Return Me.new_ItemField
            End Get
            Set
                Me.new_ItemField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property New_ItemSpecified() As Boolean
            Get
                Return Me.new_ItemFieldSpecified
            End Get
            Set
                Me.new_ItemFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property New_Description() As String
            Get
                Return Me.new_DescriptionField
            End Get
            Set
                Me.new_DescriptionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Qty_Per_Base_Comp_Unit() As Decimal
            Get
                Return Me.qty_Per_Base_Comp_UnitField
            End Get
            Set
                Me.qty_Per_Base_Comp_UnitField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Qty_Per_Base_Comp_UnitSpecified() As Boolean
            Get
                Return Me.qty_Per_Base_Comp_UnitFieldSpecified
            End Get
            Set
                Me.qty_Per_Base_Comp_UnitFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Base_Comp_Unit() As String
            Get
                Return Me.base_Comp_UnitField
            End Get
            Set
                Me.base_Comp_UnitField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Purchase_Pack() As Decimal
            Get
                Return Me.purchase_PackField
            End Get
            Set
                Me.purchase_PackField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Purchase_PackSpecified() As Boolean
            Get
                Return Me.purchase_PackFieldSpecified
            End Get
            Set
                Me.purchase_PackFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Printed() As Boolean
            Get
                Return Me.printedField
            End Get
            Set
                Me.printedField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property PrintedSpecified() As Boolean
            Get
                Return Me.printedFieldSpecified
            End Get
            Set
                Me.printedFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Printed_Quantity() As Integer
            Get
                Return Me.printed_QuantityField
            End Get
            Set
                Me.printed_QuantityField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Printed_QuantitySpecified() As Boolean
            Get
                Return Me.printed_QuantityFieldSpecified
            End Get
            Set
                Me.printed_QuantityFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Scanned_Unit_Of_Measure() As String
            Get
                Return Me.scanned_Unit_Of_MeasureField
            End Get
            Set
                Me.scanned_Unit_Of_MeasureField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Qty_Per_Scanned_Unit() As Decimal
            Get
                Return Me.qty_Per_Scanned_UnitField
            End Get
            Set
                Me.qty_Per_Scanned_UnitField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Qty_Per_Scanned_UnitSpecified() As Boolean
            Get
                Return Me.qty_Per_Scanned_UnitFieldSpecified
            End Get
            Set
                Me.qty_Per_Scanned_UnitFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Scanned_Unit_Quantity() As Decimal
            Get
                Return Me.scanned_Unit_QuantityField
            End Get
            Set
                Me.scanned_Unit_QuantityField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Scanned_Unit_QuantitySpecified() As Boolean
            Get
                Return Me.scanned_Unit_QuantityFieldSpecified
            End Get
            Set
                Me.scanned_Unit_QuantityFieldSpecified = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/prlineapi")>  _
    Partial Public Class PRLineAPI_Filter
        
        Private fieldField As PRLineAPI_Fields
        
        Private criteriaField As String
        
        '''<remarks/>
        Public Property Field() As PRLineAPI_Fields
            Get
                Return Me.fieldField
            End Get
            Set
                Me.fieldField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Criteria() As String
            Get
                Return Me.criteriaField
            End Get
            Set
                Me.criteriaField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/prlineapi")>  _
    Public Enum PRLineAPI_Fields
        
        '''<remarks/>
        Document_No
        
        '''<remarks/>
        Line_No
        
        '''<remarks/>
        Barcode
        
        '''<remarks/>
        Item_No
        
        '''<remarks/>
        Variant_code
        
        '''<remarks/>
        Unit_of_Measure_Code
        
        '''<remarks/>
        Packaging_Weight
        
        '''<remarks/>
        Total_Weight
        
        '''<remarks/>
        Entered_Quantity_1
        
        '''<remarks/>
        Entered_Quantity_2
        
        '''<remarks/>
        Description
        
        '''<remarks/>
        Quantity
        
        '''<remarks/>
        Reason_Code
        
        '''<remarks/>
        Handheld_User
        
        '''<remarks/>
        Handheld_Start_Time
        
        '''<remarks/>
        Vendor_Item_No
        
        '''<remarks/>
        Weight_Item
        
        '''<remarks/>
        New_Item
        
        '''<remarks/>
        New_Description
        
        '''<remarks/>
        Qty_Per_Base_Comp_Unit
        
        '''<remarks/>
        Base_Comp_Unit
        
        '''<remarks/>
        Purchase_Pack
        
        '''<remarks/>
        Printed
        
        '''<remarks/>
        Printed_Quantity
        
        '''<remarks/>
        Scanned_Unit_Of_Measure
        
        '''<remarks/>
        Qty_Per_Scanned_Unit
        
        '''<remarks/>
        Scanned_Unit_Quantity
    End Enum
End Namespace