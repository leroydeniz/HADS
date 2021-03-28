Public Class cambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub BtnCambiarPassword_Click(sender As Object, e As EventArgs) Handles BtnCambiarPassword.Click
        Dim objController = New LAB.Controller

        Dim pUser = Session.Contents("usuario")
        Dim pOldPassword = oldPassword.Text
        Dim pNewPassword = newPassword.Text

        Dim resultadoTmp = objController.cambiarPassword(pUser, pOldPassword, pNewPassword)


        '0 - Error de conexión a la base de datos'
        '1 - Usuario o contraseña incorrectos'
        '2 - Error de actualización de contraseña'
        '3 - Contraseña cambiada exitosamente'


        If resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 1 Then
            RespuestaDelServidor.Text = "Usuario/contraseña incorrectos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Error de actualización en la BD."
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Contraseña cambiada correctamente. Será redirigido en 3 segundos..."
            If Session.Contents("tipo") = "Profesor" Then
                Response.AddHeader("REFRESH", "3;URL=Profesor/inicioProfesor.aspx")
            Else
                Response.AddHeader("REFRESH", "3;URL=Alumno/inicioAlumno.aspx")
            End If

        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub

End Class