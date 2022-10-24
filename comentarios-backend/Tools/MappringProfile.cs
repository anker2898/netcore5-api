using AutoMapper;
using comentarios_backend.DTO;
using comentarios_backend.Models;

namespace comentarios_backend.Tools
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ComentarioDto, Comentario>();
            CreateMap<Comentario, ComentarioDto>();
        }
    }
}
