<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="importarTareas.aspx.vb" Inherits="GUI.importarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <h1>Importar tareas XML XMLDocument </h1>
                            <h2>Profesor: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            Asignatura:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="true" DataTextField="CodAsig" DataValueField="CodAsig"/>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br />
                            <asp:Button ID="Button1" runat="server" Text="Importar tareas" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="result" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br /><br /><asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="LinkLogout" runat="server">Logout</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>

        </div>
    </form>
</body>
</html>
