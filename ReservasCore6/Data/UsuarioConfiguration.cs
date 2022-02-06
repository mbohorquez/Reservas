using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservasCore6.Models;

namespace ReservasCore6.Data
{
    public class UsuarioConfiguration
    {
        // se realiza una carga de ejemplo para usuario
        public UsuarioConfiguration(EntityTypeBuilder<Usuario> entityBuilder)
        {
            var usuarios = new List<Usuario>();

            for (var i = 1; i <= 100; i++)
            {
                usuarios.Add(new Usuario
                {
                    IdUsuario = i,
                    Nombre = $"usuario {i}",
                    Apellidos = $"apellido {i}",
                    Email = $"Email@dominio.com {i}",
                    Direccion = $"Direccion {i}"

                }); ;
             }
            // se especifica que es data inicial
            entityBuilder.HasData(usuarios);
        }
    }
}
