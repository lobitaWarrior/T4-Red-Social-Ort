using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using RedSocialEntity;
using RedSocialData;
using System.Collections.Generic;

namespace RedSocialDataSQLServer
{
    public class UsuarioDA
    {
        public UsuarioDA()
        {
        }

        Helpers helpers = new Helpers();

        #region Métodos Privados
        private UsuarioEntity CrearUsuario(SqlDataReader cursor)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Id = cursor.GetInt32(cursor.GetOrdinal("UsuarioID"));
            usuario.Nombre = cursor.GetString(cursor.GetOrdinal("UsuarioNombre"));
            usuario.Apellido = cursor.GetString(cursor.GetOrdinal("UsuarioApellido"));
            usuario.Email = cursor.GetString(cursor.GetOrdinal("UsuarioEmail"));
            usuario.Password = cursor.GetString(cursor.GetOrdinal("UsuarioPassword"));
            usuario.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaNacimiento"));
            usuario.Sexo = cursor.GetString(cursor.GetOrdinal("UsuarioSexo"))[0];

            if (!cursor.IsDBNull(cursor.GetOrdinal("UsuarioFoto")))
                usuario.Foto = cursor.GetString(cursor.GetOrdinal("UsuarioFoto"));

            usuario.FechaRegistracion = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaRegistracion"));

            if (!cursor.IsDBNull(cursor.GetOrdinal("UsuarioFechaActualizacion")))
                usuario.FechaActualizacion = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaActualizacion"));

            return usuario;
        }

        private UsuarioEntity GetInfoUsuario(SqlDataReader cursor)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Id = cursor.GetInt32(cursor.GetOrdinal("UsuarioID"));
            usuario.Nombre = cursor.GetString(cursor.GetOrdinal("UsuarioNombre"));
            usuario.Apellido = cursor.GetString(cursor.GetOrdinal("UsuarioApellido"));
            usuario.Email = cursor.GetString(cursor.GetOrdinal("UsuarioEmail"));
            usuario.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaNacimiento"));
            usuario.Sexo = cursor.GetString(cursor.GetOrdinal("UsuarioSexo"))[0];
            usuario.Estudia = helpers.SafeGetString(cursor,cursor.GetOrdinal("Estudia"));
            usuario.Trabajo= helpers.SafeGetString(cursor,cursor.GetOrdinal("Trabajo"));
            usuario.Vive= helpers.SafeGetString(cursor,cursor.GetOrdinal("Vive"));
            usuario.EstadoCivil= cursor.GetString(cursor.GetOrdinal("EstadoCivil"));

            return usuario;
        }

        private AmigosEntity GetInfoAmigo(SqlDataReader cursor)
        {
            AmigosEntity usuario = new AmigosEntity();
            usuario.Id = cursor.GetInt32(cursor.GetOrdinal("UsuarioIDAmigo"));
            usuario.Nombre = cursor.GetString(cursor.GetOrdinal("UsuarioNombre"));
            usuario.Apellido = cursor.GetString(cursor.GetOrdinal("UsuarioApellido"));
            usuario.Email = cursor.GetString(cursor.GetOrdinal("UsuarioEmail"));
            usuario.FechaNacimiento = cursor.GetDateTime(cursor.GetOrdinal("UsuarioFechaNacimiento"));
            usuario.Sexo = cursor.GetString(cursor.GetOrdinal("UsuarioSexo"))[0];
            usuario.Trabajo = helpers.SafeGetString(cursor,cursor.GetOrdinal("UsuarioTrabajo"));
            usuario.Vive = helpers.SafeGetString(cursor,cursor.GetOrdinal("UsuarioProvincia"));
            usuario.Foto = helpers.SafeGetString(cursor,cursor.GetOrdinal("UsuarioFoto"));
            return usuario;
        }

        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(UsuarioEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioInsert", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioNombre"].Value = usuario.Nombre.Trim();
                        comando.Parameters["@UsuarioApellido"].Value = usuario.Apellido.Trim();
                        comando.Parameters["@UsuarioEmail"].Value = usuario.Email.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = usuario.Password.Trim();
                        comando.Parameters["@UsuarioFechaNacimiento"].Value = usuario.FechaNacimiento;
                        comando.Parameters["@UsuarioSexo"].Value = usuario.Sexo;
                        comando.Parameters["@UsuarioFechaRegistracion"].Value = usuario.FechaRegistracion;
                        comando.ExecuteNonQuery();
                        usuario.Id = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);
                    }
                    
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void Actualizar(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                FileInfo infoArchivo = new FileInfo(nombreArchivo);
                
                string rutaFotos = ConfigurationManager.AppSettings["RutaFotos"];
                string nuevoNombreArchivo = id.ToString() + infoArchivo.Extension;

                using (FileStream archivo = File.Create(rutaFotos + nuevoNombreArchivo))
                {
                    archivo.Write(archivoFoto, 0, archivoFoto.Length);
                    archivo.Close();
                }
                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioActualizarFoto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioID"].Value = id;
                        comando.Parameters["@UsuarioFoto"].Value = nuevoNombreArchivo;
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar la foto.", ex);
            }
        }

        public bool ExisteEmail(string email)
        {
            try
            {
                bool existeEmail;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarEmail", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        existeEmail = Convert.ToBoolean(comando.ExecuteScalar());
                    }

                    conexion.Close();
                }

                return existeEmail;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email.", ex);
            }
        }

        public UsuarioEntity BuscarUsuario(string email, string password)
        {
            try
            {
                UsuarioEntity usuario = null;
                
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = password.Trim();
                        
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        public UsuarioEntity TraerInformacionUsuario(int idUser)
        {
            UsuarioEntity usuario = null;

            using (SqlConnection conexion = ConexionDA.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("UsuarioInfoBuscarPorId", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);

                    comando.Parameters["@IDUsuario"].Value = idUser;

                    using (SqlDataReader cursor = comando.ExecuteReader())
                    {
                        if (cursor.Read())
                        {
                            usuario = GetInfoUsuario(cursor);
                        }

                        cursor.Close();
                    }
                }

                conexion.Close();
            }

            return usuario;
        }

        public List<AmigosEntity> TraerInformacionAmigosUsuario(int idUser)
        {
            List<AmigosEntity> amigos = new List<AmigosEntity>();

            using (SqlConnection conexion = ConexionDA.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("AmigosBuscarPorUserId", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);

                    comando.Parameters["@IDUsuario"].Value = idUser;

                    using (SqlDataReader cursor = comando.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            amigos.Add(GetInfoAmigo(cursor));
                        }

                        cursor.Close();
                    }
                }

                conexion.Close();
            }

            return amigos;
        }

        #endregion Métodos Públicos
    }
}
