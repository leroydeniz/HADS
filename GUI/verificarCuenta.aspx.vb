﻿Public Class verificarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            Response.Write("<script>alert('Usuario no logueado.')</script>")
            Response.Redirect("login.aspx")
        End If

        Dim objController = New LAB.Controller

        If objController.cuentaVerificada(Session.Contents("usuario")) = 1 Then
            Response.Write("<script>alert('Cuenta ya verificada.')</script>")
            Response.Redirect("index.aspx")
        End If
    End Sub

    Protected Sub BtnVerificarCuenta_Click(sender As Object, e As EventArgs) Handles BtnVerificarCuenta.Click
        Dim objController = New LAB.Controller

        Dim resultadoTmp = objController.verificarCuenta(Session.Contents("usuario"), codigo.Text)

        '0 - Error de conexión a la base de datos'
        '1 - Usuario ya verificado'
        '2 - Usuario no existe en db'
        '3 - Usuario confirmado correctamente'
        '4 - Error de actualización de db'
        '5 - Código incorrecto OK'

        If resultadoTmp = 1 Then
            RespuestaDelServidor.Text = "Usuario ya confirmado!"
            Response.Redirect("index.aspx")
        ElseIf resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Usuario no existe en la BD."
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Cuenta verificada correctamente."
            Response.Redirect("index.aspx")
        ElseIf resultadoTmp = 4 Then
            RespuestaDelServidor.Text = "Error de actualización en la base de datos."
        ElseIf resultadoTmp = 5 Then
            RespuestaDelServidor.Text = "Código de verificación incorrecto."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub

End Class