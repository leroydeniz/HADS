Public Class InstanciarTarea
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim datos As GridViewRow = Session("datosFila")
        Dim usuario As String = Session("usuario")
        Dim Codigo As String = datos.Cells(0).Text
        Dim Descripcion As String = datos.Cells(1).Text
        Dim CodAig As String = datos.Cells(2).Text
        Dim HEstimadas As String = datos.Cells(4).Text
        Dim tipoTarea As String = datos.Cells(3).Text

        TBusuario.Text = usuario
        TBtarea.Text = tipoTarea
        TBhorasEstimadas.Text = HEstimadas

        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
        End If
    End Sub

    Protected Sub BtnInstanciar_Click(sender As Object, e As EventArgs) Handles BtnInstanciar.Click
        Dim datos As GridViewRow = Session("datosFila")
        Dim usuario As String = Session("usuario")
        Dim CodAsig As String = TBtarea.Text
        Dim HEstimadas As String = TBhorasEstimadas.Text
        Dim HReales = TBHorasReales.Text
        Dim objController = New LAB.Controller
        If objController.instanciarTarea(usuario, CodAsig, HEstimadas, HReales) Then
            RespuestaDelServidor.Text = "Tarea Instanciada correctamente."
            Response.AddHeader("REFRESH", "1;URL=InstanciarTarea.aspx")
        Else
            RespuestaDelServidor.Text = "La tarea ya ha sido instanciada"
        End If

    End Sub

    Protected Sub TBHorasReales_TextChanged(sender As Object, e As EventArgs) Handles TBHorasReales.TextChanged

    End Sub
    Protected Sub VerTareas_Click(sender As Object, e As EventArgs) Handles VerTareas.Click
        Response.AddHeader("REFRESH", "1;URL=TareasAlumnosOcultandoColumnas.aspx")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "1;URL=inicioAlumno.aspx")
    End Sub
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "1;URL=../login.aspx")
    End Sub
End Class