using System;

namespace comentarios_backend.DTO
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Creador { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
