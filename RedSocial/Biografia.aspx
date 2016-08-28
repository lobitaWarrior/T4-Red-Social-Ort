<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Biografia.aspx.cs" Inherits="Biografia" %>

<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" Runat="Server" >
    <div class="row">
        <div class="col-md-3">
            <asp:Image runat="server" CssClass="img-responsive img-rounded"/>
        </div>
        <div class="col-md-7">
            <textarea class="form-control" placeholder="Escribe en la biograf&iacute;a"></textarea>
        </div>
        <div class="col-md-2">
            <%-- cual es la diferencia entre un asp button y un button html? --%>
            <%--<button type="button" id="btnAceptarTextoBiografia" class="btn-primary"></button>--%>
            <asp:Button ID="btnAceptarTextoBiografia" runat="server" CssClass="btn-primary"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <asp:ListView runat="server" ID="LstInfo" DataSourceID="sqlDataSourceInformacion">
                <LayoutTemplate>
                    <table runat="server" id="tableInformacion">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <%-- Data-bound content. --%>
                            <asp:Label runat="server" Text='<%#Eval("Nombre") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Apellido") %>' />
                            <asp:Label runat="server" Text='<%#Eval("FechaNacimiento") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Mail") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Pais") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Provincia") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Genero") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Trabajo") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-7">
            <asp:ListView runat="server" ID="lstMuro" DataSourceID="sqlDataSourceMuro">
                <LayoutTemplate>
                    <table runat="server" id="tableMuro">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <%-- Data-bound content. --%>
                            <asp:Label runat="server" Text='<%#Eval("Usuario") %>' />
                            <asp:Label runat="server" Text='<%#Eval("Texto") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-2">
            <asp:ListView runat="server" ID="LstAmigos" DataSourceID="sqlDataSourceMuro">
                <LayoutTemplate>
                    <table runat="server" id="tableAmigos">
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <%-- Data-bound content. --%>
                            <asp:Label runat="server" Text='<%#Eval("Nombre") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

