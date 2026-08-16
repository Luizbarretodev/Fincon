using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Infrastructure.Repositories;

public class EntradaRepository : IEntradaRepository
{
    private readonly AppDbContext _context;

    public EntradaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Entrada entrada)
    {
        _context.Add(entrada);

        await _context.SaveChangesAsync();
    }

    public async Task<Entrada?> ObterPorIdAsync(Guid id)
    {
        return await _context.Entradas.FindAsync(id);
    }

    public async Task AtualizarAsync(Entrada entrada)
    {
        _context.Entradas.Update(entrada);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Guid id)
    {
        var entrada = await _context.Entradas.FindAsync(id);
        if (entrada != null)
        {
            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
        }
    }
}