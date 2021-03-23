<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumnosOcultandoColumnas.aspx.vb" Inherits="GUI.TareasAlumnosOcultandoColumnas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alumnos | Tareas por asignatura</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <br />
                            <h1>Tareas por asignatura </h1>
                            <h2>Alumno: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
                            Seleccionar Asignatura:
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig" AutoPostBack="True"></asp:DropDownList>
        			        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [tareasAlumnos] WHERE ([Email] = @Email)">
            				        <SelectParameters>
                				        <asp:SessionParameter Name="Email" SessionField="usuario" Type="String" />
            				        </SelectParameters>
        			        </asp:SqlDataSource>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            	 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                			<Columns>
                		   		<asp:ButtonField ButtonType="Button" CommandName="Select" Text="Instanciar" />
             		   		    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" />
                                <asp:BoundField DataField="TipoTarea" HeaderText="Tipo Tarea" />
                                <asp:BoundField DataField="HEstimadas" HeaderText="Horas Estimadas" />
             		   		</Columns>
                			<Columns>
                		   		
             		   		</Columns>
            			</asp:GridView>
                        </asp:TableCell>
                    </asp:TableRow>
                                
                    <asp:TableRow>
                        <asp:TableCell>
                            <br /><br /><br /><asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="LinkLogout" runat="server">Logout</asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>     
    </form>
</body>
</html>
