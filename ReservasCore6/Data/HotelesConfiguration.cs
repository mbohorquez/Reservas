using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservasCore6.Models;

namespace ReservasCore6.Data
{
    public class HotelesConfiguration
    {
        // se realiza una carga de ejemplo para hoteles
        public HotelesConfiguration(EntityTypeBuilder<Hotel> entityBuilder)
        {
            var hoteles = new List<Hotel>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                hoteles.Add(new Hotel
                {
                    IdHotel = i,
                    Nombre = $"Hotel {i}",
                    Pais = $"Pais {i}",
                    Latitud = random.NextDouble(),
                    Longitud = random.NextDouble(),
                    Descripcion = $"Descripcion {i}",
                    Activo = true,
                    NumeroHabitaciones = random.Next(5, 100)

                }); ;
             }
            entityBuilder.HasData(hoteles);
        }
    }
}
