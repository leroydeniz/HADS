Public Class logout
    Inherits System.Web.UI.Page
    Dim objController = New LAB.Controller

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Logout")
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub

End Class