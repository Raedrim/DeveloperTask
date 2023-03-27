using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DTOs;

namespace ReservationSystem.Logic.DAOInterfaces;

public interface IRoomDao
{
    Task<Room> CreateRoomAsync(RoomCreationDto dto);
    Task<IEnumerable<Room>> GetAllRoomsAsync();
    Task<Room> GetRoomByIdAsync(int id);

}