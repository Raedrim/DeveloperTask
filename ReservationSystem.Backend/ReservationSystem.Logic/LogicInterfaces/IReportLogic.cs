using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DTOs;

namespace ReservationSystem.Logic.LogicInterfaces;

public interface IReservationLogic
{ 
    Task<Reservation> CreateReservationAsync(ReservationCreationDto dto);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
}