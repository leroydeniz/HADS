<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="GUI.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alumnos | Instancias nueva tarea</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <asp:Table runat="server" BorderWidth="1"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <br />
                            <h1>Gestión Web de Tareas-Dedicación </h1>
                            <h2>Alumno: <asp:Label ID="usuarioText" runat="server" Text=""></asp:Label></h2><br />
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell>
				            Usuario:
                        </asp:TableCell>
                        <asp:TableCell>
				            <asp:TextBox ID="TBusuario" runat="server" ReadOnly="true" BackColor="#efefef" Width="100px" value=""/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell>
				            Tarea:
                        </asp:TableCell><asp:TableCell>
				            <asp:TextBox ID="TBtarea" runat="server" ReadOnly="true" BackColor="#efefef" Width="100px" value=""/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell>
				            Horas Estimadas:
                        </asp:TableCell><asp:TableCell>
				            <asp:TextBox ID="TBhorasEstimadas" runat="server" ReadOnly="true" BackColor="#efefef" Width="100px" value=""/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell>
				            Horas Reales:
                        </asp:TableCell><asp:TableCell>
				            <asp:TextBox ID="TBHorasReales" runat="server" type="number" Width="100px" value=""/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell>
				            <asp:Button ID="BtnInstanciar" runat="server" Height="44px" Text="Instanciar" Width="221px" />
                        </asp:TableCell><asp:TableCell>
				            <asp:Label ID="RespuestaDelServidor" runat="server" Text=""/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:GridView ID="GridView2" runat="server"> </asp:GridView>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell>
                            <br/><br/><br/><asp:LinkButton ID="VerTareas" runat="server">Ver tareas</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="VolverAlMenu" runat="server">Volver al menú</asp:LinkButton> &nbsp;&nbsp;| &nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="../Private/logout.aspx">Logout</asp:LinkButton>
                        </asp:TableCell></asp:TableRow></asp:Table></div></form></body></html>





