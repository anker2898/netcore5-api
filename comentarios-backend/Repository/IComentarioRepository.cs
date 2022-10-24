using comentarios_backend.DTO;
using comentarios_backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comentarios_backend.Repository
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> getAll();
        Task<Comentario> ComentarioPorId(int id);
        Task<Comentario> NuevoComentario(Comentario model);
        Task<Comentario> ActualizarComentario(int id, Comentario model);
        Task<Boolean> EliminarComentario(int id);
    }
}
