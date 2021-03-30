Public Class recuperarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub BtnCambiarPassword_Click(sender As Object, e As EventArgs) Handles BtnCambiarPassword.Click
        Dim objController = New LAB.Controller

        Dim pEmail As String = email.Text

        Dim resultadoTmp = objController.recuperarPassword(pEmail)

        '0 - Error de conexión a la base de datos'
        '1 - Usuario no existe en la base de datos'
        '2 - Error de actualización de contraseña'
        '3 - Contraseña cambiada y mail enviado'
        '4 - Contraseña cambiada pero mail no enviado'

        If resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 1 Then
            RespuestaDelServidor.Text = "Usuario no existe en la base de datos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Error de actualización de contraseña."
        ElseIf resultadoTmp = 3 Then
            objController.registrarMovimiento(pEmail, Session("tipo"), "Contraseña cambiada")
            RespuestaDelServidor.Text = "Contraseña cambiada y mail enviado. Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=login.aspx")
        ElseIf resultadoTmp = 4 Then
            RespuestaDelServidor.Text = "Contraseña cambiada pero mail no enviado."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub
End Class