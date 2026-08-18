using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class Recorrencia
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal ValorParcela { get; private set; }
    public int QuantidadeParcelas { get; private set; }
    public DateTime DataInicio { get; private set; }
    public TipoRecorrencia Tipo { get; private set; }

    public Recorrencia(string descricao, decimal valorParcela, int quantidadeParcelas, DateTime dataInicio, TipoRecorrencia tipo)
    {
        if (string.IsNullOrWhiteSpace(descricao))
        {
            throw new ArgumentException("Descrição é obrigatória", nameof(descricao));
        }
        if (valorParcela <= 0)
        {
            throw new ArgumentException("Valor não pode ser 0", nameof(valorParcela));
        }

        if (quantidadeParcelas <= 0)
        {
            throw new ArgumentException("Quantidade deve ser 1 ou mais", nameof(quantidadeParcelas));
        }

        Id = Guid.NewGuid();
        Descricao = descricao;
        ValorParcela = valorParcela;
        QuantidadeParcelas = quantidadeParcelas;
        DataInicio = dataInicio;
        Tipo = tipo;
    }

    public void Atualizar(string descricao, decimal valorParcela, int quantidadeParcelas, DateTime dataInicio, TipoRecorrencia tipo)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("A descrição é obrigatória", nameof(descricao));
        if (valorParcela <= 0)
            throw new ArgumentException("O valor deve ser maior que zero", nameof(valorParcela));
        if (quantidadeParcelas <= 0)
            throw new ArgumentException("Quantidade deve ser 1 ou mais", nameof(quantidadeParcelas));

        Descricao = descricao;
        ValorParcela = valorParcela;
        QuantidadeParcelas = quantidadeParcelas;
        DataInicio = dataInicio;
        Tipo = tipo;
    }
}