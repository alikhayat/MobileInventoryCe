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
Namespace PricingJobLinePage
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="PricingJobLinePage_Binding", [Namespace]:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage")>  _
    Partial Public Class PricingJobLinePage_Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://10.1.100.22:7047/ABRWEB/WS/Bsat%20Supermarket%20S.A.L/Page/PricingJobLineP"& _ 
                "age"
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:Read", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="Read_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Read(ByVal Job_No As String, ByVal Line_No As Integer) As <System.Xml.Serialization.XmlElementAttribute("PricingJobLinePage")> PricingJobLinePage
            Dim results() As Object = Me.Invoke("Read", New Object() {Job_No, Line_No})
            Return CType(results(0),PricingJobLinePage)
        End Function
        
        '''<remarks/>
        Public Function BeginRead(ByVal Job_No As String, ByVal Line_No As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Read", New Object() {Job_No, Line_No}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndRead(ByVal asyncResult As System.IAsyncResult) As PricingJobLinePage
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PricingJobLinePage)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:ReadByRecId", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="ReadByRecId_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ReadByRecId(ByVal recId As String) As <System.Xml.Serialization.XmlElementAttribute("PricingJobLinePage")> PricingJobLinePage
            Dim results() As Object = Me.Invoke("ReadByRecId", New Object() {recId})
            Return CType(results(0),PricingJobLinePage)
        End Function
        
        '''<remarks/>
        Public Function BeginReadByRecId(ByVal recId As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ReadByRecId", New Object() {recId}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndReadByRecId(ByVal asyncResult As System.IAsyncResult) As PricingJobLinePage
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PricingJobLinePage)
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:ReadMultiple", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="ReadMultiple_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ReadMultiple(<System.Xml.Serialization.XmlElementAttribute("filter")> ByVal filter() As PricingJobLinePage_Filter, ByVal bookmarkKey As String, ByVal setSize As Integer) As <System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result"), System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> PricingJobLinePage()
            Dim results() As Object = Me.Invoke("ReadMultiple", New Object() {filter, bookmarkKey, setSize})
            Return CType(results(0),PricingJobLinePage())
        End Function
        
        '''<remarks/>
        Public Function BeginReadMultiple(ByVal filter() As PricingJobLinePage_Filter, ByVal bookmarkKey As String, ByVal setSize As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ReadMultiple", New Object() {filter, bookmarkKey, setSize}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndReadMultiple(ByVal asyncResult As System.IAsyncResult) As PricingJobLinePage()
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),PricingJobLinePage())
        End Function
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:IsUpdated", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="IsUpdated_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
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
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:GetRecIdFromKey", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="GetRecIdFromKey_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
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
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:Update", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="Update_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub Update(ByRef PricingJobLinePage As PricingJobLinePage)
            Dim results() As Object = Me.Invoke("Update", New Object() {PricingJobLinePage})
            PricingJobLinePage = CType(results(0),PricingJobLinePage)
        End Sub
        
        '''<remarks/>
        Public Function BeginUpdate(ByVal PricingJobLinePage As PricingJobLinePage, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Update", New Object() {PricingJobLinePage}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndUpdate(ByVal asyncResult As System.IAsyncResult, ByRef PricingJobLinePage As PricingJobLinePage)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PricingJobLinePage = CType(results(0),PricingJobLinePage)
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/pricingjoblinepage:UpdateMultiple", RequestNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", ResponseElementName:="UpdateMultiple_Result", ResponseNamespace:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub UpdateMultiple(<System.Xml.Serialization.XmlArrayItemAttribute(IsNullable:=false)> ByRef PricingJobLinePage_List() As PricingJobLinePage)
            Dim results() As Object = Me.Invoke("UpdateMultiple", New Object() {PricingJobLinePage_List})
            PricingJobLinePage_List = CType(results(0),PricingJobLinePage())
        End Sub
        
        '''<remarks/>
        Public Function BeginUpdateMultiple(ByVal PricingJobLinePage_List() As PricingJobLinePage, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("UpdateMultiple", New Object() {PricingJobLinePage_List}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndUpdateMultiple(ByVal asyncResult As System.IAsyncResult, ByRef PricingJobLinePage_List() As PricingJobLinePage)
            Dim results() As Object = Me.EndInvoke(asyncResult)
            PricingJobLinePage_List = CType(results(0),PricingJobLinePage())
        End Sub
    End Class
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage")>  _
    Partial Public Class PricingJobLinePage
        
        Private keyField As String
        
        Private job_NoField As String
        
        Private line_NoField As Integer
        
        Private line_NoFieldSpecified As Boolean
        
        Private item_NoField As String
        
        Private variant_CodeField As String
        
        Private unit_of_MeasureField As String
        
        Private descriptionField As String
        
        Private arabic_DescriptionField As String
        
        Private new_PriceField As Decimal
        
        Private new_PriceFieldSpecified As Boolean
        
        Private old_PriceField As Decimal
        
        Private old_PriceFieldSpecified As Boolean
        
        Private barcode_ListField As String
        
        Private scale_ItemField As Boolean
        
        Private scale_ItemFieldSpecified As Boolean
        
        Private reason_Code_GroupField As String
        
        Private reason_CodeField As String
        
        Private divisionField As String
        
        Private categoryField As String
        
        Private product_GroupField As String
        
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
        Public Property Job_No() As String
            Get
                Return Me.job_NoField
            End Get
            Set
                Me.job_NoField = value
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
        Public Property Item_No() As String
            Get
                Return Me.item_NoField
            End Get
            Set
                Me.item_NoField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Variant_Code() As String
            Get
                Return Me.variant_CodeField
            End Get
            Set
                Me.variant_CodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Unit_of_Measure() As String
            Get
                Return Me.unit_of_MeasureField
            End Get
            Set
                Me.unit_of_MeasureField = value
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
        Public Property Arabic_Description() As String
            Get
                Return Me.arabic_DescriptionField
            End Get
            Set
                Me.arabic_DescriptionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property New_Price() As Decimal
            Get
                Return Me.new_PriceField
            End Get
            Set
                Me.new_PriceField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property New_PriceSpecified() As Boolean
            Get
                Return Me.new_PriceFieldSpecified
            End Get
            Set
                Me.new_PriceFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Old_Price() As Decimal
            Get
                Return Me.old_PriceField
            End Get
            Set
                Me.old_PriceField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Old_PriceSpecified() As Boolean
            Get
                Return Me.old_PriceFieldSpecified
            End Get
            Set
                Me.old_PriceFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Barcode_List() As String
            Get
                Return Me.barcode_ListField
            End Get
            Set
                Me.barcode_ListField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Scale_Item() As Boolean
            Get
                Return Me.scale_ItemField
            End Get
            Set
                Me.scale_ItemField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property Scale_ItemSpecified() As Boolean
            Get
                Return Me.scale_ItemFieldSpecified
            End Get
            Set
                Me.scale_ItemFieldSpecified = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Reason_Code_Group() As String
            Get
                Return Me.reason_Code_GroupField
            End Get
            Set
                Me.reason_Code_GroupField = value
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
        Public Property Division() As String
            Get
                Return Me.divisionField
            End Get
            Set
                Me.divisionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Category() As String
            Get
                Return Me.categoryField
            End Get
            Set
                Me.categoryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Product_Group() As String
            Get
                Return Me.product_GroupField
            End Get
            Set
                Me.product_GroupField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage")>  _
    Partial Public Class PricingJobLinePage_Filter
        
        Private fieldField As PricingJobLinePage_Fields
        
        Private criteriaField As String
        
        '''<remarks/>
        Public Property Field() As PricingJobLinePage_Fields
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
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:microsoft-dynamics-schemas/page/pricingjoblinepage")>  _
    Public Enum PricingJobLinePage_Fields
        
        '''<remarks/>
        Job_No
        
        '''<remarks/>
        Line_No
        
        '''<remarks/>
        Item_No
        
        '''<remarks/>
        Variant_Code
        
        '''<remarks/>
        Unit_of_Measure
        
        '''<remarks/>
        Description
        
        '''<remarks/>
        Arabic_Description
        
        '''<remarks/>
        New_Price
        
        '''<remarks/>
        Old_Price
        
        '''<remarks/>
        Barcode_List
        
        '''<remarks/>
        Scale_Item
        
        '''<remarks/>
        Reason_Code_Group
        
        '''<remarks/>
        Reason_Code
        
        '''<remarks/>
        Division
        
        '''<remarks/>
        Category
        
        '''<remarks/>
        Product_Group
    End Enum
End Namespace
