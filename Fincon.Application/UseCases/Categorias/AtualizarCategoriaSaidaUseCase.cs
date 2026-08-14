using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class AtualizarCategoriaSaidaUseCase
{
    private readonly ICategoriaSaidaRepository _categoriaSaidaRepository;
    public AtualizarCategoriaSaidaUseCase(ICategoriaSaidaRepository categoriaSaidaRepository)
    {
        _categoriaSaidaRepository = categoriaSaidaRepository;
    }

    public async Task<CategoriaSaida> ExecutarAsync(Guid id, string nome)
    {
        var categoriaSaida = await _categoriaSaidaRepository.ObterPorIdAsync(id);
        if (categoriaSaida == null)
            throw new ArgumentException("Categoria não encontrada", nameof(id));

        categoriaSaida.AtualizarNome(nome);
        await _categoriaSaidaRepository.AtualizarAsync(categoriaSaida);
        return categoriaSaida;
    }
}