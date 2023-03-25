using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DAOInterfaces;
using ReservationSystem.Logic.DTOs;
using ReservationSystem.Logic.LogicInterfaces;

namespace ReservationSystem.Logic.LogicImplementations;

public class ReservationLogic : IReservationLogic
{
    private  readonly IReservationDao _reservationDao;

    public ReservationLogic(IReservationDao reservationDao)
    {
        _reservationDao = reservationDao;
    }

    public async Task<Reservation> CreateReservationAsync(ReservationCreationDto dto)
    {
        Reservation created = await _reservationDao.CreateReservationAsync(dto);
        return created;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _reservationDao.GetAllReservationsAsync();

    }
}