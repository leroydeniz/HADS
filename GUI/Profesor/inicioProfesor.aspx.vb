Public Class inicioProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usuarioText.Text = Session.Contents("usuario")
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim profesoresListaHTML As String = ""
        Dim alumnosListaHTML As String = ""
        Dim adminsListaHTML As String = ""

        Dim totalConectados As Integer = 0
        Dim profesoresConectadosTotal As Integer = 0
        Dim alumnosConectadosTotal As Integer = 0
        Dim adminsConectadosTotal As Integer = 0


        For i = 0 To Application("profesoresList").Count - 1
            profesoresListaHTML = profesoresListaHTML & "<br/>" & Application("profesoresList").Item(i)
            profesoresConectadosTotal = profesoresConectadosTotal + 1
            totalConectados = totalConectados + 1
        Next i

        For i = 0 To Application("alumnosList").Count - 1
            alumnosListaHTML = alumnosListaHTML & "<br/>" & Application("alumnosList").Item(i)
            alumnosConectadosTotal = alumnosConectadosTotal + 1
            totalConectados = totalConectados + 1
        Next i

        For i = 0 To Application("adminsList").Count - 1
            adminsListaHTML = adminsListaHTML & "<br/>" & Application("adminsList").Item(i)
            adminsConectadosTotal = adminsConectadosTotal + 1
            totalConectados = totalConectados + 1
        Next i

        profesoresLista.Text = profesoresListaHTML
        alumnosLista.Text = alumnosListaHTML
        adminsLista.Text = adminsListaHTML

        profesoresTotal.Text = CStr(profesoresConectadosTotal) + " profesores de<br/>" + CStr(totalConectados) + " usuarios conectados."
        alumnosTotal.Text = CStr(alumnosConectadosTotal) + " alumnos de<br/>" + CStr(totalConectados) + " usuarios conectados."
        adminsTotal.Text = CStr(adminsConectadosTotal) + " admins de<br/>" + CStr(totalConectados) + " usuarios conectados."

    End Sub
End Class