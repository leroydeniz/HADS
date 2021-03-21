﻿Imports System.Data.SqlClient
Imports System.Xml

Public Class importarTareas
    Inherits System.Web.UI.Page
    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:jorgehads.database.windows.net,1433;Initial Catalog=HADS-Jorge;Persist Security Info=False;User ID=trabajo.jorge2000@gmail.com@jorgehads;Password=Marmota69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dataAdapter As New SqlDataAdapter()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session.Contents("usuario")) Then
            Response.Redirect("../login.aspx")
        Else
            usuarioText.Text = Session.Contents("usuario")
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
        Xml1.DocumentSource = Server.MapPath("xml/" & DropDownList11.Text & ".xml")
        Xml1.TransformSource = Server.MapPath("xml/VerTablaTareas.xsl")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            ' 1 - SQL - Consulta de la tabla que trae
            Dim consulta As String = "SELECT Codigo,Descripcion,CodAsig, HEstimadas,Explotacion,TipoTarea FROM TareasGenericas WHERE Explotacion='True' AND Codigo NOt in (SELECT CodTarea FROM EstudiantesTareas WHERE email='" & Session("usuario") & "');"

            ' 2 - Adapter - Ejecuta la consutla y establece la conexión
            dataAdapter = New SqlDataAdapter(consulta, conexion)

            ' 3 - SQLCommandBuilder - Establece automáticamente las consultas de AMB
            Dim tareasBuilder As New SqlCommandBuilder(dataAdapter)

            ' 4 - Creo el dataset para guardar los datos
            Dim tareasDataSet As New DataSet

            ' 5 - Fill - Trae los datos al dataset en memoria
            dataAdapter.Fill(tareasDataSet)


            ' Creo un DataTable y defino su estructura de columnas
            Dim tareasDataTable As New DataTable
            tareasDataTable.Columns.Add("Codigo", GetType(String))
            tareasDataTable.Columns.Add("Descripcion", GetType(String))
            tareasDataTable.Columns.Add("CodAsig", GetType(String))
            tareasDataTable.Columns.Add("HEstimadas", GetType(Integer))
            tareasDataTable.Columns.Add("Explotacion", GetType(Integer))
            tareasDataTable.Columns.Add("TipoTarea", GetType(String))

            ' 6 - Tables - para elegir la tabla dentro del DataSet
            tareasDataTable = tareasDataSet.Tables(0)

            ' Creo e inicializo a vacío un nuevo objeto de tipo XMLDocument para asignarle el contenido del Archivo XML
            Dim xmldoc As New XmlDocument()
            xmldoc = New XmlDocument()

            ' Cargo el contenido del archivo XML en una variable de tipo XmlDocument
            xmldoc.Load(Server.MapPath("xml/" & DropDownList11.Text & ".xml"))

            ' Creo un nuevo XmlNodeList que tendrá la lista de todos los nodos del DOM tareas -> tarea *
            Dim tareasList As XmlNodeList

            ' Creo una XmlNode que cargará cada dato de la lista
            Dim tarea As XmlNode

            ' Creo un DataRow que me permita ir llenando fila a fila al DataTable con los datos de cada nodo 'tarea' del XML
            Dim Fila As DataRow = tareasDataTable.NewRow

            'Cargo el DOM con todos los primeros nodos de tipo 'tarea'
            tareasList = xmldoc.GetElementsByTagName("tarea")

            ' Para cada nodo tarea del XML, voy cargando cada columna de la Row
            For Each tarea In tareasList
                Fila("Codigo") = tarea.Attributes.GetNamedItem("codigo").Value
                Fila("Descripcion") = tarea.ChildNodes(0).InnerText
                Fila("CodAsig") = DropDownList11.Text
                Fila("HEstimadas") = tarea.ChildNodes(1).InnerText

                If (tarea.ChildNodes(2).InnerText = "false") Then
                    Fila("Explotacion") = 0
                Else
                    Fila("Explotacion") = 1
                End If

                Fila("TipoTarea") = tarea.ChildNodes(3).InnerText

                ' Agrego la fila al DataTable
                tareasDataTable.ImportRow(Fila)

            Next

            Dim actualizadas = dataAdapter.Update(tareasDataSet)
            If actualizadas = 0 Then
                result.Text = "No se actualizaron"
            Else
                result.Text = "OK"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub
End Class