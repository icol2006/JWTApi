Public Class Form1
    Dim ClientJWTApi As ClientJWTApi = New ClientJWTApi()
    Dim token As String



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            token = ClientJWTApi.GETTOKEN()
            txtToken.Text = token
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            txtResult.Text = ClientJWTApi.GETALL(token)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ClientJWTApi.hostname = txtHostname.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGetSingle_Click(sender As Object, e As EventArgs) Handles btnGetSingle.Click
        Try
            txtResult.Text = ClientJWTApi.GETSINGLE(token, txtSingle.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ClientJWTApi.INSERTRECORD(token, txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text)
            txtResult.Text = ClientJWTApi.GETALL(token)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ClientJWTApi.UPDATERECORD(token, txtId.Text, txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text)
            txtResult.Text = ClientJWTApi.GETSINGLE(token, txtId.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ClientJWTApi.DELETE(token, txtDelete.Text)
            txtResult.Text = ClientJWTApi.GETALL(token)
        Catch ex As Exception

        End Try
    End Sub
End Class
