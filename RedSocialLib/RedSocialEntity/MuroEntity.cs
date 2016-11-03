using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSocialEntity
{
    public class MuroEntity
    {
        public string Mensaje { get; set; }
        public int RemitenteId { get; set; }
        public string Remitente { get; set; }
        public string RemitenteFoto { get; set; }
        public int DestinatarioId { get; set; }
        public string Destinatario { get; set; }
        public DateTime fechaPublicacion { get; set; }

    }
}
