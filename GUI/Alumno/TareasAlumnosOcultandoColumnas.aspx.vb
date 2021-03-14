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
            Dim st As String = "SELECT * FROM TareasGenericas;"
            dapMbrs = New SqlDataAdapter(st, conClsf)
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "Miembros")
            tblMbrs = dstMbrs.Tables("Miembros")
            GridView1.DataSource = tblMbrs
            GridView1.DataBind()
            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs
            Session("tabla") = tblMbrs
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

End Class