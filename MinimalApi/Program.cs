using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MinimalApi;
using MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

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

app.MapGet("team/{id}",(ITeamService TeamService,int id)=>TeamService.Get(id));
app.MapPost("team", (ITeamService TeamService, team team)=>TeamService.Create(team));
app.MapPut("team/{id}", (ITeamService teamService, int id, team team) => teamService.Update(team, id));
app.MapDelete("team/{id}", (ITeamService teamService, int id) => teamService.Delete(id));

app.Run();
