Public Class verificarPassword
    Inherits System.Web.UI.Page
    Dim objController = New LAB.Controller

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objController = New LAB.Controller

        If objController.cuentaVerificada(Session.Contents("usuario")) = 1 Then
            Response.Write("<script>alert('Cuenta ya verificada.')</script>")
            If Session.Contents("tipo") = "Profesor" Then
                Response.AddHeader("REFRESH", "0;URL=../Profesor/inicioProfesor.aspx")
            Else
                Response.AddHeader("REFRESH", "0;URL=../Alumno/inicioAlumno.aspx")
            End If
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
            RespuestaDelServidor.Text = "Usuario ya confirmado!"
            If Session.Contents("tipo") = "Profesor" Then
                Response.AddHeader("REFRESH", "3;URL=../Profesor/inicioProfesor.aspx")
            Else
                Response.AddHeader("REFRESH", "3;URL=../Alumno/inicioAlumno.aspx")
            End If
        ElseIf resultadoTmp = 0 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Usuario no existe en la BD."
        ElseIf resultadoTmp = 3 Then
            RespuestaDelServidor.Text = "Cuenta verificada correctamente."
            If Session.Contents("tipo") = "Profesor" Then
                objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Cuenta Profesor verificada ")
                Response.AddHeader("REFRESH", "3;URL=../Profesor/inicioProfesor.aspx")
            Else
                objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Cuenta Alumno verificada ")
                Response.AddHeader("REFRESH", "3;URL=../Alumno/inicioAlumno.aspx")
            End If
        ElseIf resultadoTmp = 4 Then
            RespuestaDelServidor.Text = "Error de actualización en la base de datos."
        ElseIf resultadoTmp = 5 Then
            RespuestaDelServidor.Text = "Código de verificación incorrecto."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub

End Class