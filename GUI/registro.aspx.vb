Public Class registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Dim objController = New LAB.Controller

        Dim pUser = email.Text
        Dim pNombre = nombre.Text
        Dim pApellidos = apellidos.Text
        Dim pPass = password.Text
        Dim pTipo = perfil.Text

        Dim resultadoTmp = objController.registro(pUser, pPass, pNombre, pApellidos, pTipo)


        '0 - Usuario ya existe'
        '1 - Error de conexión a la base de datos
        '2 - Error de inserción en la base de datos'
        '3 - Registro correcto'

        If resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Usuario ya existe! Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=login.aspx")
        ElseIf resultadoTmp = 1 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Error de inserción en al BD."
            Response.Redirect("verificar.aspx")
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Usuario registrado correctamente. Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=login.aspx")
        ElseIf resultadoTmp = 4 Then
            RespuestaDelServidor.Text = "Error en envío de email."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub
End Class