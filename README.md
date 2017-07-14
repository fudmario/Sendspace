# Sendspace

![alt text](https://www.sendspace.com/graphics/header/logo.png "sendspace")


Implementación de la API de Sendspace en vb.net


Ejemplo de uso:
```vb.net
 Dim filePath As String = "C:\Compress\MoveControl.zip"
 Dim sendspaceclient As New Sendspace.SendspaceClient("YourApiKey")
 Dim ssService As New Sendspace.SendspaceService(sendspaceclient)
Dim result As Sendspace.SendspaceResponse = Await ssService.UploadFileAsync(filePath)
  MessageBox.Show(result.ToString())
```

#### Retorna:
````
 Status.......: ok
File ID......: u9km31
File Name....: MoveControl.zip
Download Url.: https://www.sendspace.com/file/u9km31
Delete Url...: https://www.sendspace.com/delete/u9km31/5bb0402796182faa626e3aa7593137c7
````
