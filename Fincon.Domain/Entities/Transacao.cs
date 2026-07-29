using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public abstract class Transacao
{
    public Guid Id { get; private set; }
    public DateTime Data { get; private set; }
    public decimal Valor { get; private set; }
    public string Descricao { get; private set; }
    public StatusTransacao Status { get; private set; }
    public Guid ContaId { get; private set; }
    public Guid? RecorrenciaId { get; private set; }

    protected Transacao(DateTime data, decimal valor, string descricao, StatusTransacao status, Guid contaId, Guid? recorrenciaId)
    {
            
    }
}