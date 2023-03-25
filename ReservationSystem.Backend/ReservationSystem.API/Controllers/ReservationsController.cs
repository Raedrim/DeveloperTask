using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DTOs;
using ReservationSystem.Logic.LogicInterfaces;

namespace ReservationSystem.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationLogic _reservationLogic;

        public ReservationsController(IReservationLogic reservationLogic)
        {
            _reservationLogic = reservationLogic;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation(ReservationCreationDto dto)
        {
            try
            {
                var created = await _reservationLogic.CreateReservationAsync(dto);
                return Created($"/api/reservations/{created.Id}", created);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationLogic.GetAllReservationsAsync();
        }
    }
}