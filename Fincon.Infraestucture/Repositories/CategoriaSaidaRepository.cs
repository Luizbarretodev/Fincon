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

public class CategoriaSaidaRepository : ICategoriaSaidaRepository
{
    private readonly AppDbContext _context;

    public CategoriaSaidaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaSaida>> ListarCategoriasSaida()
    {
        return await _context.CategoriasSaida.ToListAsync();
    }
    public async Task<bool> ExisteAsync(Guid id)
    {
        return await _context.CategoriasSaida.AnyAsync(cs => cs.Id == id);
    }
    public async Task CriaSaidaAsync(CategoriaSaida saida)
    {
        _context.Add(saida);

        await _context.SaveChangesAsync();
    }

    public async Task<CategoriaSaida?> ObterPorIdAsync(Guid id)
    {
        return await _context.CategoriasSaida.FindAsync(id);
    }

    public async Task AtualizarAsync(CategoriaSaida saida)
    {
        _context.CategoriasSaida.Add(saida);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Guid id)
    {
        var saida = await _context.CategoriasSaida.FindAsync(id);
        if(saida != null)
        {
            _context.Remove(saida);
            await _context.SaveChangesAsync();
        }
    }
}