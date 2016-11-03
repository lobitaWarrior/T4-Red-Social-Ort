﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSocialEntity;
using RedSocialData;
using RedSocialDataSQLServer;

namespace RedSocialBusiness
{
    public class MuroBO
    {
        private MuroDA daMuro;

        public MuroBO()
        {
            daMuro = new MuroDA();
        }

        public void InsertarComentario(MuroEntity muro)
        {
            try
            {
                daMuro.InsertarComentario(muro);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo publicar el comentario en el muro.", ex);
            }
        }


        public List<MuroEntity> TraerMuroUsuario(int idUser)
        {
            List<MuroEntity> muro = new List<MuroEntity>();
            try
            {
                muro = daMuro.TraerDataMuro(idUser);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo traer el muro del usuario.", ex);
            }
            return muro;
        }

    }
}
