using System.ComponentModel.DataAnnotations;

namespace TaskManager_Api.Models
{
    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
        public required string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
