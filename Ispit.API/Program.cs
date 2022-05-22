using Ispit.API.Data;
using Ispit.Data.Interfaces;
using Ispit.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//naredba koja omogu�ava spajanje s bazom
builder.Services.AddDbContext<ApplicationDbContext>();

//definiranje objekta neke klase (app bi radio i bez toga - slu�i za povezivanje interfejsa)
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
