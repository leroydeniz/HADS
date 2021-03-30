Imports System.Data.SqlClient
Public Class InstanciarTarea
    Inherits System.Web.UI.Page

    Dim datos As GridViewRow
    Dim usuario As String
    Dim Codigo As String
    Dim Descripcion As String
    Dim CodAsig As String
    Dim HEstimadas As String
    Dim tipoTarea As String
    Dim HReales As String

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim tareasAdapter As New SqlDataAdapter()
    Dim tareas As New DataSet
    Dim tareasTabla As New DataTable
    Dim tareasDataView As DataView
    Dim objController = New LAB.Controller

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        usuarioText.Text = Session.Contents("usuario")

        datos = Session("datosFila")
        usuario = Session("usuario")
        Codigo = datos.Cells(1).Text
        Descripcion = datos.Cells(2).Text
        CodAsig = datos.Cells(3).Text
        HEstimadas = datos.Cells(5).Text
        tipoTarea = datos.Cells(4).Text

        TBusuario.Text = usuario
        TBtarea.Text = Codigo
        TBhorasEstimadas.Text = HEstimadas

        ' 1 - SQL - Consulta de la tabla que trae
        Dim consulta As String = "SELECT * from EstudiantesTareas where Email = '" & usuario & "';"

        ' 2 - Adapter - Establece la conexión y ejecuta el select
        tareasAdapter = New SqlDataAdapter(consulta, conexion)

        ' 3 - Fill - Trae los datos al dataset en memoria
        tareasAdapter.Fill(tareas)

        ' 4 - Tables - para elegir la tabla dentro del DataSet
        tareasTabla = tareas.Tables(0)

        ' 5 - SQLCommandBuilder - Establece automáticamente las consultas de INSERT, UPDATE y DELETE
        Dim tareasBuilder As New SqlCommandBuilder(tareasAdapter)

        GridView2.DataSource = tareasTabla
        GridView2.DataBind()

        ' 7 - Se guardan en sesión los datos que se reutilizarán
        Session("tareasTabla") = tareasTabla
        Session("tareasAdapter") = tareasAdapter
        Session("tareasDataSet") = tareas


    End Sub

    Protected Sub BtnInstanciar_Click(sender As Object, e As EventArgs) Handles BtnInstanciar.Click
        Codigo = TBtarea.Text
        HEstimadas = TBhorasEstimadas.Text
        HReales = TBHorasReales.Text
        Try
            Dim ds As New DataSet
            ds = Session("tareasDataSet")
            Dim dr As DataRow
            dr = ds.Tables(0).NewRow()
            dr.Item(0) = Session("usuario")
            dr.Item(1) = Codigo
            dr.Item(2) = HEstimadas
            dr.Item(3) = HReales

            ds.Tables(0).Rows.Add(dr)

            Session("tareasAdapter").Update(tareas)
            tareas.AcceptChanges()

            objController.registrarMovimiento(Session("usuario"), Session("tipo"), "Tarea instanciada")
            RespuestaDelServidor.Text = "Tarea instanciada correctamente."
            Response.AddHeader("REFRESH", "0;URL=InstanciarTarea.aspx")
        Catch ex As Exception
            RespuestaDelServidor.Text = "La tarea ya ha sido instanciada."
        End Try
    End Sub

    Protected Sub TBHorasReales_TextChanged(sender As Object, e As EventArgs) Handles TBHorasReales.TextChanged

    End Sub
    Protected Sub VerTareas_Click(sender As Object, e As EventArgs) Handles VerTareas.Click
        Response.AddHeader("REFRESH", "0;URL=TareasAlumnosOcultandoColumnas.aspx")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioAlumno.aspx")
    End Sub



End Class