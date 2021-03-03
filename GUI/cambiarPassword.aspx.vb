Public Class cambiarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            MsgBox("Usuario no logueado.")
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub BtnCambiarPassword_Click(sender As Object, e As EventArgs) Handles BtnCambiarPassword.Click
        Dim objController = New LAB.Controller

        Dim pUser = email.Text
        Dim pOldPassword = oldPassword.Text
        Dim pNewPassword = newPassword.Text

        Dim resultadoTmp = objController.cambiarPassword(pUser, pOldPassword, pNewPassword)


        '0 - Error de conexión a la base de datos'
        '1 - Usuario o contraseña incorrectos'
        '2 - Error de actualización de contraseña'
        '3 - Contraseña cambiada exitosamente'


        If resultadoTmp = 0 Then
            MsgBox("Error de conexión a la base de datos.")
        ElseIf resultadoTmp = 1 Then
            MsgBox("Usuario/contraseña incorrectos.")
        ElseIf resultadoTmp = 2 Then
            MsgBox("Error de actualización en la BD.")
        ElseIf resultadoTmp = 3 Then
            MsgBox("Contraseña cambiada correctamente.")
            Response.Redirect("index.aspx")
        Else
            MsgBox("Error desconocido.")
        End If

    End Sub

End Class