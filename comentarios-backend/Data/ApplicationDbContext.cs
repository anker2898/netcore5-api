using comentarios_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace comentarios_backend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Comentario> Comentarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
