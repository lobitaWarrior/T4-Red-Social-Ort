using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSocialEntity
{
    public class AmigosEntity:UsuarioEntity
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombreApellido { get; set; }
        public int EstadoSolicitud { get; set; }
        public string UsuarioFoto { get; set; }
        public int EsAmigo { get; set; }

    }
}
