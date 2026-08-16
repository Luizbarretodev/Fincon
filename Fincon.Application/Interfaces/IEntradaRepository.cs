using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface IEntradaRepository
{
    Task AdicionarAsync(Entrada entrada);
    Task<Entrada?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Entrada entrada);
    Task ExcluirAsync(Guid id);
}