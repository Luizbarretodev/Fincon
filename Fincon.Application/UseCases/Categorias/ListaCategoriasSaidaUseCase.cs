using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class ListaCategoriasSaidaUseCase
{
    private readonly ICategoriaSaidaRepository _categoriasSaidaRepository;

    public ListaCategoriasSaidaUseCase(ICategoriaSaidaRepository categoriasSaidaRepository)
    {
        _categoriasSaidaRepository = categoriasSaidaRepository;
    }

    public async Task<List<CategoriaSaida>> ExecutarAsync()
    {
       return await _categoriasSaidaRepository.ListarCategoriasSaida();
    }
}