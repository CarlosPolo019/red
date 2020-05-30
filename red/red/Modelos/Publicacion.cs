using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace red.Modelos
{
    [Table("publicacion")]
    public class Publicacion
    {
        public int PublicacionID { get; set; }
        public int Id_usuario { get; set; }
        public Usuario Usuario { get; set; }
        public int Tipo_publicacion { get; set; }
        public String Texto { get; set; }
        public DateTime Fecha { get; set; }

    }
}
