using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Contas;

public class CriaContaUseCase 
{
    private readonly IContaRepository _contaRepository;

    public CriaContaUseCase(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<Conta> ExecutarAsync(string nome)
    {
        var conta = new Conta(nome);
        await _contaRepository.CriarContaAsync(conta);

        return conta;
    }
}