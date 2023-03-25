using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Logic.DTOs;

public class ReservationCreationDto
{
    [Required]
    public int RoomId { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }

    [Required]
    public DateTime DateTo { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "The number of people must be greater than 0.")]
    public int NumberOfPeople { get; set; }
}
