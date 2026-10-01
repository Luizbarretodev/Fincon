using Fincon.Domain.Enums;

namespace Fincon.Api.Models.Movimentacoes;

public record CriaEntradaRequest(
    DateTime Data,
    decimal Valor,
    string Descricao,
    StatusTransacao Status,
    Guid ContaId,
    Guid CategoriaEntradaId,
    Guid? RecorrenciaId
);