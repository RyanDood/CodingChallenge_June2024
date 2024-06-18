using CodingChallenge.Context;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Repositories;
using CodingChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CodingChallengeContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CodingChallengePolicy", opts =>
    {
        opts.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002", "http://localhost:3003", "http://localhost:3004", "http://localhost:3005", "http://localhost:3006", "http://localhost:3007").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
builder.Services.AddScoped<IRepository<int, Event>, EventRepository>();
builder.Services.AddScoped<IRepository<int, Registration>, RegistrationRepository>();

builder.Services.AddScoped<IUserUserService, UserService>();
builder.Services.AddScoped<IEventAdminService, EventService>();
builder.Services.AddScoped<IRegistrationAdminService, RegistrationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CodingChallengePolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
