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
        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
        End If
    End Sub

    Protected Sub BtnAñadirTarea_Click(sender As Object, e As EventArgs) Handles BtnAñadirTarea.Click
        vCodigo = codigo.Text
        vDescripcion = descripcion.Text
        vHorasEstimadas = horasEstimadas.Text

        If objController.insertarTarea(vCodigo, vDescripcion, vAsignatura, vHorasEstimadas, vTipoTarea) Then
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
        Response.AddHeader("REFRESH", "1;URL=inicioProfesor.aspx")
    End Sub
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "1;URL=../login.aspx")
    End Sub
End Class