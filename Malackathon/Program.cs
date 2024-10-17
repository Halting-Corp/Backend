var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Recibir coordenadas, devolver embalses ordenados por distancia


app.MapGet("/embalses", () => { });
app.MapGet("/embalse", () => { });


app.Run();