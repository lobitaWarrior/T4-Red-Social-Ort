using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialEntity;
using RedSocialData;
using RedSocialDataSQLServer;

namespace RedSocialBusiness
{
    public class AmigosBO
    {
        private UsuarioDA daUsuario;
        private AmigosDA daAmigo;

        public AmigosBO()
        {
            daUsuario = new UsuarioDA();
            daAmigo = new AmigosDA();
        }

        public void AgregarAmigo(int usuarioid, int amigoid)
        {
            
            try
            {
                daAmigo.AgregarAmigo(usuarioid, amigoid);

                
            }
            catch (Exception ex)
            {

                throw new ExcepcionBO("Mo de pudo agregar el asmigo", ex);
            }

        }
        public void ModificarSolicituEstado(int estado, int usuarioId, int usuarioIdAmigo)
        {

            try
            {
                daAmigo.AceptarSolicitud(estado,usuarioId,usuarioIdAmigo);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo modificar la solicitud", ex);
            }
        }

        public void CrearSolicituEstado(int usuarioId, int usuarioIdAmigo)
        {

            try
            {
                daAmigo.AceptarSolicitud(estado, usuarioId, usuarioIdAmigo);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo modificar la solicitud", ex);
            }
        }

    }


}
