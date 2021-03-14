<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="GUI.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            Usuario<asp:TextBox ID="TBusuario" runat="server" ReadOnly="true" Width="100px" value=""/><br />
            Tarea<asp:TextBox ID="TBtarea" runat="server" ReadOnly="true" Width="100px" value=""/><br />
            Horas Estimadas<asp:TextBox ID="TBhorasEstimadas" runat="server" ReadOnly="true" Width="100px" value=""/><br />
            Horas Reales<asp:TextBox ID="TBHorasReales" runat="server"  Width="100px" value=""/><br />
         <asp:Button ID="BtnInstanciar" runat="server" Height="44px" Text="Instanciar" Width="221px" />
            <br />
         <asp:Label ID="RespuestaDelServidor" runat="server" Text=""/>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:BoundField DataField="HReales" HeaderText="HReales" SortExpression="HReales" />
            </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT [Email], [Codigo], [HEstimadas], [HReales] FROM [TareasPersonales] WHERE ([Email] = @Email)">
                <SelectParameters>
                    <asp:SessionParameter Name="Email" SessionField="ususario" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    </form>
</body>
</html>
