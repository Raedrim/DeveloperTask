using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DAOInterfaces;
using ReservationSystem.Logic.DTOs;

namespace ReservationSystem.Data.DAOs;

public class RoomDao : IRoomDao
{

    private readonly ApplicationDbContext _context;

    public RoomDao(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Room> CreateRoomAsync(RoomCreationDto dto)
    {
        Room room = new Room
        {
            NumberOfPeople = dto.NumberOfPeople,
            Name = dto.Name
        };
        EntityEntry<Room> entityEntry = await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        List<Room> rooms = await _context.Rooms.ToListAsync();
        return rooms;
    }
}