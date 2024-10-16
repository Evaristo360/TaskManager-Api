using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager_Api.Models;

namespace TaskManager_Api.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly IDbContextFactory<TareasDbContext> _contextFactory;

        public TareaRepository(IDbContextFactory<TareasDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IEnumerable<Tarea> GetAllTareas()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Tareas.ToList();
        }

        public Tarea GetTareaById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Tareas.Find(id);
        }

        public void AddTarea(Tarea tarea)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Tareas.Add(tarea);
            context.SaveChanges();
        }

        public void UpdateTarea(Tarea tarea)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Tareas.Update(tarea);
            context.SaveChanges();
        }

        public void DeleteTarea(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var tarea = context.Tareas.Find(id);
            if (tarea != null)
            {
                context.Tareas.Remove(tarea);
                context.SaveChanges();
            }
        }
    }
}
