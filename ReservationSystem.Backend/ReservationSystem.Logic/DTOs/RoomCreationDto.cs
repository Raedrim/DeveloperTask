using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Logic.DTOs;

public class RoomCreationDto
{
    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int NumberOfPeople { get; set; }

    
}
