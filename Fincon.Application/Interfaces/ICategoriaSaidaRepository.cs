using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface ICategoriaSaidaRepository
{
    Task<List<CategoriaSaida>> ListarCategoriasSaida();
    Task<bool> ExisteAsync(Guid id);
    Task CriaSaidaAsync(CategoriaSaida saida);
    Task<CategoriaSaida?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(CategoriaSaida saida);
    Task ExcluirAsync(Guid id);
}