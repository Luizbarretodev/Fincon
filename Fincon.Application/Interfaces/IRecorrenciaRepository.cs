using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface IRecorrenciaRepository
{
    public Task AdicionarAsync(Recorrencia recorrencia);
    Task<Recorrencia?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Recorrencia recorrencia);
    Task ExcluirAsync(Guid id);
}
