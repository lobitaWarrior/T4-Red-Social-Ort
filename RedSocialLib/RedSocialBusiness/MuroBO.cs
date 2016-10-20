using System;
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


        public MuroEntity TraerInformacionUsuario(int idUser)
        {
            MuroEntity muro = new MuroEntity();
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
