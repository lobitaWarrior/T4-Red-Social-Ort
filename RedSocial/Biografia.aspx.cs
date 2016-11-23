using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using RedSocialBusiness;
using RedSocialEntity;
using RedSocialWebUtil;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Biografia : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    private MuroBO boMuro = new MuroBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //cuando entra mi pagina personal y la de otro -> si en la url hay un prametro se lo mando sino session
            int UsuarioIdNavegado = Convert.ToInt32(Request.QueryString["UserID"]);

            LlenarListViewInfoUsuario(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
            LlenarListViewInfoAmigos(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
            LlenarMuroUsuario(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
        }

    }


    protected void InsertarMensajeMuro(string mensaje)
    {
        MuroEntity muro = new MuroEntity();

        muro.RemitenteId = SessionHelper.UsuarioAutenticado.Id;//quien lo hace (el usuario logeado)
        muro.DestinatarioId = SessionHelper.UsuarioAutenticado.Id; // a quien se lo hace (sacar id pagina)
        muro.Mensaje = mensaje;

        boMuro.InsertarComentario(muro);
    }

    #region /////   LLENAR DATOS    /////

    public void CargarFotoUsuario(string nombreFoto) {

        string ruta = Server.MapPath(ConfigurationManager.AppSettings["RutaFotos"]);
        if (nombreFoto!=null)
        {
            imagenUsuario.ImageUrl = ruta + nombreFoto;
        }
        else
        {
            imagenUsuario.ImageUrl = ruta + "imagenUsuario.svg";
        }
    }

    public void LlenarListViewInfoUsuario(int idUser)
    {
        UsuarioEntity user = new UsuarioEntity();

        try
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario = boUsuario.TraerInformacionUsuario(idUser);
            List<UsuarioEntity> dsUsuario = new List<UsuarioEntity>();
            dsUsuario.Add(usuario);
            detailsViewInfoUsuario.DataSource = dsUsuario;
            detailsViewInfoUsuario.DataBind();

            CargarFotoUsuario(usuario.Foto);//ademas cargo la foto del user
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    public void LlenarListViewInfoAmigos(int idUser)
    {
        UsuarioEntity user = new UsuarioEntity();
        string ruta = Server.MapPath(ConfigurationManager.AppSettings["RutaFotos"]);
        try
        {

            List<AmigosEntity> dsUsuarioAmigos = new List<AmigosEntity>();
            dsUsuarioAmigos = boUsuario.TraerInformacionAmigosUsuario(idUser);
            //como solo traigo el nombre de la foto en la base de datos, aca le asigno la ruta para poder buscarla en la carpeta
            dsUsuarioAmigos.ForEach(f=>f.UsuarioFoto=ruta+f.UsuarioFoto);
            detailsViewInfoAmigos.DataSource = dsUsuarioAmigos;
            detailsViewInfoAmigos.DataBind();
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    public void LlenarMuroUsuario(int idUser)
    {
        string ruta = Server.MapPath(ConfigurationManager.AppSettings["RutaFotos"]);
        List<MuroEntity> dsMuro = new List<MuroEntity>();
        dsMuro = boMuro.TraerMuroUsuario(idUser);
        //como solo traigo el nombre de la foto en la base de datos, aca le asigno la ruta para poder buscarla en la carpeta
        dsMuro.ForEach(f => f.RemitenteFoto = ruta + f.RemitenteFoto);
        RptMuro.DataSource = dsMuro;
        RptMuro.DataBind();

    }

    #endregion

    public void devolverDatosUsuario(ref UsuarioEntity usuario)
    {

        //TODO:TENER CUENTA VALIDACIONES
        usuario.Nombre = ((TextBox)detailsViewInfoUsuario.Rows[0].Cells[1].Controls[0]).Text;
        usuario.Apellido = ((TextBox)detailsViewInfoUsuario.Rows[1].Cells[1].Controls[0]).Text;
        usuario.Email = ((TextBox)detailsViewInfoUsuario.Rows[2].Cells[1].Controls[0]).Text;
        usuario.Sexo = Convert.ToChar(((DropDownList)detailsViewInfoUsuario.Rows[3].Cells[1].Controls[1]).Text);
        usuario.FechaNacimiento = Convert.ToDateTime(((TextBox)detailsViewInfoUsuario.Rows[4].Cells[1].Controls[0]).Text);
        usuario.Estudia = ((TextBox)detailsViewInfoUsuario.Rows[5].Cells[1].Controls[0]).Text;
        usuario.Trabajo = ((TextBox)detailsViewInfoUsuario.Rows[6].Cells[1].Controls[0]).Text;
        usuario.Vive = ((TextBox)detailsViewInfoUsuario.Rows[7].Cells[1].Controls[0]).Text;
        usuario.EstadoCivil = ((TextBox)detailsViewInfoUsuario.Rows[8].Cells[1].Controls[0]).Text;
        usuario.Id = SessionHelper.UsuarioAutenticado.Id;

    }

    protected void btnEditarInformacion_Click(object sender, EventArgs e)
    {
        detailsViewInfoUsuario.ChangeMode(DetailsViewMode.Edit);
        LlenarListViewInfoUsuario(SessionHelper.UsuarioAutenticado.Id);
        LinkButton btnGuardar = (LinkButton)detailsViewInfoUsuario.FindControl("btnGuardarInformacion");
        LinkButton btnCancelar = (LinkButton)detailsViewInfoUsuario.FindControl("btnCancelarGuardado");
        LinkButton btnEditar = (LinkButton)detailsViewInfoUsuario.FindControl("btnEditarInformacion");
        btnGuardar.Visible = true;
        btnCancelar.Visible = true;
        btnEditar.Visible = false;

    }

    protected void btnGuardarInformacion_Click(object sender, EventArgs e)
    {
        UsuarioEntity usuario = new UsuarioEntity();
        devolverDatosUsuario(ref usuario);
        boUsuario.ActualizarInformacionUsuario(usuario);
        detailsViewInfoUsuario.ChangeMode(DetailsViewMode.ReadOnly);
        detailsViewInfoUsuario.DefaultMode = DetailsViewMode.ReadOnly;
        LlenarListViewInfoUsuario(SessionHelper.UsuarioAutenticado.Id);
    }

    protected void btnCancelarGuardado_Click(object sender, EventArgs e)
    {
        detailsViewInfoUsuario.ChangeMode(DetailsViewMode.ReadOnly);
        detailsViewInfoUsuario.DefaultMode = DetailsViewMode.ReadOnly;
        LlenarListViewInfoUsuario(SessionHelper.UsuarioAutenticado.Id);
    }

    protected void btnAceptarTextoBiografia_Click(object sender, EventArgs e)
    {
        string mensaje = Request.Form["MensajeMuro"];
        InsertarMensajeMuro(mensaje);
        LlenarMuroUsuario(SessionHelper.UsuarioAutenticado.Id);//session o url
    }


    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
        {
            //TODO:validar que la key no este vacia!
            string ruta = Server.MapPath(ConfigurationManager.AppSettings["RutaFotos"]);
            boUsuario.ActualizarFoto(SessionHelper.UsuarioAutenticado.Id,ruta, FileUpload.PostedFile.FileName, FileUpload.FileBytes);
        }
    }

    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        //((DetailsView)sender).DataItemContainer.DataItem.Sexo
        //((DetailsView)sender).DataItemContainer;
        ((DropDownList)sender).Text = "F";
    }
}