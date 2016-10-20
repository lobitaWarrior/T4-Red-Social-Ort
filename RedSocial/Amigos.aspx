<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Amigos.aspx.cs" Inherits="Amigos" %>


<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">


    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UsuarioFoto" ReadOnly="True" SortExpression="UsuarioFoto" />
            <asp:BoundField DataField="UsuarioNombreApellido" ReadOnly="True" SortExpression="UsuarioNombreApellido" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Agregar Amigo" ControlStyle-CssClass="btn btn-primary"/>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

</asp:Content>
