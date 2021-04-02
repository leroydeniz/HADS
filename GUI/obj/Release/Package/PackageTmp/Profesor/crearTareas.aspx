<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="crearTareas.aspx.vb" Inherits="GUI.crearTareas" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profesor | Gestión de tareas genéricas</title>

    <script>
        function tareasAJAX() {
            if (XMLHttpRequest) {
                xhr = new XMLHttpRequest();
                var asignatura = document.getElementById("DropDownList1").value;
                xhr.open('GET', '../Private/AJAX/tareasFiltradas.aspx?asig=' + asignatura, true);
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        document.getElementById('tareasAJAX').innerHTML = xhr.responseText;
                    }
                }
                xhr.send('');
            } //cierra if xmlhttprequest
        } //cierra la función
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <br />
                            <h1>Gestion de tareas genericas </h1>
                            <h2>Profesor: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Seleccionar Asignatura:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig" AutoPostBack="false" onChange="tareasAJAX();"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT ' ' As CodAsig UNION ALL SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>    
                        </asp:TableCell>
                    </asp:TableRow>
                                        
                    <asp:TableRow>
                        <asp:TableCell ID="tareasAJAX" ColumnSpan="2"></asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="BtnInsertarTarea" runat="server" Text="Insertar Nueva Tarea" Width="221px" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br /><br /><asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="../Private/logout.aspx">Logout</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>     

    </form>

</body>
</html>









        
        
