Public Class verificarPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            MsgBox("Usuario no logueado.")
            Response.Redirect("login.aspx")
        End If

        Dim objController = New LAB.Controller

        If objController.cuentaVerificada(Session.Contents("usuario")) = 1 Then
            MsgBox("Cuenta ya verificada.")
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
        '5 - Código incorrecto'

        If resultadoTmp = 1 Then
            MsgBox("Usuario ya confirmado!")
            Response.Redirect("index.aspx")
        ElseIf resultadoTmp = 0 Then
            MsgBox("Error de conexión a la base de datos.")
        ElseIf resultadoTmp = 2 Then
            MsgBox("Usuario no existe en la BD.")
        ElseIf resultadoTmp = 3 Then
            MsgBox("Cuenta verificada correctamente.")
            Response.Redirect("index.aspx")
        ElseIf resultadoTmp = 4 Then
            MsgBox("Error de actualización en la base de datos.")
        ElseIf resultadoTmp = 5 Then
            MsgBox("Código de verificación incorrecto.")
        Else
            MsgBox("Error desconocido.")
        End If

    End Sub

End Class