<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Biografia.aspx.cs" Inherits="Biografia" %>

<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="row">
        <div class="col-md-3">
            <asp:Image runat="server" CssClass="img-responsive img-rounded" />
        </div>
        <div class="col-md-7">
            <textarea class="form-control" placeholder="Escribe en la biograf&iacute;a"></textarea>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnAceptarTextoBiografia" runat="server" CssClass="btn-primary" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">

            <asp:DetailsView ID="detailsViewInfoUsuario" runat="server" AutoGenerateRows="False" Height="16px" Width="33px">
                <Fields>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" />
                    <asp:BoundField DataField="Estudia" HeaderText="Estudia" SortExpression="Estudia" />
                    <asp:BoundField DataField="Trabajo" HeaderText="Trabajo" SortExpression="Trabajo" />
                    <asp:BoundField DataField="Vive" HeaderText="Vive" SortExpression="Vive" />
                    <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" SortExpression="EstadoCivil" />
                </Fields>
            </asp:DetailsView>


            <asp:DetailsView ID="detailsViewInfoAmigos" runat="server" AutoGenerateRows="False" Height="16px" Width="33px">
                <Fields>
                    <asp:BoundField DataField="UsuarioNombre" HeaderText="Nombre" SortExpression="UsuarioNombre"></asp:BoundField>
                    <asp:BoundField DataField="UsuarioApellido" HeaderText="Apellido" SortExpression="UsuarioApellido" />
                    <asp:BoundField DataField="UsuarioFoto" HeaderText="Foto" SortExpression="UsuarioIDAmigo" />
                </Fields>
            </asp:DetailsView>
        </div>
        <%--        <div class="col-md-7">
            <asp:ListView runat="server" ID="lstMuro" DataSourceID="sqlDataSourceMuro">
                <LayoutTemplate>
                    <table runat="server" id="tableMuro">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <asp:Label runat="server" Text='<%#Eval("Usuario") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Texto") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>--%>
        <%--        <div class="col-md-2">
            <asp:ListView runat="server" ID="LstAmigos" DataSourceID="sqlDataSourceMuro">
                <LayoutTemplate>
                    <table runat="server" id="tableAmigos">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <asp:Label runat="server" Text='<%#Eval("Nombre") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>--%>
    </div>

</asp:Content>

