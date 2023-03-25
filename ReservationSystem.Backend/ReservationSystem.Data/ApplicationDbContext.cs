
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Models;

namespace ReservationSystem.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../ReservationSystem.Data/ReservationSystem.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Reservations)
            .WithOne(res => res.Room)
            .HasForeignKey(res => res.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}