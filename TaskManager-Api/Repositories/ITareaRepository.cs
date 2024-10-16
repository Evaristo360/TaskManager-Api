using TaskManager_Api.Models;

namespace TaskManager_Api.Repositories
{
    public interface ITareaRepository
    {
        IEnumerable<Tarea> GetAllTareas();
        Tarea GetTareaById(int id);
        void AddTarea(Tarea tarea);
        void UpdateTarea(Tarea tarea);
        void DeleteTarea(int id);
    }
}
