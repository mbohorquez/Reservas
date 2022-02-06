using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ReservasCore6.Data;
using ReservasCore6.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReservasCore6.Controllers
{
    [TestFixture]
    public class ReservasContrellerNUnitTest
    {

        private ReservasController _context;
        private readonly ILogger<ReservasController> _logger;
        private List<Reserva> _reservasNUnit;

        public ReservasContrellerNUnitTest()
        {
            // se crea un moq de logger
            _logger = Mock.Of<ILogger<ReservasController>>();
        }

        [SetUp]
        public void Setup()
        {
            // se inicializa librerias utiles
            var fixture = new Fixture();
            var random = new Random();
            //Se trae data basada de los modelos
            var reservasFix = fixture.CreateMany<Reserva>().ToList();
            // esto se realiza por si aun no existe data de ejemplo para el FIXTURE
            reservasFix.Add(fixture.Build<Reserva>().With(x => x.IdReserva).Create());
            _reservasNUnit = reservasFix;
            // se crea instancia en memoria de la bd
            var options = new DbContextOptionsBuilder<AplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: $"ReservasDB-{Guid.NewGuid()}")
                          .Options;
            // se inicializa
            var reservasDbFake = new AplicationDbContext(options);
            // ingresa la data de prueba
            reservasDbFake.Reserva.AddRange(reservasFix);
            // se guarda
            reservasDbFake.SaveChanges();
            // se tiene un contexto local de la prueba
            _context = new ReservasController(_logger, reservasDbFake);
        }

        [Test]
        public async Task ConsultaReservaId_Return_Ok()
        {
            // se realiza petinicion
            Task<ActionResult<Reserva>> task = _context.GetReserva(_reservasNUnit.FirstOrDefault().IdReserva);
            // se espera tarea
            dynamic result = await task;
            // se verifica si el resultado es el deseado
            Assert.AreEqual(200,(int)result.Result.StatusCode);
        }

        [Test]
        public async Task ConsultaReservaFechas_Return_Ok()
        {
            // se realiza peticicion
            Task<ActionResult<List<Reserva>>> task = _context.GetReserva(_reservasNUnit.FirstOrDefault().FechaEntrada,
                                                                         _reservasNUnit.LastOrDefault().FechaSalida);
            // se espera tarea
            dynamic result = await task;
            // se verifica si el resultado es el deseado
            Assert.AreEqual(200, (int)result.Result.StatusCode);
        }
        [Test]
        public async Task ActualizarEstadoReserva_Return_Ok()
        {
            // se realiza peticicion
            Task<ActionResult<Reserva>> task = _context.PutCancelarReserva(_reservasNUnit.FirstOrDefault().IdReserva);
            // se espera tarea
            dynamic result = await task;
            // se verifica si el resultado es el deseado
            Assert.AreEqual(200, (int)result.Result.StatusCode);
         }

        [Test]
        public async Task CrearReserva_Return_Ok()
        {
            // se crea objeto para luego mandarlo al post
            var reserva = new ReservaVM();
            reserva.IdHotel = (int)_reservasNUnit.FirstOrDefault().IdHotel;
            reserva.IdUsuario = (int)_reservasNUnit.FirstOrDefault().IdUsuario;
            reserva.FechaEntrada = _reservasNUnit.FirstOrDefault().FechaEntrada;
            reserva.FechaSalida= _reservasNUnit.FirstOrDefault().FechaSalida;
            reserva.NumeroHabitacion = 1;
            reserva.FechaReserva = DateTime.Now;
            reserva.Estado = true;
            // se realiza peticicion
            Task<ActionResult<ReservaVM>> task = _context.PostReservas(reserva);
            // se espera tarea
            dynamic result = await task;
            // se verifica si el resultado es el deseado
            Assert.AreEqual(201, (int)result.Result.StatusCode);
        }
    }
}
