using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;
public interface ICategoriaEntradaRepository
{
    Task<List<CategoriaEntrada>> ListarCategoriasEntrada();
    Task<bool> ExisteAsync(Guid id);
    Task CriaEntradaAsync(CategoriaEntrada entrada);
    Task<CategoriaSaida> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(CategoriaSaida saida);
    Task ExcluirAsync(Guid id);
}