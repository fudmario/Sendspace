' ***********************************************************************
' Assembly         : Sendspace
' Author           : fudmario
' Created          : 07-14-2017
'
' Last Modified By : fudmario
' Last Modified On : 07-14-2017
' ***********************************************************************
' <copyright file="SendspaceResponse.vb" company="DeveloperTeam">
'     Copyright ©  2017
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class SendspaceResponse.
''' </summary>
Public Class SendspaceResponse
    ''' <summary>
    ''' Gets the download URL.
    ''' </summary>
    ''' <value>The download URL.</value>
    Public ReadOnly Property DownloadUrl As String
    ''' <summary>
    ''' Gets the delete URL.
    ''' </summary>
    ''' <value>The delete URL.</value>
    Public ReadOnly Property DeleteUrl As String
    ''' <summary>
    ''' Gets the file identifier.
    ''' </summary>
    ''' <value>The file identifier.</value>
    Public ReadOnly Property FileId As String
    ''' <summary>
    ''' Gets the name of the file.
    ''' </summary>
    ''' <value>The name of the file.</value>
    Public ReadOnly Property FileName As String
    ''' <summary>
    ''' Gets the status.
    ''' </summary>
    ''' <value>The status.</value>
    Public ReadOnly Property Status As String
    ''' <summary>
    ''' Initializes a new instance of the <see cref="SendspaceResponse"/> class.
    ''' </summary>
    ''' <param name="downloadUrl">The download URL.</param>
    ''' <param name="deleteUrl">The delete URL.</param>
    ''' <param name="fileId">The file identifier.</param>
    ''' <param name="filename">The filename.</param>
    ''' <param name="status">The status.</param>
    Public Sub New(ByVal downloadUrl As String,
                   ByVal deleteUrl As String,
                   ByVal fileId As String,
                   ByVal filename As String,
                   ByVal status As String)

        Me.DownloadUrl = downloadUrl
        Me.DeleteUrl = deleteUrl
        Me.FileId = fileId
        Me.FileName = filename
        Me.Status = status
    End Sub
    ''' <summary>
    ''' Prevents a default instance of the <see cref="SendspaceResponse"/> class from being created.
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>A <see cref="System.String" /> that represents this instance.</returns>
    Public Overrides Function ToString() As String
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine($"Status.......: {Me.Status}")
        sb.AppendLine($"File ID......: {Me.FileId}")
        sb.AppendLine($"File Name....: {Me.FileName}")
        sb.AppendLine($"Url Download.: {Me.DownloadUrl}")
        sb.AppendLine($"Url Delete...: {Me.DeleteUrl}")
        Return sb.ToString()
    End Function
End Class