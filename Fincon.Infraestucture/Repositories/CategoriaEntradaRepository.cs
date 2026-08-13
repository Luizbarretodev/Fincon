using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Infrastructure.Repositories;

public class CategoriaEntradaRepository : ICategoriaEntradaRepository
{
    private readonly AppDbContext _context;

    public CategoriaEntradaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaEntrada>> ListarCategoriasEntrada()
    {
        return await _context.CategoriasEntrada.ToListAsync();
    }
    public async Task<bool> ExisteAsync(Guid id)
    {
        return await _context.CategoriasEntrada.AnyAsync(ce => ce.Id == id);
    }
    public async Task CriaEntradaAsync(CategoriaEntrada entrada)
    {
        _context.Add(entrada);

        await _context.SaveChangesAsync();
    }
}