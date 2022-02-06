using System.ComponentModel.DataAnnotations;

namespace ReservasCore6.Models
{  
    public class Hotel
    {
        [Key]
        public int IdHotel { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Pais { get; set; }
        [Required]
        public  double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        [Required]
        public int NumeroHabitaciones { get; set; }

    }
}
