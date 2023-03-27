using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DAOInterfaces;
using ReservationSystem.Logic.DTOs;

namespace ReservationSystem.Data.DAOs;

public class ReservationDao : IReservationDao
{
    private readonly ApplicationDbContext _context;

    public ReservationDao(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation> CreateReservationAsync(ReservationCreationDto dto)
    {
        var room = await _context.Rooms.FindAsync(dto.RoomId);

        if (room == null)
        {
            throw new ArgumentException("Invalid Room Id");
        }

        //room is too small for this many people
        if (room.NumberOfPeople < dto.NumberOfPeople)
        {
            throw new ArgumentException("Not enough space for this many people, there can be maximum " +
                                        room.NumberOfPeople + " people in this room");
        }

        if (dto.DateFrom > dto.DateTo)
        {
            throw new ArgumentException("DateFrom cannot be after DateTo");
        }

        //check if there is already a reservation for this room at this time
        var reservations = await _context.Reservations
            .Where(r => r.Room.Id == dto.RoomId)
            .ToListAsync();
        foreach (var existingReservation in reservations)
        {
            if (existingReservation.DateFrom < dto.DateTo && dto.DateFrom < existingReservation.DateTo)
            {
                throw new ArgumentException("There is already a reservation for this room at this time");
            }
        }


        var reservation = new Reservation
        {
            Room = room,
            DateFrom = dto.DateFrom,
            DateTo = dto.DateTo,
            ReservedPeople = dto.NumberOfPeople
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return reservation;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }
}