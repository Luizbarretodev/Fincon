using Fincon.Application.Interfaces;
using Fincon.Application.Interfaces.Auth;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Auth;

public class RegistraUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ISenhaHasher _senhaHasher;

    public async Task<Usuario> ExecutarAsync(string nome, string email, string senha)
    {
        var Em = _usuarioRepository.EmailExisteAsync(email);
    }
}