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
                        <asp:TableCell ColumnSpan="2">
                            <br />  
                            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>Email:</td>
                                            <td>
                                              
                                                        <asp:TextBox ID="email" runat="server" AutoPostBack="True" style="margin-bottom: 0px" textMode="Email"></asp:TextBox>
                                                        <asp:Label ID="result" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Nombre:</td>
                                            <td><asp:TextBox ID="nombre" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Apellidos:</td>
                                            <td><asp:TextBox ID="apellidos" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Password:</td>
                                            <td><asp:TextBox ID="password" runat="server" textMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Re-Password:</td>
                                            <td><asp:TextBox ID="repassword" runat="server" textMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Perfil:</td>
                                            <td><asp:RadioButtonList ID="perfil" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="Profesor">Profesor</asp:ListItem>
                                                <asp:ListItem Value="Alumno">Alumno</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                    
                                    <br />
                                    <br />
                                    <asp:Button ID="BtnRegister" runat="server" Height="44px" style="text-align: center" Text="Registrarse" Width="221px" />
                                    <br />
                                    <br />
                                    <asp:Label ID="RespuestaDelServidor" runat="server" Text=""></asp:Label>
                                    <br />
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="password" ErrorMessage="Contraseña inválida." ValidationExpression="[a-zA-Z0-9]{6,}"></asp:RegularExpressionValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="repassword" ControlToValidate="password" ErrorMessage="Las contraseñas no coinciden."></asp:CompareValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombre" ErrorMessage="Nombre es obligatorio."></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="apellidos" ErrorMessage="Apellido es obligatorio."></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password" ErrorMessage="Contraseña requerida."></asp:RequiredFieldValidator>
                                    <br />
                            
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>  
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
                <br />
            </div>
        </div>
    
                            
        <br />
    </form>
    </body>
</html>
