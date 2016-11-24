using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Facebook4532.Models
{
    public class Publicacion
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int MeGusta { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public virtual List<Comentario> Comentarios { get; set; }
    }
}