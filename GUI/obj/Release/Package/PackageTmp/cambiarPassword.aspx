<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cambiarPassword.aspx.vb" Inherits="GUI.cambiarPassword" %>

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
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Cambiar password</strong></span><br />
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
                            Antigua password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="oldPassword" runat="server" textMode="Password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Nueva password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="newPassword" runat="server" textMode="Password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Repetir nueva password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="newRePassword" runat="server" textMode="Password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <asp:Button ID="BtnCambiarPassword" runat="server" Height="44px" style="text-align: center" Text="Cambiar" Width="221px" />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="[a-zA-Z0-9]{6,}" ControlToValidate="newPassword" ErrorMessage="Nueva contraseña demasiado corta"></asp:RegularExpressionValidator><br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Contraseñas no coinciden" controltovalidate="newPassword" controltocompare="NewRePassword"></asp:CompareValidator><br />
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
                </asp:Table>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
