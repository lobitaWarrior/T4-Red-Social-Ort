﻿using System;
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

public partial class Biografia : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //cuando entra mi pagina personal y la de otro -> si en la url hay un prametro se lo mando sino session
            LlenarListViewInfoUsuario(SessionHelper.UsuarioAutenticado.Id);
            LlenarListViewInfoAmigos(SessionHelper.UsuarioAutenticado.Id);
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
            //TO-DO: AMIGOS ENTITY, LLAMAR AL SP EN CAPA DATOS

            //UsuarioEntity usuario = new UsuarioEntity();
            //usuario = boUsuario.TraerInformacionUsuario(idUser);
            //List<> dsUsuario = new List<UsuarioEntity>();
            //dsUsuario.Add(usuario);
            //detailsViewInfoAmigos.DataSource = dsUsuario;
            //detailsViewInfoAmigos.DataBind();
        }
        catch (Exception ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

}