Imports System.Data.SqlClient

Public Class RegistroLogin
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim xDataAdapter As New SqlDataAdapter()
    Dim xDataSet As New DataSet()
    Dim xDataTable As New DataTable
    Dim xDataRow As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim xEmail As String = DropDownList1.Text

        ' 1 - SQL - Consulta de la tabla que trae
        Dim st As String = "SELECT * FROM Registro"

        ' 2 - Adapter - Ejecuta la consulta y establece la conexión
        xDataAdapter = New SqlDataAdapter(st, conexion)

        ' 3 - SQLCommandBuilder - Establece automáticamente las consultas de INSERT,  UPDATE y DELETE
        Dim xCommandBuilder As New SqlCommandBuilder(xDataAdapter)

        ' 4 - Fill - Trae los datos al dataset en memoria
        xDataAdapter.Fill(xDataSet)

        ' 5 - Tables - para elegir la tabla dentro del DataSet
        xDataTable = xDataSet.Tables(0)

        ' 6 - Se guardan en sesión los datos que se reutilizarán
        Session("xDataSet") = xDataSet
        Session("xDataAdapter") = xDataAdapter
        Session("xDataTable") = xDataTable

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Try
            ' Traigo el nuevo email del DropDownList
            Session.Contents("emailRegistro") = DropDownList1.Text

            ' Cargo la tabla de todas las tareas que tengo en la sesión
            Dim xDataView As DataView = xDataTable.DefaultView
            xDataView = New DataView(Session("xDataTable"))

            ' Elijo el filtro que voy a hacer de toda la tabla completa
            Dim filtro As String = "email = '" & DropDownList1.Text & "'"

            ' Aplico el filtro
            xDataView.RowFilter = filtro
            Session("tareasFiltradas") = xDataView.ToTable

            ' Pego la tabla filtrada en el DataView y aplico los cambios a tiempo real
            GridView1.DataSource = xDataView
            GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub
End Class