using AutoMapper;
using comentarios_backend.Data;
using comentarios_backend.DTO;
using comentarios_backend.Models;
using comentarios_backend.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comentarios_backend.Services
{
    public class ComentarioService : IComentarioService
    {
        private IMapper _mapper;
        private IComentarioRepository _repository;

        public ComentarioService(IMapper mapper, IComentarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ComentarioDto>> ListadoComentario()
        {
            List<ComentarioDto> result;
            try
            {
                List<Comentario> listAll = await _repository.getAll();
                result = new List<ComentarioDto>();
                foreach (Comentario comentario in listAll)
                {
                    var comentarioDto = _mapper.Map<ComentarioDto>(comentario);
                    result.Add(comentarioDto);
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        public async Task<ComentarioDto> ComentarioPorId(int id)
        {
            ComentarioDto result;
            try
            {
                var comentario = await _repository.ComentarioPorId(id);
                if (comentario == null)
                {
                    throw new Exception("Comentario no encontrado");
                }
                result = _mapper.Map<ComentarioDto>(comentario);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public async Task<ComentarioDto> NuevoComentario(ComentarioDto comentarioDto)
        {
            ComentarioDto result;
            try
            {
                Comentario model = _mapper.Map<Comentario>(comentarioDto);
                var resultDb = await _repository.NuevoComentario(model);
                result = _mapper.Map<ComentarioDto>(resultDb);
            }
            catch(Exception ex)
            {
                result = null;
            }
            return result;
        }

        public async Task<ComentarioDto> ActualizarComentario(int id, ComentarioDto comentarioDto)
        {
            ComentarioDto result;
            try
            {
                Comentario model = _mapper.Map<Comentario>(comentarioDto);
                var resultDb = await _repository.ActualizarComentario(id, model);
                result = _mapper.Map<ComentarioDto>(resultDb);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public async Task<Boolean> EliminarComentario(int id)
        {
            Boolean result = true;
            try
            {
                var resultDb = await _repository.EliminarComentario(id);
                if (!resultDb)
                {
                    throw new Exception("Comentario no eliminado.");
                }
                result = resultDb;
            } 
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
