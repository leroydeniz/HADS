Public Class InsertarNuevaTarea
    Inherits System.Web.UI.Page
    Dim vCodigo As String
    Dim vDescripcion As String
    Dim vAsignatura As String
    Dim vHorasEstimadas As String
    Dim vTipoTarea As String
    Dim objController = New LAB.Controller

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vAsignatura = DropDownList1.Text
        vTipoTarea = DropDownList2.Text
        usuarioText.Text = Session.Contents("usuario")
    End Sub

    Protected Sub BtnAñadirTarea_Click(sender As Object, e As EventArgs) Handles BtnAñadirTarea.Click
        vCodigo = codigo.Text
        vDescripcion = descripcion.Text
        vHorasEstimadas = horasEstimadas.Text

        If objController.insertarTarea(vCodigo, vDescripcion, vAsignatura, vHorasEstimadas, vTipoTarea) Then
            objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Insertar nueva tarea")
            Label0.Text = "Pregunta introducida correctamente"
        Else
            Label0.Text = "Error al introducir la pregunta"
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        vAsignatura = DropDownList1.Text
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        vTipoTarea = DropDownList2.Text
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioProfesor.aspx")
    End Sub

End Class