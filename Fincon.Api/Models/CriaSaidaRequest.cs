using Fincon.Domain.Enums;

namespace Fincon.Api.Models;

public record CriaSaidaRequest(
    DateTime Data,
    decimal Valor,
    string Descricao,
    StatusTransacao Status,
    Guid ContaId,
    Guid CategoriaSaidaId,
    Guid? RecorrenciaId
);