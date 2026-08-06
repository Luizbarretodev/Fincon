using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class ListaCategoriasEntradaUseCase
{
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;

    public ListaCategoriasEntradaUseCase(ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<List<CategoriaEntrada>> ExecutarAsync()
    {
        return await _categoriaEntradaRepository.ListarCategorias();
    }
}