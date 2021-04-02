Public Class logout
    Inherits System.Web.UI.Page
    Dim objController = New LAB.Controller

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Session("tipo") = "Profesor") Then
            Application("profesoresList").remove(Session("usuario"))
        ElseIf (Session("tipo") = "Alumno") Then
            Application("alumnosList").remove(Session("usuario"))
        Else
            Application("adminsList").remove(Session("usuario"))
        End If

        objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Logout")
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub

End Class