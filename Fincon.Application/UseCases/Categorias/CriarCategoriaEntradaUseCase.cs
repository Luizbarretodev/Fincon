using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class CriarCategoriaEntradaUseCase
{
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;

    public CriarCategoriaEntradaUseCase(ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<CategoriaEntrada> ExecutarAsync(string nome)
    {
        var entrada = new CategoriaEntrada(nome);
        await _categoriaEntradaRepository.CriaEntradaAsync(entrada);

        return entrada;
    }
}