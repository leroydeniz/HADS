Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class RegistroLogin
    Inherits System.Web.Services.WebService
    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim xDataAdapter As New SqlDataAdapter()
    Dim xDataSet As New DataSet()
    Dim xDataTable As New DataTable

    <WebMethod()>
    Public Function registros(pUser As String) As DataTable

        ' 1 - SQL - Consulta de la tabla que trae
        Dim st As String = "SELECT TOP 20 * FROM Registro where email='" & pUser & "' order by fecha DESC"

        ' 2 - Adapter - Ejecuta la consulta y establece la conexión
        xDataAdapter = New SqlDataAdapter(st, conexion)

        ' 4 - Fill - Trae los datos al dataset en memoria
        xDataAdapter.Fill(xDataSet)

        ' 5 - Tables - para elegir la tabla dentro del DataSet
        xDataTable = xDataSet.Tables(0)

        Return xDataTable

    End Function

End Class