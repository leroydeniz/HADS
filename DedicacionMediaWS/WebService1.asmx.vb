Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService
    Private Shared conexion As New SqlConnection

    <WebMethod()>
    Public Function DedicacionMadia(pAsignatura As String) As Double
        Dim result As Integer = -1
        Try
            conexion.ConnectionString = "Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
            Dim query = "SELECT AVG(tareasE.HReales) 
                    FROM EstudiantesTareas as tareasE INNER JOIN TareasGenericas as tareasG ON tareasE.CodTarea=tareasG.Codigo
                    WHERE CodAsig='" & pAsignatura & "'"
            Dim comando = New SqlCommand(query, conexion)
            result = comando.ExecuteScalar()
        Catch ex As Exception
            conexion.Close()
            Return -1
        End Try
        conexion.Close()
        Return result

    End Function

End Class