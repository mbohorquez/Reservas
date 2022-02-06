using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCore6.Data;
using ReservasCore6.Models;

namespace ReservasCore6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservasController : Controller
    {
        private readonly ILogger<ReservasController> _logger;
        private readonly AplicationDbContext _context;

        public ReservasController(ILogger<ReservasController> logger, AplicationDbContext contexto )
        {
            _logger = logger;
            _context = contexto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            _logger.LogInformation($"Obteniedo el id {id} de la reserva.");
            var reserva = await _context.Reserva.FindAsync(id);
            if(reserva == null)
            {
                _logger.LogWarning($"No se encontro data relacionada al id {id}");
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpGet("{FCheckIn}/{FCheckOut}")]
        public async Task<ActionResult<List<Reserva>>> GetReserva(DateTime FCheckIn, DateTime FCheckOut)
        {
            _logger.LogInformation($"Obteniedo reservas entre las fechas {FCheckIn} y {FCheckOut}");
            // Esta consulta trae el data completa del usuario y hotel, se se desea solo traer el email se puede armar un modelo 
            // especifico para que se vea organizada la data
            var reserva = await _context.Reserva.Include(x => x.Usuario)
                                                .Include(x => x.Hotel)
                                                .OrderByDescending(x => x.FechaEntrada >= FCheckIn &&
                                                x.FechaSalida <= FCheckOut).Take(1000).ToListAsync(); 
            if (reserva == null)
            {
                _logger.LogWarning($"No se encontro data relacionada entre las fechas {FCheckIn} y {FCheckOut}");
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaVM>> PostReservas (ReservaVM reserva)
        {
            try
            {
                _logger.LogInformation("Realizando guardado de reserva");
                var reservaContext = new Reserva();
                reservaContext.IdUsuario = reserva.IdUsuario;
                reservaContext.IdHotel = reserva.IdHotel;
                reservaContext.FechaEntrada = reserva.FechaEntrada;
                reservaContext.FechaSalida = reserva.FechaSalida;
                reservaContext.NumeroHabitacion = reserva.NumeroHabitacion;
                reservaContext.FechaReserva = DateTime.Now;
                reservaContext.Estado = reserva.Estado;
                _context.Reserva.Add(reservaContext);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetReserva), new { id = reservaContext.IdReserva }, reserva);
            }
            catch (Exception ex)
            {
                _logger.LogError("error al intertar guardar la reserva " + ex);
                return BadRequest("Existe un problema al realizar el registro de la reserva " + ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reserva>> PutCancelarReserva(int id)
        {
            try
            {
                _logger.LogInformation($"Obteniedo el id {id} de la reserva para actualizar estado de la reserva");
                var reserva = await _context.Reserva.FindAsync(id);
                if (reserva == null)
                {
                    _logger.LogWarning($"No se encontro data relacionada al id {id} para actualizar estado de la reserva");
                    return BadRequest();
                }
                reserva.Estado = false;
                _context.Entry(reserva).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(reserva);
            }catch (Exception ex)
            {
                _logger.LogError("error al intertar actualizar la reserva " + ex);
                return BadRequest("Existe un problema al realizar el registro de la reserva " + ex);
            }
        }
    }
}
