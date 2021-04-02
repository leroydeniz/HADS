Public Class inicioProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usuarioText.Text = Session.Contents("usuario")
    End Sub

End Class