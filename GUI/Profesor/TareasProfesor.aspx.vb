Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usuarioText.Text = Session.Contents("usuario")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioProfesor.aspx")
    End Sub



    Protected Sub BtnInsertarTarea_Click(sender As Object, e As EventArgs) Handles BtnInsertarTarea.Click
        Response.Redirect("InsertarNuevaTarea.aspx")
    End Sub

End Class