<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="recuperarPassword.aspx.vb" Inherits="GUI.recuperarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cambiar contraseña</title>
</head>
<body>
    <form id="formCambiarPassword" runat="server">
        <div>
            <div class="auto-style1">
                <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="2" HorizontalAlign="Center" BorderColor="#0F423F" BorderWidth="1px">
                    
                    <asp:TableRow BorderWidth="1">
                        <asp:TableCell>
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Recuperar password</strong></span><br />
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Email:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="email" runat="server" textMode="Email"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <asp:Button ID="BtnCambiarPassword" runat="server" Height="44px" style="text-align: center" Text="Enviar" Width="221px" />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <asp:Label ID="RespuestaDelServidor" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
            </div>
        </div>
    </form>
</body>
</html>

