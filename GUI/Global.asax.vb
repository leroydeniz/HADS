Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        ' Versión de la aplicación global
        Application("version") = "v7.2.1"

        Dim profesoresList As New List(Of String)
        Dim alumnosList As New List(Of String)
        Dim adminsList As New List(Of String)

        ' Se definen las dos listas de usuarios logueados en la aplicación
        Application("profesoresList") = profesoresList
        Application("alumnosList") = alumnosList
        Application("adminsList") = adminsList

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión

        If (Session("tipo") = "Profesor") Then
            Application("profesoresList").remove(Session("usuario"))
        ElseIf (Session("tipo") = "Alumno") Then
            Application("alumnosList").remove(Session("usuario"))
        Else
            Application("adminsList").remove(Session("usuario"))
        End If

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class