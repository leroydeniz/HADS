<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="usuariosActivos.aspx.vb" Inherits="GUI.usuariosActivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:Table ID="Table1" runat="server" BorderWidth="1">
        <asp:TableRow BackColor="#777777">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" Style="padding:20px;">.:: <b>Usuarios activos</b> ::.</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#aaaaaa">
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">Profesores</asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">Alumnos</asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">Admins</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ID="profesoresLista" HorizontalAlign="Center" ></asp:TableCell>
            <asp:TableCell ID="alumnosLista" HorizontalAlign="Center"></asp:TableCell>
            <asp:TableCell ID="adminsLista" HorizontalAlign="Center"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#aaaaaa">
            <asp:TableCell ID="profesoresTotal" HorizontalAlign="Center" BorderWidth="1">X/X</asp:TableCell>
            <asp:TableCell ID="alumnosTotal" HorizontalAlign="Center" BorderWidth="1">X/X</asp:TableCell>
            <asp:TableCell ID="adminsTotal" HorizontalAlign="Center" BorderWidth="1">X/X</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</body>
</html>
