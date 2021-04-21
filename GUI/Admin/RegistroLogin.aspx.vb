Imports System.Data.SqlClient

Public Class RegistroLogin
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim xDataAdapter As New SqlDataAdapter()
    Dim xDataSet As New DataSet()
    Dim xDataTable As New DataTable
    Dim xDataRow As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Try
            ' Traigo el nuevo email del DropDownList
            Session.Contents("emailRegistro") = DropDownList1.Text

            Dim objRegistroLoginWS As New RegistroLoginWS.RegistroLoginSoapClient
            Session("xDataTable") = objRegistroLoginWS.registros(Session("emailRegistro"))

            ' Pego la tabla filtrada en el DataView y aplico los cambios a tiempo real
            GridView1.DataSource = Session("xDataTable")
            GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub
End Class