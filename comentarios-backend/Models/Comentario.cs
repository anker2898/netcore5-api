using System;
using System.ComponentModel.DataAnnotations;

namespace comentarios_backend.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Creador { get; set; }

        [Required]
        [MaxLength(250)]
        public string Texto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}
