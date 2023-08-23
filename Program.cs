using Microsoft.EntityFrameworkCore;
using ProyectoGrupalG06.Models;
//using ProyectoGrupalG06.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add context
builder.Services.AddDbContext<PROYECTOG06Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("newPolicy",
        app =>
        {
            app.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("newPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
