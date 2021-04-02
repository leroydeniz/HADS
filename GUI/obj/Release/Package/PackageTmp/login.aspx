<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="GUI.login"  Debug="true" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
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
    <form id="loginForm" runat="server">
        <div>
            <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Login</strong></span><br />
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Email:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="email" runat="server" textMode="email"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="password" runat="server" textMode="password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br /> 
                            <asp:Button ID="BtnLogin" runat="server" Height="44px" Text="Login" Width="221px" />
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <asp:LinkButton ID="LinkRegistro" runat="server" PostBackUrl="registro.aspx">Quiero registrarme</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="LinkRecuperarContrasena" runat="server" PostBackUrl="recuperarPassword.aspx">Recuperar contraseña</asp:LinkButton>
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <asp:Label ID="RespuestaDelServidor" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <br />
                            <br />
                            <br /><asp:Label ID="Label1" runat="server" style="text-align: center" Text="Label"></asp:Label>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>      
        </div>
    </form>
</body>
</html>