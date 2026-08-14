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
builder.Services.AddScoped<CriarContaUseCase>();
builder.Services.AddScoped<CriarCategoriaEntradaUseCase>();
builder.Services.AddScoped<CriarCategoriaSaidaUseCase>();
builder.Services.AddScoped<CriarRecorrenciaUseCase>();
builder.Services.AddScoped<ListarContasUseCase>();
builder.Services.AddScoped<ListarCategoriasSaidaUseCase>();
builder.Services.AddScoped<ListarCategoriasEntradaUseCase>();
builder.Services.AddScoped<AtualizarContaUseCase>();
builder.Services.AddScoped<ExcluirContaUseCase>();
builder.Services.AddScoped<AtualizarCategoriaSaidaUseCase>();
builder.Services.AddScoped<ExcluirCategoriaSaidaUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Fincon-web", policy =>
    {
               policy.WithOrigins(builder.Configuration["FrontendUrl"]!)
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
