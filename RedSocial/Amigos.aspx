<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Amigos.aspx.cs" Inherits="Amigos" %>


<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionRedSocial %>" SelectCommand="SELECT US.UsuarioApellido,US.UsuarioNombre,US.UsuarioFoto
FROM Usuario US
"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%"
         OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="UsuarioFoto" SortExpression="UsuarioFoto"></asp:BoundField>
            <asp:BoundField DataField="UsuarioApellido" SortExpression="UsuarioApellido"></asp:BoundField>
            <asp:BoundField DataField="UsuarioNombre" SortExpression="UsuarioNombre" />
            <asp:ButtonField Text="Agregar Amigo" CommandName="btn-Agregar-Amigo" />
        </Columns>
    </asp:GridView>



</asp:Content>
