using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Domain.Models;
using ReservationSystem.Logic.DTOs;
using ReservationSystem.Logic.LogicInterfaces;

namespace ReservationSystem.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    
    private readonly IRoomLogic  _roomLogic;

    public RoomsController(IRoomLogic roomLogic)
    {
        _roomLogic = roomLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Room>> CreateRoom(RoomCreationDto dto)
    {
        try
        {
            Room created = await _roomLogic.CreateRoomAsync(dto);
            return Created($"/api/rooms/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
    {
        var rooms = await _roomLogic.GetAllRoomsAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoomById(int id)
    {
        var room = await _roomLogic.GetRoomByIdAsync(id);
        return Ok(room);
    }

}