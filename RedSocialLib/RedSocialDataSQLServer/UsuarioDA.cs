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
            usuario.Estudia = helpers.SafeGetString(cursor, cursor.GetOrdinal("Estudia"));
            usuario.Trabajo = helpers.SafeGetString(cursor, cursor.GetOrdinal("Trabajo"));
            usuario.Vive = helpers.SafeGetString(cursor, cursor.GetOrdinal("Vive"));
            usuario.EstadoCivil = helpers.SafeGetString(cursor, cursor.GetOrdinal("EstadoCivil"));
            usuario.Foto = helpers.SafeGetString(cursor, cursor.GetOrdinal("UsuarioFoto"));

            return usuario;
        }

        public AmigosEntity GetUsuariosAmigos(SqlDataReader cursor)
        {
            AmigosEntity amigos = new AmigosEntity();
            amigos.UsuarioNombreApellido = cursor.GetString(cursor.GetOrdinal("UsuarioNombreApellido"));
            amigos.UsuarioFoto = helpers.SafeGetString(cursor, cursor.GetOrdinal("UsuarioFoto"));
            amigos.EstadoSolicitud = cursor.GetInt32(cursor.GetOrdinal("EstadoSolicitud"));
            amigos.EsAmigo = cursor.GetInt32(cursor.GetOrdinal("EsAmigo"));
            amigos.UsuarioId = cursor.GetInt32(cursor.GetOrdinal("UsuarioID"));

            return amigos;
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
            usuario.UsuarioFoto = helpers.SafeGetString(cursor,cursor.GetOrdinal("UsuarioFoto"));
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

        public void Actualizar(int id, string ruta,string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                FileInfo infoArchivo = new FileInfo(nombreArchivo);
                
                string rutaFotos = ConfigurationManager.AppSettings["RutaFotos"];
                string nuevoNombreArchivo = id.ToString() + infoArchivo.Extension;


                using (FileStream archivo = File.Create(ruta + nuevoNombreArchivo))
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

        public List<AmigosEntity> ListarUsuarios(int idUser)
        {
            List<AmigosEntity> usuarios = new List<AmigosEntity>();

            using (SqlConnection conexion = ConexionDA.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("TraerUsuariosYSiEsMiAmigo", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);

                    comando.Parameters["@IDUsuario"].Value = idUser;

                    using (SqlDataReader cursor = comando.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            usuarios.Add(GetUsuariosAmigos(cursor));
                        }

                        cursor.Close();
                    }
                }

                conexion.Close();
            }

            return usuarios;
        }

        public void ActualizarInformacionUsuario(UsuarioEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ModificarInfoUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@IDUsuario"].Value = usuario.Id;
                        comando.Parameters["@Apellido"].Value = usuario.Apellido.Trim();
                        comando.Parameters["@Email"].Value = usuario.Email.Trim();
                        comando.Parameters["@FechaNacimiento"].Value = usuario.FechaNacimiento;
                        comando.Parameters["@Nombre"].Value = usuario.Nombre.Trim();
                        comando.Parameters["@Sexo"].Value = usuario.Sexo;
                        comando.Parameters["@Trabaja"].Value = usuario.Trabajo.Trim();
                        comando.Parameters["@Estudia"].Value = usuario.Estudia.Trim();
                        comando.Parameters["@Vive"].Value = usuario.Vive.Trim();
                        comando.Parameters["@EstadoCivil"].Value = usuario.EstadoCivil.Trim();
                        comando.Parameters["@IDUsuarioEstadoCivil"].Value = 1;//TODO: CAMBIAR ACA
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }

        }


        #endregion Métodos Públicos
    }
}
