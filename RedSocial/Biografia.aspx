<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Biografia.aspx.cs" Inherits="Biografia" %>

<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="row">
        <div class="col-md-3">
            <asp:Image runat="server" CssClass="img-responsive img-rounded img-thumbnail" ImageUrl="~/Imagenes/imagenUsuario.svg" Height="140" Width="140" ID="imagenUsuario" />
            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Button ID="btnUploadImage" runat="server" Text="Upload" OnClick="btnUploadImage_Click" />
        </div>
        <div class="col-md-7">
            <div class="input-group">
                <input type="text" class="form-control" id="MensajeMuro" name="MensajeMuro" placeholder="Escribe en la biograf&iacute;a"/>
                <span class="input-group-btn">
                    <asp:LinkButton runat="server" CssClass="btn btn-default" ID="btnAceptarTextoBiografia" OnClick="btnAceptarTextoBiografia_Click">GO</asp:LinkButton>
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
                    <asp:TemplateField HeaderText="Sexo" SortExpression="Sexo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownListSexo" runat="server" Height="23px" OnDataBound="DropDownList1_DataBound">
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sexo") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estudia" HeaderText="Estudia" SortExpression="Estudia" />
                    <asp:BoundField DataField="Trabajo" HeaderText="Trabajo" SortExpression="Trabajo" />
                    <asp:BoundField DataField="Vive" HeaderText="Vive" SortExpression="Vive" />
                    <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" SortExpression="EstadoCivil" />
                </Fields>
                <HeaderTemplate>
                    <asp:LinkButton runat="server" ID="btnEditarInformacion"  CssClass="pull-right" OnClick="btnEditarInformacion_Click" ><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnGuardarInformacion"  CssClass="pull-right " OnClick="btnGuardarInformacion_Click" Visible="false"><i class="glyphicon glyphicon-ok"></i></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnCancelarGuardado" CssClass="pull-right  " OnClick="btnCancelarGuardado_Click" Visible="false"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                </HeaderTemplate>
            </asp:DetailsView>


            <asp:GridView ID="detailsViewInfoAmigos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:ImageField DataImageUrlField="UsuarioFoto" ReadOnly="true" 
                        ConvertEmptyStringToNull="true" NullImageUrl="~/Imagenes/imagenUsuario.svg" 
                        ControlStyle-Width="50" ControlStyle-Height="50"></asp:ImageField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True" SortExpression="Apellido" />
                </Columns>

            </asp:GridView>
        </div>

        <div class="col-md-7">

            <asp:Repeater ID="RptMuro" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Image runat="server" Width="25" Height="25" ImageUrl='<%# Eval("RemitenteFoto") %>' />
                        </div>
                        <div class="col-md-11">
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

