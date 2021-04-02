﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registroLogin.aspx.vb" Inherits="GUI.RegistroLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin | Registro de actividades por usuario</title>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" ></script>
    <script>
        setInterval(function () {

            /* PROFESORES - creamos la variable con la solicitud */
            xhr = new XMLHttpRequest();

            /* indico qué traer y le paso el parámetro de email para saber las preguntas del usuario */
            xhr.open("GET", "../Private/AJAX/usuariosActivos.aspx", true);

            /* le digo qué hacer cuando llegue la respuesta */
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    $("#tablaUsuariosActivos").html(xhr.responseText);
                }
            }
            xhr.send('');
        }, 2000);
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <br />
                            <h1>Registro de actividades por usuario </h1>
                            <h2>Usuario: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Seleccionar usuario:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email" AutoPostBack="True"></asp:DropDownList>
        			        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT ' ' As email UNION SELECT DISTINCT [email] FROM [Registro]">
        			        </asp:SqlDataSource>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            	 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                			<Columns>
             		   		    <asp:BoundField DataField="id" HeaderText="Id" />
                                <asp:BoundField DataField="email" HeaderText="Email" />
                                <asp:BoundField DataField="accion" HeaderText="Acción" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="rol" HeaderText="Rol" />
             		   		</Columns>
            			</asp:GridView>
                        </asp:TableCell>
                    </asp:TableRow>
                                
                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br /><br /><asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="../Private/logout.aspx">Logout</asp:LinkButton><br /><br /><br /><br /><br />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell ID="tablaUsuariosActivos">
                            
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>     
    </form>
</body>
</html>

