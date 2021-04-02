Public Class tareasFiltradas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim asig As String = UCase(Request.QueryString("asig"))
        Session("asignaturaElegida") = asig
    End Sub

End Class