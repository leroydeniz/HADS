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
            MsgBox("Usuario ya existe!")
            Response.Redirect("login.aspx")
        ElseIf resultadoTmp = 1 Then
            MsgBox("Error de conexión a la base de datos.")
        ElseIf resultadoTmp = 2 Then
            MsgBox("Error de inserción en al BD.")
            Response.Redirect("verificar.aspx")
        ElseIf resultadoTmp = 3 Then
            MsgBox("Usuario registrado correctamente.")
            Response.Redirect("login.aspx")
        ElseIf resultadoTmp = 4 Then
            MsgBox("Error en envío de email.")
        Else
            MsgBox("Error desconocido.")
        End If

    End Sub
End Class