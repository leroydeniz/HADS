Imports System.Data.SqlClient
Imports System.Xml

Public Class importarTareasDS
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")






    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")

        End If
    End Sub






    Protected Sub VolverAlMenu_Click(sender As Object, e As EventArgs) Handles VolverAlMenu.Click
        Response.AddHeader("REFRESH", "0;URL=../inicioProfesor.aspx")
    End Sub






    Protected Sub LinkLogout_Click(sender As Object, e As EventArgs) Handles LinkLogout.Click
        Session.Abandon()
        Response.AddHeader("REFRESH", "0;URL=../login.aspx")
    End Sub








    Protected Sub DropDownList11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList11.SelectedIndexChanged
        If DropDownList11.Text = " " Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
            Xml1.DocumentSource = Server.MapPath("../../App_Data/" & DropDownList11.Text & ".xml")
            Xml1.TransformSource = Server.MapPath("../../App_Data/VerTablaTareas.xsl")
            result.Text = ""
        End If
    End Sub








    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from TareasGenericas WHERE 0=1", conexion)
            Dim commandBuilder As New SqlCommandBuilder(da)
            Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("../../App_Data/" & DropDownList11.Text & ".xml"))
        Dim dt As New DataTable
        dt = ds.Tables(0)
        Dim dr As DataRow
            For Each dr In dt.Rows
                dr("codAsig") = DropDownList11.Text
            Next
            da.Update(ds.Tables(0))
            ds.AcceptChanges()
            result.Text = "TAREAS IMPORTADAS CORRECTAMENTE"
        'Catch ex As Exception
        '    result.Text = "ERROR. ALGUNA DE LAS TAREAS YA HA SIDO IMPORTADAS"
        'End Try

    End Sub







End Class