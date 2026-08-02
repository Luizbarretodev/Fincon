using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
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
    public async Task CriaSaidaAsync(CategoriaSaida saida)
    {
        _context.Add(saida);

        await _context.SaveChangesAsync();
    }
}