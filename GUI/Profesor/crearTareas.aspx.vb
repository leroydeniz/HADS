Imports System.Data.SqlClient

Public Class crearTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Contents("asignaturaElegida") = DropDownList1.Text

        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session.Contents("asignaturaElegida") = DropDownList1.Text
    End Sub


    Protected Sub BtnInsertarTarea_Click(sender As Object, e As EventArgs) Handles BtnInsertarTarea.Click
        Response.Redirect("InsertarNuevaTarea.aspx")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "1;URL=inicioProfesor.aspx")
    End Sub
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "1;URL=../login.aspx")
    End Sub
End Class