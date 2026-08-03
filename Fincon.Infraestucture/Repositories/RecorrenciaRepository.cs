using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Infrastructure.Repositories;

public class RecorrenciaRepository
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
    public async Task CriaContaAsync(Recorrencia recorrencias)
    {
        _context.Add(recorrencias);
        await _context.SaveChangesAsync();
    }
}