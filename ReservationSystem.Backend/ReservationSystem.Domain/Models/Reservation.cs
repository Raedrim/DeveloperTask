using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DateTo { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }
    
    [Required]
    public int ReservedPeople { get; set; }

    [ForeignKey("Room")]
    public int RoomId { get; set; }
    public Room Room { get; set; }
}