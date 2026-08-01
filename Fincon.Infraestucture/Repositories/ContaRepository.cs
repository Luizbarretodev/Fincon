using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Infrastructure.Context;
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
    public async Task CriarContaAsync(Conta conta)
    {
        _context.Add(conta);
        await _context.SaveChangesAsync();
    }
}