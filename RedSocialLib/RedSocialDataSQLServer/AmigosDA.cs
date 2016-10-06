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
        public void AgregarAmigo()
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioInsert", conexion))
                    {
                        //comando.CommandType = CommandType.StoredProcedure;
                        //SqlCommandBuilder.DeriveParameters(comando);

                        //comando.Parameters["@UsuarioNombre"].Value = usuario.Nombre.Trim();
                        //comando.Parameters["@UsuarioApellido"].Value = usuario.Apellido.Trim();
                        //comando.Parameters["@UsuarioEmail"].Value = usuario.Email.Trim();
                        //comando.Parameters["@UsuarioPassword"].Value = usuario.Password.Trim();
                        //comando.Parameters["@UsuarioFechaNacimiento"].Value = usuario.FechaNacimiento;
                        //comando.Parameters["@UsuarioSexo"].Value = usuario.Sexo;
                        //comando.Parameters["@UsuarioFechaRegistracion"].Value = usuario.FechaRegistracion;
                        //comando.ExecuteNonQuery();
                        //usuario.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }
    }
}
