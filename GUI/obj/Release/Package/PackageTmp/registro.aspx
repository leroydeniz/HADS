<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registro.aspx.vb" Inherits="GUI.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
    <style type="text/css">

        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <div class="auto-style1">
                <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="2" HorizontalAlign="Center" BorderColor="#0F423F" BorderWidth="1px">
                    
                    <asp:TableRow BorderWidth="1">
                        <asp:TableCell>
                            <br />
                            <br />
                            <span class="auto-style2"><strong>Registro</strong></span><br />
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
                            Nombre:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="nombre" runat="server"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Apellidos:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="apellidos" runat="server"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="password" runat="server" textMode="Password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Re-Password:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="repassword" runat="server" textMode="Password"></asp:TextBox> 
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Perfil:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:RadioButtonList ID="perfil" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Profesor" Selected="True">Profesor</asp:ListItem>
                                <asp:ListItem Value="Alumno">Alumno</asp:ListItem>
                            </asp:RadioButtonList>     
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <asp:Button ID="BtnRegister" runat="server" Height="44px" style="text-align: center" Text="Registrarse" Width="221px" />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <br /> <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
