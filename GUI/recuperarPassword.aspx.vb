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
            MsgBox("Error de conexión a la base de datos.")
        ElseIf resultadoTmp = 1 Then
            MsgBox("Usuario no existe en la base de datos.")
        ElseIf resultadoTmp = 2 Then
            MsgBox("Error de actualización de contraseña.")
        ElseIf resultadoTmp = 3 Then
            MsgBox("Contraseña cambiada y mail enviado.")
            Response.Redirect("login.aspx")
        ElseIf resultadoTmp = 4 Then
            MsgBox("Contraseña cambiada pero mail no enviado.")
        Else
            MsgBox("Error desconocido.")
        End If

    End Sub
End Class