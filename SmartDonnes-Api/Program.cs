using Microsoft.EntityFrameworkCore;
using SmartDonnes_Api.Data;
using SmartDonnes_Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
// Microsoft.AspNetCore.Mvc.NewtonsoftJson
.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ADD FOR ME INJECTION DEPENCY HERE TO DONNES PROJECT
builder.Services.AddScoped<IRepository, Repository>();

//ADD FOR ME CONTEXT ACCESS TO DONNES PROJECT
builder.Services.AddDbContext<MyDataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ADD CORS POLITICS
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.Run();
