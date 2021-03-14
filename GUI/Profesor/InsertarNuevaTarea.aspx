<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarNuevaTarea.aspx.vb" Inherits="GUI.InsertarNuevaTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Profesor Gestion de Tareas Genericas<br />
            Codigo: <asp:TextBox ID="codigo" runat="server"/> <br />
            Descripcion:<asp:TextBox ID="descripcion" runat="server" /> <br /> 
            Asignatura: <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig"/>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource> <br />
            Horas Estimadas:  <asp:TextBox ID="horasEstimadas" runat="server" type="number"/>
            <br />
            Tipo Tarea: <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="laboratorio" Text="Laboratorio"></asp:ListItem>
                <asp:ListItem Value="trabajo" Text="Trabajo"></asp:ListItem>
                <asp:ListItem Value="ejercicio" Text="Ejercicio"></asp:ListItem>
                <asp:ListItem Value="examen" Text="Examen"></asp:ListItem>
            </asp:DropDownList> 
            <br />
                <asp:Label ID="Label0" runat="server" Text=""/>
            <br />
        </div> <br />
            <asp:Button ID="BtnAñadirTarea" runat="server" Height="44px" Text="Añadir Tarea" Width="221px" />
        <br />
        <asp:LinkButton ID="LinkVerTareas" runat="server" PostBackUrl="crearTareas.aspx">Ver Tareas</asp:LinkButton>
    </form>
    
    </body>
</html>
