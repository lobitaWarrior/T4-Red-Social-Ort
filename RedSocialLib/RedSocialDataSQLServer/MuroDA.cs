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
    public class MuroDA
    {

        public MuroDA()
        {
        }

        Helpers helpers = new Helpers();

        #region Metodos Privados

        private MuroEntity GetDataMuro(SqlDataReader cursor)
        {
            MuroEntity muro = new MuroEntity();
            muro.fechaPublicacion = cursor.GetDateTime(cursor.GetOrdinal("Fecha"));
            muro.Remitente = cursor.GetString(cursor.GetOrdinal("Remitente"));
            muro.Mensaje = cursor.GetString(cursor.GetOrdinal("Mensaje"));
            muro.RemitenteFoto = helpers.SafeGetString(cursor, cursor.GetOrdinal("RemitenteFoto"));

            return muro;
        }

        #endregion

        #region Metodos Publicos

        public void InsertarComentario(MuroEntity muro)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearMensajeMuro", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@IDUsuario"].Value = muro.DestinatarioId;
                        comando.Parameters["@IDUsuarioRemitente"].Value = muro.RemitenteId;
                        comando.Parameters["@Message"].Value = muro.Mensaje;

                        comando.ExecuteNonQuery();

                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el comentario en el muro", ex);
            }
        }

        public List<MuroEntity> TraerDataMuro(int idUser)
        {
            List<MuroEntity> muro = new List<MuroEntity>();

            using (SqlConnection conexion = ConexionDA.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("MuroInfoBuscarPorUserId", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);

                    comando.Parameters["@IDUsuario"].Value = idUser;

                    using (SqlDataReader cursor = comando.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            muro.Add(GetDataMuro(cursor));
                        }

                        cursor.Close();
                    }
                }

                conexion.Close();
            }

            return muro;
        }

        #endregion

    }
}
