using Microsoft.EntityFrameworkCore;

namespace TaskManager_Api.Models
{
    public class TareasDbContext : DbContext
    {
        public TareasDbContext(DbContextOptions<TareasDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
