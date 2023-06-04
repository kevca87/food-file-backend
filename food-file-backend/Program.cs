using food_file_backend.Controllers;
using food_file_backend.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRecipesService,RecipesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//CORS 

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
        //options.WithOrigins("https://ncv-application.web.app/", "http://localhost:5009/").AllowAnyHeader().AllowAnyMethod();

    });
});

app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });