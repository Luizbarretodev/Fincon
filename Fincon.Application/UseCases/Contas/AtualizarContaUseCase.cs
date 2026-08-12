using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Contas;

public class AtualizarContaUseCase
{
    private readonly IContaRepository _contaRepository;

    public AtualizarContaUseCase(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<Conta> ExecutarAsync(Guid id, string nome)
    {
        var conta = await _contaRepository.ObterPorIdAsync(id);
        if (conta == null)
            throw new ArgumentException("Conta não encontrada", nameof(id));

        conta.AtualizarNome(nome);
        await _contaRepository.AtualizarAsync(conta);
        return conta;
    }
}