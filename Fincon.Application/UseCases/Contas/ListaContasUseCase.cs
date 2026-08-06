using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Contas;

public class ListaContasUseCase
{
    private readonly IContaRepository _contaRepository;

    public ListaContasUseCase(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<List<Conta>> ExecutarAsync()
    {
        return await _contaRepository.ListarAsync();
    }
}