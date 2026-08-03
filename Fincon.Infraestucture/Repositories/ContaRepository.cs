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

public class ContaRepository : IContaRepository
{
    private readonly AppDbContext _context;

    public ContaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExisteAsync(Guid id)
    {
        return await _context.Contas.AnyAsync(c => c.Id == id);
    }
    public async Task CriaContaAsync(Conta conta)
    {
        _context.Add(conta);
        await _context.SaveChangesAsync();
    }
}