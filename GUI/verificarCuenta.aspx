<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="verificarCuenta.aspx.vb" Inherits="GUI.verificarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Verificar Cuenta</title>
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
    <form id="formVerificarCuenta" runat="server">
        <div>

                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Verificar Cuenta</strong></span><br />
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
                            Código:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="codigo" runat="server" textMode="password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br /> 
                            <asp:Button ID="BtnVerificarCuenta" runat="server" Height="44px" Text="Verificar" Width="221px" />
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
                </asp:Table>
        </div>

    </form>
</body>
</html>
