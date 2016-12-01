<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Amigos.aspx.cs" Inherits="Amigos" %>


<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">

    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="663px" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ImageField DataImageUrlField="UsuarioFoto" DataImageUrlFormatString="Imagenes/{0}" ControlStyle-Width="50"></asp:ImageField>
            <asp:BoundField DataField="UsuarioNombreApellido" HeaderText="UsuarioNombreApellido" SortExpression="UsuarioNombreApellido" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnEnviarSolicitud" CommandArgument='<%#Eval("UsuarioID") %>' CssClass="btn btn-default" Visible="false" OnClick="btnEnviarSolicitud_Click"><i class="glyphicon glyphicon-share-alt"></i></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnAceptar" CommandArgument='<%#Eval("UsuarioID") %>' CssClass="btn btn-default" Visible="false" OnClick="btnAceptar_Click"><i class="glyphicon glyphicon-ok"></i></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnCancelar" CommandArgument='<%#Eval("UsuarioID") %>'  CssClass="btn btn-default" Visible="false" OnClick="btnCancelar_Click"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                    <asp:Label runat="server" ID="labelSolicitudEnviada" Visible="false">Solicitud pendiente</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
