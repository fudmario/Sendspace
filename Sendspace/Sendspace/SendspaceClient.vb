' ***********************************************************************
' Assembly         : Sendspace
' Author           : fudmario
' Created          : 07-14-2017
'
' Last Modified By : fudmario
' Last Modified On : 07-14-2017
' ***********************************************************************
' <copyright file="SendspaceClient.vb" company="DeveloperTeam">
'     Copyright ©  2017
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.IO
Imports System.Net
Imports System.Text

''' <summary>
''' Class SendspaceClient.
''' </summary>
Public Class SendspaceClient
    Private ReadOnly Property ApiKeyB() As String
    ''' <summary>
    ''' Base Url of sendspace Api
    ''' </summary>
    Private Const ApiUrl As String = "http://api.sendspace.com/rest/"
    ''' <summary>
    ''' Prevents a default instance of the <see cref="SendspaceClient"/> class from being created.
    ''' </summary>
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Initializes a new instance of the <see cref="SendspaceClient"/> class.
    ''' </summary>
    ''' <param name="apikey">Api Key, received from sendspace.</param>
    Public Sub New(ByVal apikey As String)
        ApiKeyB = apikey
    End Sub
    ''' <summary>
    ''' Obtains the basic information needed to make an anonymous upload. This method does not require authentication or login.
    ''' </summary>
    ''' <returns>result.</returns>
    Public Function AnonymousGetInfo() As result
        Dim parameters As String = $"?method=anonymous.uploadGetInfo&speed_limit=0&api_key={ApiKeyB}&api_version=1.2"
        Dim req As WebRequest = WebRequest.Create(New Uri(String.Format("{0}{1}", ApiUrl, parameters)))
        Using resp As WebResponse = req.GetResponse
            Using sr As New StreamReader(resp.GetResponseStream, Encoding.UTF8)
                Dim res As Stream = sr.BaseStream
                Return res.XmlDeserialize(Of result)
            End Using
        End Using
    End Function
End Class
