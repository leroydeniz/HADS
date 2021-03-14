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
    End Sub

    Protected Sub BtnInstanciar_Click(sender As Object, e As EventArgs) Handles BtnInstanciar.Click
        Dim datos As GridViewRow = Session("datosFila")
        Dim usuario As String = Session("usuario")
        Dim Codigo As String = datos.Cells(0).Text
        Dim Descripcion As String = datos.Cells(1).Text
        Dim CodAsig As String = datos.Cells(2).Text
        Dim HEstimadas As String = datos.Cells(3).Text
        Dim tipoTarea As String = datos.Cells(4).Text
        Dim HReales = TBHorasReales.Text
        Dim objController = New LAB.Controller
        If objController.instanciarTarea(usuario, CodAsig, HReales) Then
            RespuestaDelServidor.Text = "Tarea Instanciada correctamente"
        Else
            RespuestaDelServidor.Text = "Ha ocurrido un error y la tarea no ha sido instanciada"
        End If
    End Sub

    Protected Sub TBHorasReales_TextChanged(sender As Object, e As EventArgs) Handles TBHorasReales.TextChanged

    End Sub
End Class