using Malackathon;
using static Malackathon.GetReservoirsOrderedByDistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

// Recibir coordenadas, devolver embalses ordenados por distancia


app.MapGet("/embalses", (double x, double y) => new GetReservoirsOrderedByDistance().Execute(new Location(x,y)));
app.MapGet("/embalses0", () => new GetReservoirsOrderedByDistance().Execute(new Location(0,0)));

app.MapGet("/embalse", () => { });
app.MapGet("/", () => "Hello World!");


app.Run();