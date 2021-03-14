<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumnosOcultandoColumnas.aspx.vb" Inherits="GUI.TareasAlumnosOcultandoColumnas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Seleccionar Asignatura:
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig" AutoPostBack="True"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [tareasAlumnos] WHERE ([Email] = @Email)">
            <SelectParameters>
                <asp:SessionParameter Name="Email" SessionField="usuario" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                   <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Instanciar" />
                </Columns>
            </asp:GridView>
            <br />
           
        </div>
    </form>
</body>
</html>
