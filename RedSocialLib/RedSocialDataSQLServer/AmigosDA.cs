using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using RedSocialEntity;
using RedSocialData;
namespace RedSocialDataSQLServer
{
    public class AmigosDA
    {
        public void AgregarAmigo(int usuarioid, int usuarioidamigo)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearAmigo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioID"].Value = usuarioid;
                        comando.Parameters["@UsuarioIDAmigo"].Value = usuarioidamigo;

                        comando.ExecuteNonQuery();
                      
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al agregar amigo.", ex);
            }

        }

            public void AceptarSolicitud(int estado)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("SolicitudModificarEstado", conexion))
                    {


                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("No se pudo realizar la solicitud", ex);
            }
        }
    }
}
