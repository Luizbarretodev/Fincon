using Fincon.Application.Interfaces;

public class ExcluirCategoriaEntradaUseCase
{
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;
    public ExcluirCategoriaEntradaUseCase(ICategoriaEntradaRepository categoriaEntradaRepository)
        => _categoriaEntradaRepository = categoriaEntradaRepository;

    public async Task ExecutarAsync(Guid id)
    {
        await _categoriaEntradaRepository.ExcluirAsync(id);
    }
}