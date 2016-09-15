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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RedSocialORT22AGrupo01ConnectionString %>" SelectCommand="SELECT [UsuarioNombre], [UsuarioApellido], [UsuarioEmail], [UsuarioFechaNacimiento], [UsuarioSexo] FROM [Usuario] WHERE ([UsuarioID] = @UsuarioID)">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="1" Name="UsuarioID" SessionField="UsuarioAutenticado" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="UsuarioNombre" HeaderText="Nombre" SortExpression="UsuarioNombre">
                    <HeaderStyle BorderStyle="None" Font-Names="Arial" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UsuarioApellido" HeaderText="UsuarioApellido" SortExpression="UsuarioApellido" />
                    <asp:BoundField DataField="UsuarioEmail" HeaderText="UsuarioEmail" SortExpression="UsuarioEmail" />
                    <asp:BoundField DataField="UsuarioFechaNacimiento" HeaderText="UsuarioFechaNacimiento" SortExpression="UsuarioFechaNacimiento" />
                    <asp:BoundField DataField="UsuarioSexo" HeaderText="UsuarioSexo" SortExpression="UsuarioSexo" />
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

