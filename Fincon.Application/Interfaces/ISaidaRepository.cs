using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface ISaidaRepository
{
    Task AdicionarAsync(Saida saida);
    Task<Saida?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Saida saida);
    Task ExcluirAsync(Guid id);
}