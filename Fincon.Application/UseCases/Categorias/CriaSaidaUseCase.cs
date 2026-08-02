using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class CriaSaidaUseCase
{
    private readonly ICategoriaSaidaRepository _categoriaSaidaRepository;

    public CriaSaidaUseCase(ICategoriaSaidaRepository categoriaSaidaRepository)
    {
        _categoriaSaidaRepository = categoriaSaidaRepository;
    }

    public async Task<CategoriaSaida> ExecutarAsync(string nome)
    {
        var saida = new CategoriaSaida(nome);
        await _categoriaSaidaRepository.CriaSaidaAsync(saida);

        return saida;
    }
}
