using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Facebook4532.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public Usuario Propietario { get; set; }
        public string Descripcion { get; set; }
        public int MeGusta { get; set; }

        public int PublicacionId { get; set; }

        [ForeignKey("PublicacionId")]
        public virtual Publicacion Publicacion { get; set; }
    }
}