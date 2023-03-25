using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DTOs;

namespace ReservationSystem.Logic.DAOInterfaces;

public interface IReservationDao
{
    Task<Reservation> CreateReservationAsync(ReservationCreationDto dto);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
}