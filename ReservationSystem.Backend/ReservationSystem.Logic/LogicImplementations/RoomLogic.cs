using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DAOInterfaces;
using ReservationSystem.Logic.DTOs;
using ReservationSystem.Logic.LogicInterfaces;

namespace ReservationSystem.Logic.LogicImplementations;

public class RoomLogic : IRoomLogic
{
    
    private  readonly IRoomDao _roomDao;

    public RoomLogic(IRoomDao roomDao)
    {
        this._roomDao = roomDao;
    }

    public async Task<Room> CreateRoomAsync(RoomCreationDto dto)
    {
        Room created = await _roomDao.CreateRoomAsync(dto);
        return created;
    }

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        return await _roomDao.GetAllRoomsAsync();
    }
}