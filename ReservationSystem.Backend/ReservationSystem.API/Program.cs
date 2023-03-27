using ReservationSystem.Data;
using ReservationSystem.Data.DAOs;
using ReservationSystem.Logic.DAOInterfaces;
using ReservationSystem.Logic.LogicImplementations;
using ReservationSystem.Logic.LogicInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IRoomDao, RoomDao>();
builder.Services.AddScoped<IReservationDao, ReservationDao>();

builder.Services.AddScoped<IRoomLogic, RoomLogic>();
builder.Services.AddScoped<IReservationLogic, ReservationLogic>();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseAuthentication();

app.Run();