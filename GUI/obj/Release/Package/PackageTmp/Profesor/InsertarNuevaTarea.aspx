<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarNuevaTarea.aspx.vb" Inherits="GUI.InsertarNuevaTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profesor | Insertar nueva tarea</title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <br />
                            <h1>Insertar nueva tarea </h1>
                            <h2>Profesor: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Codigo:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="codigo" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Descripcion:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="descripcion" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Asignatura:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig"/>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Horas Estimadas:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="horasEstimadas" runat="server" type="number"/>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            Tipo Tarea: 
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Value="laboratorio" Text="Laboratorio"></asp:ListItem>
                                <asp:ListItem Value="trabajo" Text="Trabajo"></asp:ListItem>
                                <asp:ListItem Value="ejercicio" Text="Ejercicio"></asp:ListItem>
                                <asp:ListItem Value="examen" Text="Examen"></asp:ListItem>
                            </asp:DropDownList> 
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><asp:Button ID="BtnAñadirTarea" runat="server" Height="44px" Text="Añadir Tarea" Width="221px" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <br />
                            <asp:Label ID="Label0" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Código de tarea no puede estar vacío." ControlToValidate="codigo"></asp:RequiredFieldValidator>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Descripción de tarea no puede estar vacío." ControlToValidate="descripcion"></asp:RequiredFieldValidator>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Horas estimadas de tarea no puede estar vacío." ControlToValidate="horasEstimadas"></asp:RequiredFieldValidator>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br /><br /><asp:LinkButton ID="LinkVerTareas" runat="server" PostBackUrl="crearTareas.aspx">Volver a Tareas</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp; <asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp; <asp:LinkButton ID="LinkLogout" runat="server">Logout</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>     

    </form>

</body>
</html>