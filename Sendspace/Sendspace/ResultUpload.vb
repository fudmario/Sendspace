
Imports System.Xml.Serialization

''' <summary>
''' Attributes of Upload Data
''' </summary>
<XmlType(AnonymousType:=True)>
Partial Public Class ResultUpload

    ''' <summary>
    ''' URL field
    ''' </summary>
    Private urlField As String

    ''' <summary>
    ''' progress URL field
    ''' </summary>
    Private progress_urlField As String

    ''' <summary>
    ''' maximum file size field
    ''' </summary>
    Private max_file_sizeField As UInteger

    ''' <summary>
    ''' upload identifier field
    ''' </summary>
    Private upload_identifierField As String

    ''' <summary>
    ''' extra information field
    ''' </summary>
    Private extra_infoField As String


    ''' <summary>
    ''' Get or sets URL to upload the file to.
    ''' </summary>
    ''' <value>URL to upload the file to.</value>
    <XmlAttribute()>
    Public Property url() As String
        Get
            Return Me.urlField
        End Get
        Set
            Me.urlField = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets URL for real-time progress information.
    ''' </summary>
    ''' <value>URL for real-time progress information.</value>
    <XmlAttribute()>
    Public Property progress_url() As String
        Get
            Return Me.progress_urlField
        End Get
        Set
            Me.progress_urlField = Value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets for max size current user can upload.
    ''' </summary>
    ''' <value>max_file_size for max size current user can upload.</value>
    <XmlAttribute()>
    Public Property max_file_size() As UInteger
        Get
            Return Me.max_file_sizeField
        End Get
        Set
            Me.max_file_sizeField = Value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets upload_identifier to be passed in the upload form.
    ''' </summary>
    ''' <value>upload_identifier to be passed in the upload form.</value>
    <XmlAttribute()>
    Public Property upload_identifier() As String
        Get
            Return Me.upload_identifierField
        End Get
        Set
            Me.upload_identifierField = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets extra_info to be passed in the upload form..
    ''' </summary>
    ''' <value>extra_info to be passed in the upload form..</value>
    ''' <comentarios />
    <XmlAttribute()>
    Public Property extra_info() As String
        Get
            Return Me.extra_infoField
        End Get
        Set
            Me.extra_infoField = Value
        End Set
    End Property
End Class