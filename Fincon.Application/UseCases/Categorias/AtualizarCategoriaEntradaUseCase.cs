using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;

public class AtualizarCategoriaEntradaUseCase
{
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;
    public AtualizarCategoriaEntradaUseCase(ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<CategoriaEntrada> ExecutarAsync(Guid id, string nome)
    {
        var categoriaEntrada = await _categoriaEntradaRepository.ObterPorIdAsync(id);
        if (categoriaEntrada == null)
            throw new ArgumentException("Categoria não encontrada", nameof(id));

        categoriaEntrada.AtualizarNome(nome);
        await _categoriaEntradaRepository.AtualizarAsync(categoriaEntrada);
        return categoriaEntrada;
    }
}