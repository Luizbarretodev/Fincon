using Fincon.Domain.Enums;

namespace Fincon.Api.Models;

public record AtualizarRecorrenciaRequest(
 string Descricao,
 decimal ValorParcela,
 int QuantidadeParcelas,
 DateTime DataInicio,
 TipoRecorrencia Tipo
);