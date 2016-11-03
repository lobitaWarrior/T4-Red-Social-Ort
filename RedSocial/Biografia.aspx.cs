using System;
using System.Collections.Generic;
using System.Web.UI;
using RedSocialBusiness;
using RedSocialEntity;
using RedSocialWebUtil;

public partial class Biografia : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    private MuroBO boMuro = new MuroBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            //cuando entra mi pagina personal y la de otro -> si en la url hay un prametro se lo mando sino session
            int UsuarioIdNavegado=Convert.ToInt32(Request.QueryString["UserID"]);

            LlenarListViewInfoUsuario(UsuarioIdNavegado==0?SessionHelper.UsuarioAutenticado.Id:UsuarioIdNavegado);
            LlenarListViewInfoAmigos(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
            LlenarMuroUsuario(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
        }
        else
        {
            string mensaje = Request.Form["MensajeMuro"];
            InsertarMensajeMuro(mensaje);
            LlenarMuroUsuario(SessionHelper.UsuarioAutenticado.Id);//session o url
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
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    public void LlenarListViewInfoAmigos(int idUser)
    {
        UsuarioEntity user = new UsuarioEntity();

        try
        {

            List<AmigosEntity> dsUsuarioAmigos = new List<AmigosEntity>();
            dsUsuarioAmigos = boUsuario.TraerInformacionAmigosUsuario(idUser);
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
        List<MuroEntity> dsMuro = new List<MuroEntity>();
        dsMuro = boMuro.TraerMuroUsuario(idUser);
        RptMuro.DataSource = dsMuro;
        RptMuro.DataBind();

    }
    #endregion

}