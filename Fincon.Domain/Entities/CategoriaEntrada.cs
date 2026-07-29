using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class CategoriaEntrada
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }

    public CategoriaEntrada(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome é obrigatório", nameof(nome));
        }
        Nome = nome;

        Id = Guid.NewGuid();
    }
}
