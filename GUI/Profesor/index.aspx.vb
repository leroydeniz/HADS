Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            'MsgBox("Usuario no logueado.")'
            Response.Redirect("login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
        End If
    End Sub

    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.Redirect("login.aspx")
    End Sub
End Class