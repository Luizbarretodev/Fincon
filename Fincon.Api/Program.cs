using Fincon.Api.Models;
using Fincon.Application.Interfaces;
using Fincon.Application.Interfaces.Auth;
using Fincon.Application.UseCases.Auth;
using Fincon.Application.UseCases.Categorias;
using Fincon.Application.UseCases.Contas;
using Fincon.Application.UseCases.Movimentacoes;
using Fincon.Application.UseCases.Recorrencias;
using Fincon.Infrastructure.Context;
using Fincon.Infrastructure.Repositories;
using Fincon.Infrastructure.Repositories.Auth;
using Fincon.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Conta
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<CriarContaUseCase>();
builder.Services.AddScoped<ListarContasUseCase>();
builder.Services.AddScoped<AtualizarContaUseCase>();
builder.Services.AddScoped<ExcluirContaUseCase>();
//Categoria Entrada
builder.Services.AddScoped<ICategoriaEntradaRepository, CategoriaEntradaRepository>();
builder.Services.AddScoped<CriarCategoriaEntradaUseCase>();
builder.Services.AddScoped<ListarCategoriasEntradaUseCase>();
builder.Services.AddScoped<AtualizarCategoriaEntradaUseCase>();
builder.Services.AddScoped<ExcluirCategoriaEntradaUseCase>();
//Categoria Saida
builder.Services.AddScoped<ICategoriaSaidaRepository, CategoriaSaidaRepository>();
builder.Services.AddScoped<CriarCategoriaSaidaUseCase>();
builder.Services.AddScoped<ListarCategoriasSaidaUseCase>();
builder.Services.AddScoped<AtualizarCategoriaSaidaUseCase>();
builder.Services.AddScoped<ExcluirCategoriaSaidaUseCase>();
//Entrada
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<AtualizarSaidaUseCase>();
//Saida
builder.Services.AddScoped<ISaidaRepository, SaidaRepository>();
builder.Services.AddScoped<ExcluirSaidaUseCase>();
//Recorrencia
builder.Services.AddScoped<IRecorrenciaRepository, RecorrenciaRepository>();
builder.Services.AddScoped<CriarRecorrenciaUseCase>();
builder.Services.AddScoped<AtualizarRecorrenciaUseCase>();
builder.Services.AddScoped<ExcluirRecorrenciaUseCase>();
//Auth
builder.Services.AddScoped<RegistraUsuarioUseCase>();
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();


//Caso não funcione com a chave, vai aceitar receber os chamados da URL definida aq
var frontendUrl = builder.Configuration["FrontendUrl"] ?? "http://localhost:5173";

builder.Services.AddCors(options =>
{
    options.AddPolicy("Fincon-web", policy =>
    {
        policy.WithOrigins(frontendUrl)
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
