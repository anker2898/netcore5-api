using comentarios_backend.DTO;
using comentarios_backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comentarios_backend.Services
{
    public interface IComentarioService
    {
        Task<List<ComentarioDto>> ListadoComentario();
        Task<ComentarioDto> ComentarioPorId(int id);
        Task<ComentarioDto> NuevoComentario(ComentarioDto comentarioDto);
        Task<ComentarioDto> ActualizarComentario(int id, ComentarioDto comentarioDto);
        Task<Boolean> EliminarComentario(int id);
    }
}
