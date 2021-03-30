<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="crearTareas.aspx.vb" Inherits="GUI.crearTareas" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profesor | Gestión de tareas genéricas</title>
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
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CodAsig" DataValueField="CodAsig" AutoPostBack="True"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT DISTINCT [CodAsig] FROM [crearTareasProfesor] WHERE ([email] = @email)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="email" SessionField="usuario" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>    
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" style="margin-right: 1px">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" HeaderText="" ShowEditButton="True" ShowHeader="True" />
                                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                                </Columns>
                            </asp:GridView>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS-JorgeConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @original_Codigo AND (([Descripcion] = @original_Descripcion) OR ([Descripcion] IS NULL AND @original_Descripcion IS NULL)) AND (([CodAsig] = @original_CodAsig) OR ([CodAsig] IS NULL AND @original_CodAsig IS NULL)) AND (([HEstimadas] = @original_HEstimadas) OR ([HEstimadas] IS NULL AND @original_HEstimadas IS NULL)) AND (([Explotacion] = @original_Explotacion) OR ([Explotacion] IS NULL AND @original_Explotacion IS NULL)) AND (([TipoTarea] = @original_TipoTarea) OR ([TipoTarea] IS NULL AND @original_TipoTarea IS NULL))" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @original_Codigo AND (([Descripcion] = @original_Descripcion) OR ([Descripcion] IS NULL AND @original_Descripcion IS NULL)) AND (([CodAsig] = @original_CodAsig) OR ([CodAsig] IS NULL AND @original_CodAsig IS NULL)) AND (([HEstimadas] = @original_HEstimadas) OR ([HEstimadas] IS NULL AND @original_HEstimadas IS NULL)) AND (([Explotacion] = @original_Explotacion) OR ([Explotacion] IS NULL AND @original_Explotacion IS NULL)) AND (([TipoTarea] = @original_TipoTarea) OR ([TipoTarea] IS NULL AND @original_TipoTarea IS NULL))">
                                <DeleteParameters>
                                    <asp:Parameter Name="original_Codigo" Type="String" />
                                    <asp:Parameter Name="original_Descripcion" Type="String" />
                                    <asp:Parameter Name="original_CodAsig" Type="String" />
                                    <asp:Parameter Name="original_HEstimadas" Type="Int32" />
                                    <asp:Parameter Name="original_Explotacion" Type="Boolean" />
                                    <asp:Parameter Name="original_TipoTarea" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Codigo" Type="String" />
                                    <asp:Parameter Name="Descripcion" Type="String" />
                                    <asp:Parameter Name="CodAsig" Type="String" />
                                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                                    <asp:Parameter Name="TipoTarea" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="CodAsig" SessionField="asignaturaElegida" Type="String" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Descripcion" Type="String" />
                                    <asp:Parameter Name="CodAsig" Type="String" />
                                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                                    <asp:Parameter Name="TipoTarea" Type="String" />
                                    <asp:Parameter Name="original_Codigo" Type="String" />
                                    <asp:Parameter Name="original_Descripcion" Type="String" />
                                    <asp:Parameter Name="original_CodAsig" Type="String" />
                                    <asp:Parameter Name="original_HEstimadas" Type="Int32" />
                                    <asp:Parameter Name="original_Explotacion" Type="Boolean" />
                                    <asp:Parameter Name="original_TipoTarea" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="BtnInsertarTarea" runat="server" Height="44px" Text="Insertar Nueva Tarea" Width="221px" />
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









        
        
