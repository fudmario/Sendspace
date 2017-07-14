' ***********************************************************************
' Assembly         : Sendspace
' Author           : fudmario
' Created          : 07-14-2017
'
' Last Modified By : fudmario
' Last Modified On : 07-14-2017
' ***********************************************************************
' <copyright file="SendspaceService.vb" company="DeveloperTeam">
'     Copyright ©  2017
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.IO
Imports System.Net
Imports System.Text

''' <summary>
''' Class SendspaceService.
''' </summary>
Public Class SendspaceService
    ''' <summary>
    ''' The SSC b
    ''' </summary>
    Private ReadOnly sscB As SendspaceClient
    ''' <summary>
    ''' Prevents a default instance of the <see cref="SendspaceService"/> class from being created.
    ''' </summary>
    Private Sub New()

    End Sub
    ''' <summary>
    ''' Initializes a new instance of the <see cref="SendspaceService"/> class.
    ''' </summary>
    ''' <param name="sendspaceclient">sendspaceclient.</param>
    Public Sub New(sendspaceclient As SendspaceClient)
        Me.sscB = sendspaceclient

    End Sub
    ''' <summary>
    ''' upload file to Sendspace as an asynchronous operation.
    ''' </summary>
    ''' <param name="filepath">filepath.</param>
    ''' <returns>Task(Of SendspaceResponse).</returns>
    Public Async Function UploadFileAsync(filepath As String) As Task(Of SendspaceResponse)
        Dim result As SendspaceResponse = Await Task.Run(Function()
                                                             Return UploadFile(filepath)
                                                         End Function)
        Return result

    End Function
    ''' <summary>
    ''' Uploads the file to Sendspace.
    ''' </summary>
    ''' <param name="filePath">The file path.</param>
    ''' <returns>SendspaceResponse.</returns>
    Public Function UploadFile(ByVal filePath As String) As SendspaceResponse

        Try
            Dim upl As Result = sscB.AnonymousGetInfo()
            Dim boundary As String = String.Format("{0}{1}", New String("-"c, 27), Date.Now.Ticks.ToString)
            Dim filename As String = Path.GetFileName(filePath)
            Dim sb As New StringBuilder()
            sb.AppendFormat("--{0}", boundary)
            sb.AppendLine()
            sb.Append("Content-Disposition: form-data; name=""UPLOAD_IDENTIFIER""")
            sb.AppendLine()
            sb.AppendLine()
            sb.Append(upl.upload.upload_identifier)
            sb.AppendLine()
            sb.AppendFormat("--{0}", boundary)
            sb.AppendLine()
            sb.Append("Content-Disposition: form-data; name=""MAX_FILE_SIZE""")
            sb.AppendLine()
            sb.AppendLine()
            sb.Append(upl.upload.max_file_size)
            sb.AppendLine()
            sb.AppendFormat("--{0}", boundary)
            sb.AppendLine()
            sb.Append("Content-Disposition: form-data; name=""extra_info""")
            sb.AppendLine()
            sb.AppendLine()
            sb.Append(upl.upload.extra_info)
            sb.AppendLine()
            sb.AppendFormat("--{0}", boundary)
            sb.AppendLine()
            sb.Append("Content-Disposition: form-data; name=""userfile""; filename=""")
            sb.AppendFormat("{0}""", filename)
            sb.AppendLine()
            sb.Append("Content-Type: ""application/octet-stream""")
            sb.AppendLine()
            sb.AppendLine()

            Dim req As WebRequest = WebRequest.Create(upl.upload.url)

            req.ContentType = "multipart/form-data; boundary=" & boundary
            req.Method = "POST"
            req.Timeout = Integer.MaxValue
            Using requestStream As Stream = req.GetRequestStream()
                Dim headerBytes As Byte() = Encoding.UTF8.GetBytes(sb.ToString())
                requestStream.Write(headerBytes, 0, headerBytes.Length)
                Using fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                    Dim buffer(4096) As Byte
                    Dim bytesRead As Integer = fileStream.Read(buffer, 0, buffer.Length)
                    Do While (bytesRead > 0)
                        requestStream.Write(buffer, 0, bytesRead)
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                    Loop
                End Using
                Dim endBoundary As Byte() = Encoding.ASCII.GetBytes(String.Format("{0}--{1}--{0}", vbNewLine, boundary))
                requestStream.Write(endBoundary, 0, endBoundary.Length)
            End Using

            Using resp As WebResponse = req.GetResponse
                Using sr As New StreamReader(resp.GetResponseStream())
                    Dim result As String = sr.ReadToEnd()
                    Dim urlDown As String = result.Between("<download_url>", "</download_url>")
                    Dim urlDel As String = result.Between("<delete_url>", "</delete_url>")
                    Dim fileId As String = result.Between("<file_id>", "</file_id>")
                    Dim sts As String = result.Between("<status>", "</status>")

                    Return New SendspaceResponse(urlDown, urlDel, fileId, filename, sts)
                End Using
            End Using




        Catch ex As Exception

            Throw
        End Try
        '   Return New SendspaceResponse("", "", "", "fail")
    End Function
End Class
