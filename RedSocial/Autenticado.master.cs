using System;
using System.Security.Permissions;


[PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
public partial class Autenticado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAmigosPage_Click(object sender, EventArgs e)
    {
        //Server.Transfer("Amigos.aspx");
        Response.Redirect("Amigos.aspx");

    }

    protected void btnBiografiaPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("Biografia.aspx");
    }


    protected void btnLogOff_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registracion.aspx");
        Session.Clear();
    }
}
