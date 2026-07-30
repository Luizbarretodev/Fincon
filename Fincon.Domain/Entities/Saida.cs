using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class Saida : Transacao
{
    public Guid CategoriaSaidaId { get; private set; }

    public Saida(DateTime data, decimal valor, string descricao, StatusTransacao status, Guid contaId, Guid? recorrenciaId, Guid categoriaSaidaId)
        : base(data, valor, descricao, status, contaId, recorrenciaId)
    {
        if (categoriaSaidaId == Guid.Empty)
        {
            throw new ArgumentException("Id não pode ser vazio", nameof(categoriaSaidaId));
        }

        CategoriaSaidaId = categoriaSaidaId;
    }
}