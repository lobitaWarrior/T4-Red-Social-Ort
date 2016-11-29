using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedSocialBusiness;
using RedSocialEntity;
using RedSocialComun;
using RedSocialWebUtil;
using System.Data;

public partial class Amigos : System.Web.UI.Page
{
    private UsuarioBO boAmigos = new UsuarioBO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int UsuarioIdNavegado = Convert.ToInt32(Request.QueryString["UserID"]);
            LlenarGridAmigos(UsuarioIdNavegado == 0 ? SessionHelper.UsuarioAutenticado.Id : UsuarioIdNavegado);
        }
    }

    public void LlenarGridAmigos(int UserID)
    {
        UsuarioEntity user = new UsuarioEntity();

        try
        {
            List<AmigosEntity> dsusuario = new List<AmigosEntity>();
            dsusuario = boAmigos.ListarAmigos(UserID);
            GridView1.DataSource = dsusuario;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ///*
            // * ES AMIGO=OCULTO LOS TRES BOTONES
            // * NO ES AMIGO -> NO TIENE SOLICITUD ->MOSTRAR BOTON SOLICITUD
            // * NO ES AMIGO -> TIENE SOLICITUD -> MOSTRAR BOTON ACEPTAR/CANCELAR
            // */

            LinkButton btnEnviar = (LinkButton)e.Row.FindControl("btnEnviarSolicitud");
            LinkButton btnCancelar = (LinkButton)e.Row.FindControl("btnCancelar");
            LinkButton btnAceptar = (LinkButton)e.Row.FindControl("btnAceptar");

            if (((AmigosEntity)e.Row.DataItem).EsAmigo == 1)
            {
                btnEnviar.Visible = false;
                btnAceptar.Visible = false;
                btnCancelar.Visible = false;
            }
            else
            {
                if (((AmigosEntity)e.Row.DataItem).EstadoSolicitud == 1)
                {
                    btnCancelar.Visible = true;
                    btnAceptar.Visible = true;
                    btnEnviar.Visible = false;
                }
                else
                {
                    btnCancelar.Visible = false;
                    btnAceptar.Visible = false;
                    btnEnviar.Visible = true;
                }
            }
        }
    }

    //TODO SE LLAMO 2 VECES EL BOTON AL RENICIAR WEB (fijarse de refreshear web asi se ve la actualizacion de estado (datasource.bind algo asi))
    //TODO FALTA HACER EL CREAR SOLICITUD (SP NO ES EL MISMO QUE MODIFICAR ESTADO)
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //ACTUALIZAR TABLA SOLICITUD PONERLE 0 ESTADO
        //ACTUALIZAR TABLA AMIGOS
        LinkButton btn = (LinkButton)(sender);
        int usuarioIdAmigo = Convert.ToInt32(btn.CommandArgument);
        AmigosBO amigo = new AmigosBO();
        amigo.ModificarSolicituEstado(0, SessionHelper.UsuarioAutenticado.Id,usuarioIdAmigo);
        amigo.AgregarAmigo(SessionHelper.UsuarioAutenticado.Id,usuarioIdAmigo);


    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //ACTUALIZAR TABLA SOLICITUD PONERLE 0 ESTADO 
        LinkButton btn = (LinkButton)(sender);
        int usuarioIdAmigo = Convert.ToInt32(btn.CommandArgument);
        AmigosBO amigo = new AmigosBO();
        amigo.ModificarSolicituEstado(0, SessionHelper.UsuarioAutenticado.Id, usuarioIdAmigo);
    }

    protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
    {
        //CREAR SOLICITUD LLAMAR AL SP PARA QUE LO HAGA
        LinkButton btn = (LinkButton)(sender);
        int usuarioIdAmigo = Convert.ToInt32(btn.CommandArgument);
        AmigosBO amigo = new AmigosBO();
        //amigo.ModificarSolicituEstado(1, SessionHelper.UsuarioAutenticado.Id, usuarioIdAmigo);

    }
}