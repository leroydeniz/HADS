Public Class usuariosActivos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim profesoresListaHTML As String = ""
        Dim alumnosListaHTML As String = ""
        Dim adminsListaHTML As String = ""

        For i = 0 To Application("profesoresList").Count - 1
            profesoresListaHTML = profesoresListaHTML & "<br/>" & Application("profesoresList").Item(i)
        Next i

        For i = 0 To Application("alumnosList").Count - 1
            alumnosListaHTML = alumnosListaHTML & "<br/>" & Application("alumnosList").Item(i)
        Next i

        For i = 0 To Application("adminsList").Count - 1
            adminsListaHTML = adminsListaHTML & "<br/>" & Application("adminsList").Item(i)
        Next i

        profesoresLista.Text = profesoresListaHTML
        alumnosLista.Text = alumnosListaHTML
        adminsLista.Text = adminsListaHTML
    End Sub

End Class