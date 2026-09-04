using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Fincon.Infrastructure.Services;

public class SenhaHasher : ISenhaHasher
{
    private readonly PasswordHasher<Usuario> _passwordHasher = new();

    public string GerarHash(string senha)
    {
        return _passwordHasher.HashPassword(null!, senha);
    }

    public bool VerificarHash(string senhaHash, string senhaDigitada)
    {
        var resultado = _passwordHasher.VerifyHashedPassword(null!, senhaHash, senhaDigitada);
        return resultado == PasswordVerificationResult.Success;
    }
}
