Public Class registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BtnRegister.Enabled = False
    End Sub

    Protected Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Dim objController = New LAB.Controller

        Dim pUser = email.Text
        Dim pNombre = nombre.Text
        Dim pApellidos = apellidos.Text
        Dim pPass = password.Text
        Dim pTipo = perfil.Text

        Dim resultadoTmp = objController.registro(pUser, pPass, pNombre, pApellidos, pTipo)

        ' Se crea el objeto que maneje el web service de Matrículas
        Dim objSWMatricula As New es.ehusw.Matriculas

        ' Se llama a la función comprobar de ese web service
        Dim flagMatriculado As String = objSWMatricula.comprobar(pUser)

        ' Si no está matriculado, devuelve el error 5, CC continúa
        If flagMatriculado = "NO" Then
            resultadoTmp = 5
        End If

        '0 - Usuario ya existe'
        '1 - Error de conexión a la base de datos
        '2 - Error de inserción en la base de datos'
        '3 - Registro correcto'
        '4 - Error en envío de email
        '5 - Usuario no matriculado por WS

        If resultadoTmp = 0 Then
            objController.registrarMovimiento(pUser, Session("tipo"), "Intento de registro")
            RespuestaDelServidor.Text = "Usuario ya existe! Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=login.aspx")
        ElseIf resultadoTmp = 1 Then
            RespuestaDelServidor.Text = "Error de conexión a la base de datos."
        ElseIf resultadoTmp = 2 Then
            RespuestaDelServidor.Text = "Error de inserción en al BD."
            Response.Redirect("verificar.aspx")
        ElseIf resultadoTmp = 3 Then
            objController.registrarMovimiento(pUser, Session("tipo"), "Registro")
            RespuestaDelServidor.Text = "Usuario registrado correctamente. Será redirigido en 3 segundos..."
            Response.AddHeader("REFRESH", "3;URL=login.aspx")
        ElseIf resultadoTmp = 4 Then
            RespuestaDelServidor.Text = "Error en envío de email."
        ElseIf resultadoTmp = 5 Then
            RespuestaDelServidor.Text = "Usuario no está matriculado."
        Else
            RespuestaDelServidor.Text = "Error desconocido."
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Se crea el objeto que maneje el web service de Matrículas
        Dim objSWMatricula As New es.ehusw.Matriculas

        ' Se llama a la función comprobar de ese web service
        Dim flagMatriculado As String = objSWMatricula.comprobar(email.Text)

        ' Si no está matriculado, devuelve el error 5, CC continúa
        If flagMatriculado = "NO" Then
            BtnRegister.Enabled = False
        Else
            BtnRegister.Enabled = True
        End If
    End Sub

End Class