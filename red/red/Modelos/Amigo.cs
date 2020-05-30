using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace red.Modelos
{
    [Table("amigo")]
    public class Amigo
    {
        public int AmigoID { get; set; }
        public int Id_usuario { get; set; }
        public Usuario Usuario { get; set; }
        public int Id_usuario_amigo { get; set; }
        public Usuario Usuario_amigo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
