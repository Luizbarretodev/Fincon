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

public class RecorrenciaRepository : IRecorrenciaRepository
{
    private readonly AppDbContext _context;

    public RecorrenciaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExisteAsync(Guid id)
    {
        return await _context.Recorrencias.AnyAsync(c => c.Id == id);
    }
    public async Task AdicionarAsync(Recorrencia recorrencias)
    {
        _context.Add(recorrencias);
        await _context.SaveChangesAsync();
    }

    public async Task<Recorrencia?> ObterPorIdAsync(Guid id)
    {
        return await _context.Recorrencias.FindAsync(id);
    }

    public async Task AtualizarAsync(Recorrencia recorrencia)
    {
        _context.Recorrencias.Update(recorrencia);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Guid id)
    {
        var recorrencia = await _context.Recorrencias.FindAsync(id);
        if (recorrencia != null)
        {
            _context.Recorrencias.Remove(recorrencia);
            await _context.SaveChangesAsync();
        }
    }
}