using Fincon.Domain.Enums;

namespace Fincon.Api.Models.Movimentacoes;

public record AtualizarSaidaRequest(
    DateTime Data,
    decimal Valor,
    string Descricao,
    StatusTransacao Status,
    Guid ContaId,
    Guid CategoriaSaidaId,
    Guid? RecorrenciaId
);