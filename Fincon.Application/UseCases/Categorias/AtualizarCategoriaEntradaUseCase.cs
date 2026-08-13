using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class AtualizarCategoriaEntradaUseCase
{
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;

    public AtualizarCategoriaEntradaUseCase(ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<CategoriaEntrada> ExecutarAsync(Guid id, string nome)
    {
        var entrada = await _categoriaEntradaRepository.ObterPorIdAsync(id);
        if (entrada == null)
            throw new ArgumentException("Categoria não encontrada", nameof(id));

        entrada.AtualizarNome(nome);
        await _categoriaEntradaRepository.AtualizarAsync(entrada);
        return entrada;
    }
}