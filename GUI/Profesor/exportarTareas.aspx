    <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="exportarTareas.aspx.vb" Inherits="GUI.exportarTareas" Async="true"%>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2">
                                <br />
                                <br />
                                <h1>Exportar tareas XML </h1>
                                <h2>Profesor: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                Asignatura:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="true" DataTextField="CodAsig" DataValueField="CodAsig"/>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </asp:TableCell>
                        </asp:TableRow>

                            <asp:TableRow>
                            <asp:TableCell ColumnSpan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                   
                                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="hEstimadas" HeaderText="Horas Estimadas" />

                                        <asp:BoundField DataField="explotacion" HeaderText="Explotación" />
                                        <asp:BoundField DataField="tipoTarea" HeaderText="Tipo Tarea" />
                    
                                        <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                            </asp:TableCell>
                        </asp:TableRow>
                    
                        <asp:TableRow>
                            <asp:TableCell>
                                <br /><br />
                                <asp:Button ID="ExportarXML" runat="server" Text="Exportar XML" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <br /><br />
                                <asp:Button ID="ExportarJSON" runat="server" Text="Exportar JSON" />
                            </asp:TableCell>
                        </asp:TableRow>
                    
                        <asp:TableRow>
                            <asp:TableCell>
                                <br />
                                <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
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
