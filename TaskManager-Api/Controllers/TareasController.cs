using Microsoft.AspNetCore.Mvc;
using TaskManager_Api.Models;
using TaskManager_Api.Repositories;

namespace TaskManager_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaRepository _repository;

        public TareasController(ITareaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns>Una lista de tareas.</returns>
        /// <response code="200">Devuelve la lista de tareas.</response>
        [HttpGet]
        public IActionResult GetAllTareas()
        {
            var tareas = _repository.GetAllTareas();
            return Ok(tareas);
        }

        /// <summary>
        /// Obtiene una tarea por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarea.</param>
        /// <returns>La tarea correspondiente al ID proporcionado.</returns>
        /// <response code="200">Devuelve la tarea encontrada.</response>
        /// <response code="404">No se encontró la tarea.</response>
        [HttpGet("{id}")]
        public IActionResult GetTareaById(int id)
        {
            var tarea = _repository.GetTareaById(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="tarea">El objeto tarea a crear.</param>
        /// <returns>La tarea creada.</returns>
        /// <response code="201">Devuelve la tarea creada.</response>
        /// <response code="400">La solicitud es inválida.</response>
        [HttpPost]
        public IActionResult CreateTarea(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tarea.FechaCreacion = DateTime.Now;
            _repository.AddTarea(tarea);
            return CreatedAtAction(nameof(GetTareaById), new { id = tarea.Id }, tarea);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">El ID de la tarea a actualizar.</param>
        /// <param name="tarea">El objeto tarea con los nuevos datos.</param>
        /// <returns>La tarea actualizada.</returns>
        /// <response code="200">Devuelve la tarea actualizada.</response>
        /// <response code="404">No se encontró la tarea.</response>
        [HttpPut("{id}")]
        public IActionResult UpdateTarea(int id, Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTarea = _repository.GetTareaById(id);
            if (existingTarea == null)
            {
                return NotFound();
            }
            _repository.UpdateTarea(tarea);
            return Ok(tarea);
        }

        /// <summary>
        /// Elimina una tarea por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarea a eliminar.</param>
        /// <response code="204">La tarea se ha eliminado correctamente.</response>
        /// <response code="404">No se encontró la tarea.</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteTarea(int id)
        {
            _repository.DeleteTarea(id);
            return NoContent();
        }
    }
}
