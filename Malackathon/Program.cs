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

app.MapGet("/embalses", (double x, double y) => new GetReservoirsOrderedByDistance().Execute(new Location(x,y)));

app.MapGet("/embalse", (int id) => new GetReservoirInfo().Execute(id));
app.MapGet("/", () => "Hello World!");

app.MapGet("/agua-embalse", (int id) => new GetReservoirWater().Execute(id));

app.Run();