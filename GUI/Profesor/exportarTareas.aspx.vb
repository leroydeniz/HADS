Imports System.Data.SqlClient
Imports System.Xml

Public Class exportarTareas
    Inherits System.Web.UI.Page
    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dataAdapter As New SqlDataAdapter()
    Dim tareasTabla = New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")

            If Not Page.IsPostBack Then
                Try
                    ' Traigo la nueva asignatura elegida del DropDownList
                    Session.Contents("asignaturaElegida") = DropDownList11.Text

                    ' 1 - SQL - Consulta de la tabla que trae
                    Dim consulta As String = "SELECT Codigo, CodAsig, Descripcion, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas WHERE CodAsig IN (SELECT DISTINCT CodAsig FROM crearTareasProfesor WHERE email = '" & Session("usuario") & "');"

                    ' 2 - Adapter - Ejecuta la consutla y establece la conexión
                    dataAdapter = New SqlDataAdapter(consulta, conexion)

                    ' 3 - SQLCommandBuilder - Establece automáticamente las consultas de AMB
                    Dim tareasBuilder As New SqlCommandBuilder(dataAdapter)

                    Dim tareasDataSet As New DataSet

                    dataAdapter.Fill(tareasDataSet)

                    tareasTabla = tareasDataSet.Tables(0)

                    Session("dataAdapter") = dataAdapter
                    Session("tareasDataSet") = tareasDataSet
                    Session("tareasTabla") = tareasTabla

                Catch ex As Exception
                    Mensaje.Text = ex.Message
                End Try
            End If

        End If
    End Sub

    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioProfesor.aspx")
    End Sub

    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub

    Protected Sub DropDownList11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList11.SelectedIndexChanged

        Try
            ' Traigo la nueva asignatura elegida del DropDownList
            Session.Contents("asignaturaElegida") = DropDownList11.Text

            ' Cargo la tabla de todas las tareas que tengo en la sesión
            Dim tareasDataView As DataView = tareasTabla.DefaultView
            tareasDataView = New DataView(Session("tareasTabla"))

            ' Elijo el filtro que voy a hacer de toda la tabla completa
            Dim filtro As String = "CodAsig = '" & Session("asignaturaElegida") & "'"

            ' Aplico el filtro
            tareasDataView.RowFilter = filtro

            ' Pego la tabla filtrada en el DataView y aplico los cambios a tiempo real
            GridView1.DataSource = tareasDataView
            GridView1.DataBind()
        Catch ex As Exception
            Mensaje.Text = ex.Message
        End Try
    End Sub


    Protected Sub ExportarXML_Click(sender As Object, e As EventArgs) Handles ExportarXML.Click

        Try
            ' Creo una instancia de un nuevo objeto XML
            Dim xmldoc As New XmlDocument

            ' Defino su declaración
            Dim declaracion As XmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", Nothing, Nothing)
            xmldoc.AppendChild(declaracion)

            ' Defino el nodo DOM y lo agrego al archivo
            Dim xmlroot As XmlElement = xmldoc.CreateElement("tareas")
            xmldoc.AppendChild(xmlroot)



            ' Guardo el archivo
            xmldoc.Save(Server.MapPath("export/" & Session("asignaturaElegida") & ".xml"))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub ExportarJSON_Click(sender As Object, e As EventArgs) Handles ExportarJSON.Click

    End Sub
End Class