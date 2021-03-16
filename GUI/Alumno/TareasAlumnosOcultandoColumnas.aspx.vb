Imports System.Data.SqlClient

Public Class TareasAlumnosOcultandoColumnas
    Inherits System.Web.UI.Page

    Dim conClsf As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstMbrs = Session("datos")
        Else
            Session("asignaturaElegida") = DropDownList1.Text

            ' 1 - SQL - Consulta de la tabla que trae
            Dim st As String = "SELECT Codigo,Descripcion,CodAsig, HEstimadas,TipoTarea FROM TareasGenericas WHERE Explotacion='True' AND Codigo NOT IN (SELECT CodTarea FROM EstudiantesTareas WHERE email='" & Session("usuario") & "');"

            ' 2 - Adapter - Ejecuta la consutla y establece la conexión
            dapMbrs = New SqlDataAdapter(st, conClsf)

            ' 3 - SQLCommandBuilder - Establece automáticamente las consultas de INSERT, SELECT, UPDATE y DELETE
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)

            ' 5 - Fill - Trae los datos al dataset en memoria
            dapMbrs.Fill(dstMbrs, "Miembros")

            ' 6 - Tables - para elegir la tabla dentro del DataSet
            tblMbrs = dstMbrs.Tables("Miembros")

            ' 7 - Se guardan en sesión los datos que se reutilizarán
            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs
            Session("tabla") = tblMbrs
        End If

        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session.Contents("datosFila") = GridView1.SelectedRow
        Response.Redirect("InstanciarTarea.aspx")
    End Sub

    'A partir de aquí no funciona' 
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("asignaturaElegida") = DropDownList1.Text
        Dim dv As DataView = tblMbrs.DefaultView
        dv = New DataView(Session("tabla"))
        Dim st As String = "codAsig= '" & Session("asignaturaElegida") & "'"
        dv.RowFilter = st
        GridView1.DataSource = dv
        GridView1.DataBind()
    End Sub
    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=inicioAlumno.aspx")
    End Sub
    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub
End Class