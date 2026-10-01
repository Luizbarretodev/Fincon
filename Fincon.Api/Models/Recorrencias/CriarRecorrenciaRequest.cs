using Fincon.Domain.Enums;

namespace Fincon.Api.Models.Recorrencias;

public record CriarRecorrenciaRequest(
    string Descricao,
    decimal ValorParcela,
    int QuantidadeParcelas,
    DateTime DataInicio,
    TipoRecorrencia Tipo
);