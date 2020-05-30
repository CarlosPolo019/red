using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace red.Modelos
{
    [Table("usuario")]
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Imagen { get; set; }
        public DateTime Fecha { get; set; }

    }
}
