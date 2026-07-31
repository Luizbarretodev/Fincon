using Fincon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Infrastucture.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Conta> Contas { get; set; }
    public DbSet<CategoriaEntrada> CategoriasEntrada { get; set; }
    public DbSet<CategoriaSaida> CategoriasSaida { get; set; }
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Saida> Saidas { get; set; }
    public DbSet<Recorrencia> Recorrencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Conta>(entity =>
        {
            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<CategoriaEntrada>(entity =>
        {
            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<CategoriaSaida>(entity =>
        {
            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.Valor)
                .HasPrecision(18, 2);

            entity.HasDiscriminator<string>("TipoTransacao")
                .HasValue<Entrada>("Entrada")
                .HasValue<Saida>("Saida");
        });

        modelBuilder.Entity<Recorrencia>(entity =>
        {
            entity.Property(r => r.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(r => r.ValorParcela)
                .HasPrecision(18, 2);
        });
    }

}