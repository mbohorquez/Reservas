using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasCore6.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        [Required]
        public int? IdUsuario { get; set; }
        [Required]
        public int? IdHotel { get; set; }
        [Required]
        public int NumeroHabitacion { get; set; }
        [Required]
        public DateTime FechaEntrada { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public DateTime FechaReserva { get; set; }
        [Required]
        public bool Estado { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("IdHotel")]
        public virtual Hotel? Hotel { get; set; }
    }

    public class ReservaVM
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]
        public int NumeroHabitacion { get; set; }
        [Required]
        public DateTime FechaEntrada { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public DateTime FechaReserva { get; set; }
        [Required]
        public bool Estado { get; set; }

    }

}
