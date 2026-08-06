using Fincon.Api.Models;
using Fincon.Application.Interfaces;
using Fincon.Application.UseCases.Categorias;
using Fincon.Application.UseCases.Contas;
using Fincon.Application.UseCases.Recorrencias;
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
builder.Services.AddScoped<IRecorrenciaRepository, RecorrenciaRepository>();
builder.Services.AddScoped<CriaContaUseCase>();
builder.Services.AddScoped<CriaCategoriaEntradaUseCase>();
builder.Services.AddScoped<CriaCategoriaSaidaUseCase>();
builder.Services.AddScoped<CriaRecorrenciaUseCase>();
builder.Services.AddScoped<ListaContasUseCase>();
builder.Services.AddScoped<ListaCategoriasSaidaUseCase>();
builder.Services.AddScoped<ListaCategoriasEntradaUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Fincon-web", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("Fincon-web");

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
