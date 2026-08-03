using Fincon.Domain.Enums;

namespace Fincon.Api.Models;

public record CriaRecorrenciaRequest(
    string descricao,
    decimal valorParcela,
    int quantidadeParcelas,
    DateTime dataInicio,
    TipoRecorrencia tipo
);