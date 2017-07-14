' ***********************************************************************
' Assembly         : OsHelper
' Author           : fudmario
' Created          : 07-12-2017
'
' Last Modified By : fudmario
' Last Modified On : 07-12-2017
' ***********************************************************************
' <copyright file="result.vb" company="DeveloperTeam">
'     Copyright ©  2017
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Xml.Serialization

''' <summary>
''' Class result.
''' </summary>
<XmlType(AnonymousType:=True), XmlRoot([Namespace]:="", IsNullable:=False)>
Partial Public Class result
    ''' <summary>
    ''' The upload field
    ''' </summary>
    Private uploadField As ResultUpload

    ''' <summary>
    ''' The method field
    ''' </summary>
    Private methodField As String

    ''' <summary>
    ''' The status field
    ''' </summary>
    Private statusField As String

    ''' <summary>
    ''' Gets or sets the upload.
    ''' </summary>
    ''' <value>The upload.</value>
    ''' <comentarios />
    Public Property upload() As ResultUpload
        Get
            Return Me.uploadField
        End Get
        Set
            Me.uploadField = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the method.
    ''' </summary>
    ''' <value>The method.</value>
    ''' <comentarios />
    <XmlAttribute()>
    Public Property method() As String
        Get
            Return Me.methodField
        End Get
        Set
            Me.methodField = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the status.
    ''' </summary>
    ''' <value>The status.</value>
    ''' <comentarios />
    <XmlAttribute()>
    Public Property status() As String
        Get
            Return Me.statusField
        End Get
        Set
            Me.statusField = Value
        End Set
    End Property
End Class


