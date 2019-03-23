Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class ClientJWTApi


    Private _hostname As String
    Public Property hostname() As String
        Get
            Return _hostname
        End Get
        Set(ByVal value As String)
            _hostname = value
        End Set
    End Property



    Public Function GETTOKEN()
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim postdata As String
        Dim postdatabytes As Byte()
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php")
        enc = New System.Text.UTF8Encoding()
        postdata = "action=login&username=john.doe&password=foobar"
        postdatabytes = enc.GetBytes(postdata)
        s.Method = "POST"
        s.ContentType = "application/x-www-form-urlencoded"
        s.ContentLength = postdatabytes.Length

        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim loResponseStream As StreamReader = New StreamReader(s.GetResponse().GetResponseStream(), enc)
        Dim Response As String = loResponseStream.ReadToEnd()

        Dim result = JsonConvert.DeserializeObject(Response)("token")
        Return result
    End Function


    Public Function GETLOGIN(token As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php?token=" + token)
        enc = New System.Text.UTF8Encoding()
        s.Method = "GET"
        s.ContentType = "text/html"

        Dim response = s.GetResponse()

        Dim loResponseStream As StreamReader = New StreamReader(response.GetResponseStream(), enc)
        Dim result As String = loResponseStream.ReadToEnd()
        result = JsonConvert.DeserializeObject(result)("userId")
        Return result
    End Function

    Public Function GETALL(token As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php?token=" + token + "&" + "action=fetch_all")
        enc = New System.Text.UTF8Encoding()
        s.Method = "GET"
        s.ContentType = "text/html"

        Dim response = s.GetResponse()

        Dim loResponseStream As StreamReader = New StreamReader(response.GetResponseStream(), enc)
        Dim result As String = loResponseStream.ReadToEnd()

        result = JsonConvert.DeserializeObject(Of Object)(result).ToString()

        Return result

    End Function

    Public Function GETSINGLE(token As String, id As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php?token=" + token + "&" + "action=fetch_single&id=" + id)
        enc = New System.Text.UTF8Encoding()
        s.Method = "GET"
        s.ContentType = "text/html"

        Dim response = s.GetResponse()

        Dim loResponseStream As StreamReader = New StreamReader(response.GetResponseStream(), enc)
        Dim result As String = loResponseStream.ReadToEnd()

        result = JsonConvert.DeserializeObject(Of Object)(result).ToString()

        Return result

    End Function

    Public Function INSERTRECORD(token As String, nombre As String, direccion As String, email As String, telefono As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim postdata As String
        Dim postdatabytes As Byte()
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php")
        enc = New System.Text.UTF8Encoding()
        postdata = "action=insert&nombre=" + nombre + "&direccion=" + direccion + "&email=" + email + "&telefono=" + telefono + "&token=" + token
        postdatabytes = enc.GetBytes(postdata)
        s.Method = "POST"
        s.ContentType = "application/x-www-form-urlencoded"
        s.ContentLength = postdatabytes.Length

        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim loResponseStream As StreamReader = New StreamReader(s.GetResponse().GetResponseStream(), enc)
        Dim Response As String = loResponseStream.ReadToEnd()

        Dim result = Response.ToString()

        Return result
    End Function

    Public Function UPDATERECORD(token As String, id As String, nombre As String, direccion As String, email As String, telefono As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim postdata As String
        Dim postdatabytes As Byte()
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php")
        enc = New System.Text.UTF8Encoding()
        postdata = "action=update&nombre=" + nombre + "&id=" + id + "&direccion=" + direccion + "&email=" + email + "&telefono=" + telefono + "&token=" + token
        postdatabytes = enc.GetBytes(postdata)
        s.Method = "POST"
        s.ContentType = "application/x-www-form-urlencoded"
        s.ContentLength = postdatabytes.Length

        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim loResponseStream As StreamReader = New StreamReader(s.GetResponse().GetResponseStream(), enc)
        Dim Response As String = loResponseStream.ReadToEnd()

        Dim result = Response.ToString()

        Return result
    End Function

    Public Function DELETE(token As String, id As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        s = HttpWebRequest.Create(hostname + "/PHP-JWT/app_client.php?token=" + token + "&" + "action=delete&id=" + id)
        enc = New System.Text.UTF8Encoding()
        s.Method = "GET"
        s.ContentType = "text/html"

        Dim response = s.GetResponse()

        Dim loResponseStream As StreamReader = New StreamReader(response.GetResponseStream(), enc)
        Dim result As String = loResponseStream.ReadToEnd()

        result = JsonConvert.DeserializeObject(Of Object)(result).ToString()

        Return result

    End Function

End Class
