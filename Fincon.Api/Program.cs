using Fincon.Application.Interfaces;
using Fincon.Application.UseCases.Contas;
using Fincon.Infrastructure.Context;
using Fincon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ICategoriaEntradaRepository, CategoriaEntradaRepository>();
builder.Services.AddScoped<ICategoriaSaidaRepository, CategoriaSaidaRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<ISaidaRepository, SaidaRepository>();
builder.Services.AddScoped<CriaContaUseCase>();


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
