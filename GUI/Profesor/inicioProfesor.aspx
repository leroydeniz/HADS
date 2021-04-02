<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicioProfesor.aspx.vb" Inherits="GUI.inicioProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profesor | Inicio</title>

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
                            <h1>Gestión Web de Tareas-Dedicación </h1>
                            <h2>Profesor: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            1. <asp:LinkButton ID="LinkRegistro" runat="server" PostBackUrl="crearTareas.aspx">Tareas</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            2. <asp:LinkButton ID="LinkImportar" runat="server" PostBackUrl="XML/importarTareas.aspx">Importar tareas</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            3. <asp:LinkButton ID="LinkImportarDataSet" runat="server" PostBackUrl="XML/importarTareasDS.aspx">Importar tareas con Data Set</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            4. <asp:LinkButton ID="LinkExportar" runat="server" PostBackUrl="XML/exportarTareas.aspx">Exportar tareas</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            5. <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="../Private/cambiarPassword.aspx">Cambiar contraseña</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            6. <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="../Private/logout.aspx">Logout</asp:LinkButton><br /><br /><br /><br /><br />
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