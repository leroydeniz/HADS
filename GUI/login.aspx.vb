Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsNothing(Session.Contents("usuario"))) Then
            'MsgBox("Usuario ya logueado.")'
            Response.Redirect("index.aspx")
        End If

    End Sub

    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        'Definir la instancia del controlador'
        Dim objController = New LAB.Controller

        'Traer variables del formulario'
        Dim pEmail = email.Text
        Dim pPass = password.Text

        Dim resultadoTmp As String
        resultadoTmp = objController.login(pEmail, pPass)

        '0 - Error de conexión a la base de datos'
        '1 - Usuario registrado y verificado'
        '2 - Usuario registrado sin verificar'
        '3 - Usuario no existe'

        If resultadoTmp = 1 Then
            Session.Contents("usuario") = pEmail
            RespuestaDelServidor.Text = "Bienvenido!. Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=index.aspx")
        ElseIf resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            Session.Contents("usuario") = pEmail
            RespuestaDelServidor.Text = "Debe verificar el usuario antes de continuar. Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=verificarCuenta.aspx")
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Usuario o contraseña incorrectos."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub

End Class