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

    Dim conexionT As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim tareasAdapter As New SqlDataAdapter()
    Dim tareasDataSet As New DataSet
    Dim tareasTabla As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")

            datos = Session("datosFila")
            usuario = Session("usuario")
            Codigo = datos.Cells(1).Text
            Descripcion = datos.Cells(2).Text
            CodAsig = datos.Cells(3).Text
            HEstimadas = datos.Cells(4).Text
            tipoTarea = datos.Cells(5).Text

            TBusuario.Text = usuario
            TBtarea.Text = Codigo
            TBhorasEstimadas.Text = HEstimadas

            If Page.IsPostBack Then
            Else
                ' 1 - SQL - Consulta de la tabla que trae
                Dim consulta As String = "SELECT * from TareasGenericas where email = '" & usuario & "');"

                ' 2 - Adapter - Ejecuta la consulta y establece la conexión
                tareasAdapter = New SqlDataAdapter(consulta, conexionT)

                ' 3 - SQLCommandBuilder - Establece automáticamente las consultas de INSERT, SELECT, UPDATE y DELETE
                Dim tareasBuilder As New SqlCommandBuilder(tareasAdapter)

                ' 5 - Fill - Trae los datos al dataset en memoria
                tareasAdapter.Fill(tareasDataSet, "tareasDataSet")

                ' 6 - Tables - para elegir la tabla dentro del DataSet
                tareasTabla = tareasDataSet.Tables("tareasDataSet")

                ' 7 - Se guardan en sesión los datos que se reutilizarán
                Session("tareasTabla") = tareasTabla
                Session("tareasAdapter") = tareasAdapter
                Session("tareasDataSet") = tareasDataSet
            End If
        End If

    End Sub

    Protected Sub BtnInstanciar_Click(sender As Object, e As EventArgs) Handles BtnInstanciar.Click
        Codigo = TBtarea.Text
        HEstimadas = TBhorasEstimadas.Text
        HReales = TBHorasReales.Text

        Dim consulta As String = "INSERT INTO TareasGenericas(Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea) VALUES ('" & Codigo & "', '" & Descripcion & "', '" & CodAsig & "', '" & HEstimadas & "', 'false', '" & tipoTarea & "');"

        Session("tareasAdapter").Update(Session("tareasDataSet"), "tareasDataSet")
        Session("tareasDataSet").AcceptChanges()

        RespuestaDelServidor.Text = "Tarea Instanciada correctamente."
        Response.AddHeader("REFRESH", "0;URL=InstanciarTarea.aspx")

    End Sub

    Protected Sub TBHorasReales_TextChanged(sender As Object, e As EventArgs) Handles TBHorasReales.TextChanged

    End Sub
    Protected Sub VerTareas_Click(sender As Object, e As EventArgs) Handles VerTareas.Click
        Response.AddHeader("REFRESH", "0;URL=TareasAlumnosOcultandoColumnas.aspx")
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioAlumno.aspx")
    End Sub
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub



End Class