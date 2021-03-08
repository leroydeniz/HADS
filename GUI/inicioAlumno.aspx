<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicioAlumno.aspx.vb" Inherits="GUI.inicioAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Index</title>
    
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Dashboard Alumno</strong></span><br />
                            <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label>
                            <asp:Label ID="nombreusuario" runat="server"></asp:Label><br />
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            1. <asp:LinkButton ID="LinkCambioPassword" runat="server" PostBackUrl="cambiarPassword.aspx">Cambiar contraseña</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            2. <asp:LinkButton ID="LinkLogout" runat="server">Logout</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>     

    </form>
</body>
</html>