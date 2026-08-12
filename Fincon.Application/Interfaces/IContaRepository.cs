using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface IContaRepository
{
    Task<List<Conta>> ListarAsync();
    Task<bool> ExisteAsync(Guid id);
    Task CriaContaAsync(Conta conta);
    Task<Conta?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Conta conta);
    Task ExcluirAsync(Guid id);
}