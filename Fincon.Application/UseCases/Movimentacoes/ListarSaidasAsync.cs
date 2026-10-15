using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;

namespace Fincon.Application.UseCases.Movimentacoes;

public class ListarSaidasUseCase
{
    private readonly ISaidaRepository _saidaRepository;

    public ListarSaidasUseCase(ISaidaRepository saidaRepository)
    {
        _saidaRepository = saidaRepository;
    }

    public async Task<List<Saida>> ExecutarAsync()
    {
        return await _saidaRepository.ListarAsync();
    }
}