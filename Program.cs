using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrganizadorContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("ConexaoPadrao"),
    new MySqlServerVersion(new Version(8, 0, 0))));
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
