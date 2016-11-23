using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSocialEntity
{
    public class AmigosEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string UsuarioFoto { get; set; }
        public string Estudia { get; set; }
        public string Trabajo { get; set; }
        public string Vive { get; set; }
        public string EstadoCivil { get; set; }

    }
}
