<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Biografia.aspx.cs" Inherits="Biografia" %>

<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="row">
        <div class="col-md-3">
            <asp:Image runat="server" CssClass="img-responsive img-rounded" />
        </div>
        <div class="col-md-7">
            <div class="input-group">
                <input type="text" class="form-control" placeholder="Escribe en la biograf&iacute;a"></input>
                <span class="input-group-btn">
                    <button class="btn btn-default" id="btnAceptarTextoBiografia" type="button">Go!</button>
                </span>
            </div>
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


            <asp:GridView ID="detailsViewInfoAmigos" runat="server" AutoGenerateColumns="False">
                <Columns>
<%--                    <asp:ImageField DataImageUrlField="UsuarioFoto">
                    </asp:ImageField>--%>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True" SortExpression="Apellido" />
                </Columns>

            </asp:GridView>
        </div>

        <div class="col-md-7">

            <asp:Repeater ID="RptMuro" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-3">
<%--                            <asp:Label runat="server" ID="lblFoto" Text='<%# Eval("RemitenteFoto") %>'></asp:Label>--%>

                        </div>
                        <div class="col-md-9">
                            <asp:Label runat="server" ID="lblUsuario" Text='<%# Eval("Remitente") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label runat="server" ID="lblMensaje" Text='<%# Eval("Mensaje") %>'></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>

</asp:Content>

