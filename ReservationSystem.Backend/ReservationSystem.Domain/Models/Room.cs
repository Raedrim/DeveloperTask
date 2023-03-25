using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReservationSystem.Domain.Models;

public class Room
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int NumberOfPeople { get; set; }

    [JsonIgnore]
    public List<Reservation>? Reservations { get; set; }

}