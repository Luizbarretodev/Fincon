using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Infrastructure.Repositories;

public class SaidaRepository : ISaidaRepository
{
    private readonly AppDbContext _context;

    public SaidaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Saida saida)
    {
        _context.Add(saida);

        await _context.SaveChangesAsync();
    }

    public async Task<Saida?> ObterPorIdAsync(Guid id)
    {
        return await _context.Saidas.FindAsync(id);
    }

    public async Task AtualizarAsync(Saida saida)
    {
        _context.Saidas.Update(saida);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Guid id)
    {
        var saida = await _context.Saidas.FindAsync(id);
        if (saida != null)
        {
            _context.Saidas.Remove(saida);
            await _context.SaveChangesAsync();
        }
    }
}