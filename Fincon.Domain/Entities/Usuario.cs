using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string SenhaHash { get; private set; }

    public Usuario(string nome, string email, string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ficar em branco", nameof(nome));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ficar em branco", nameof(email));

        if (string.IsNullOrWhiteSpace(senhaHash))
            throw new ArgumentException("Senha não pode ficar em branco", nameof(senhaHash));

        try
        {
            new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Formato de email inváldo", nameof(email));
        }

        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
    }
}