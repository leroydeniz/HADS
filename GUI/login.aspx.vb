Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("index.aspx")
        End If

    End Sub

    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        'Definir la instancia del controlador'
        Dim objController = New LAB.Controller

        'Traer variables del formulario '
        Dim pEmail = email.Text
        Dim pPass = password.Text

        Dim resultadoTmp As String
        resultadoTmp = objController.login(pEmail, pPass)

        '0 - Error de conexión a la base de datos'
        '1 - Usuario registrado y verificado'
        '2 - Usuario registrado sin verificar'
        '3 - Usuario no existe'


        If resultadoTmp = 1 Then

            'Se trae la información del usuario de la base de datos para cargar en la sesión' 
            If (guardarDatos(objController, pEmail)) Then
                RespuestaDelServidor.Text = "Bienvenido!. Será redirigido en 3 segundos..."
                'Elige a qué perfil enviarlo'
                If Session.Contents("tipo") = "Profesor" Then
                    Response.AddHeader("REFRESH", "3;URL=inicioProfesor.aspx")
                Else
                    Response.AddHeader("REFRESH", "3;URL=inicioAlumno.aspx")
                End If
            Else RespuestaDelServidor.Text = "Error al crear el perfil de sesion."
            End If
        ElseIf resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            If (guardarDatos(objController, pEmail)) Then
                RespuestaDelServidor.Text = "Debe verificar el usuario antes de continuar. Será redirigido en 3 segundos..."
                Response.AddHeader("REFRESH", "3;URL=verificarCuenta.aspx")
            Else
                RespuestaDelServidor.Text = "Error al crear el perfil de sesion."
            End If
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Usuario o contraseña incorrectos."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If
    End Sub

    Private Function guardarDatos(objCotnroler As LAB.Controller, pEmail As String) As Boolean
        Try
            Dim userData = objCotnroler.getUserData(pEmail)
            Session.Contents("usuario") = userData(0)
            Session.Contents("nombre") = userData(1)
            Session.Contents("apellidos") = userData(2)
            Session.Contents("numconfir") = userData(3)
            Session.Contents("confirmado") = userData(4)
            Session.Contents("tipo") = userData(5)
            Session.Contents("pass") = userData(6)
            Session.Contents("codpass") = userData(7)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function
End Class