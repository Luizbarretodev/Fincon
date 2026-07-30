using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class Entrada : Transacao
{
    public Guid CategoriaEntradaId { get; private set; }

    public Entrada(DateTime data, decimal valor, string descricao, StatusTransacao status, Guid contaId, Guid? recorrenciaId, Guid categoriaEntradaId)
        : base(data, valor, descricao, status, contaId, recorrenciaId)
    {
        if(categoriaEntradaId == Guid.Empty)
        {
            throw new ArgumentException("Id não pode ser vazio", nameof(contaId));
        }

        CategoriaEntradaId = categoriaEntradaId;
    }
}