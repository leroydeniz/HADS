Public Class DedicacionesMedia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usuarioText.Text = Session.Contents("usuario")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=../Profesor/inicioProfesor.aspx")
    End Sub

    Protected Sub btnVerDedicacion_Click(sender As Object, e As EventArgs) Handles btnVerDedicacion.Click
        Dim objDedicacionMediaWS As New DedicacionMediaWS.WebService1
        Dim dedicacionMedia As Double = objDedicacionMediaWS.DedicacionMadia(DropDownList1.Text)
        If dedicacionMedia = -1 Then
            resultado.Text = "Esta asignatura no tiene registros de dedicación"
        Else
            resultado.Text = "Dedicacion media: " + dedicacionMedia.ToString
        End If
    End Sub
End Class