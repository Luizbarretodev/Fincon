using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class CategoriaSaida
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }

    public CategoriaSaida(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome é obrigatório", nameof(nome));
        }
        Nome = nome;

        Id = Guid.NewGuid();
    }

    public void AtualizarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome é obrigatório", nameof(nome));
        }
        Nome = nome;
    }
}