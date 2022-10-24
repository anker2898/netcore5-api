using comentarios_backend.Data;
using comentarios_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comentarios_backend.Repository
{
    public class ComentarioRepository: IComentarioRepository
    {
        private ApplicationDbContext _context;

        public ComentarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comentario>> getAll()
        {
            var result = await _context.Comentarios.ToListAsync();
            return result;
        }

        public async Task<Comentario> ComentarioPorId(int id)
        {
            Comentario result;
            try
            {
                result = await _context.Comentarios.FindAsync(id);
            } catch(Exception ex)
            {
                result=null;
            }
            return result;
        }

        public async Task<Comentario> NuevoComentario(Comentario model)
        {
            Comentario result;
            try
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                result = model;
            } catch(Exception ex)
            {
                result = null;
            }
            return result;
        }

        public async Task<Comentario> ActualizarComentario(int id, Comentario model)
        {
            Comentario result;
            try
            {
                if (id != model.Id)
                {
                    throw new Exception("Modelo no coincide con id");
                }
                _context.Update(model);
                await _context.SaveChangesAsync();
                result = model;
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
                var validExist = await _context.Comentarios.FindAsync(id);
                if (validExist == null)
                {
                    throw new Exception("Comentario no existe.");
                }
                _context.Comentarios.Remove(validExist);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
