
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization

Module Extensions
    <Extension>
    Public Function Between(sender As String, ByVal delA As String, ByVal delB As String) As String
        Try
            Dim s As Integer = sender.IndexOf(delA, StringComparison.Ordinal) + delA.Length + 1
            Dim b As Integer = sender.Substring(s).IndexOf(delB, StringComparison.Ordinal) + 1
            Return Mid(sender, s, b)
        Catch ex As Exception
        End Try
        Return String.Empty
    End Function
    <Extension>
    Public Function XmlDeserialize(Of T)(ByVal fs As Stream) As T
        Dim serializer As Object = New XmlSerializer(GetType(T))
        Return DirectCast(DirectCast(serializer, XmlSerializer).Deserialize(fs), T)
    End Function
End Module
