using Fincon.Application.Interfaces;
using Fincon.Application.Interfaces.Auth;
using Fincon.Domain.Entities.Auth;
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
        var EmailJaExiste = await _usuarioRepository.EmailExisteAsync(email);

        if (EmailJaExiste)
        {
            throw new ArgumentException("Email já existente", nameof(email));
        }

        var senhaHash = _senhaHasher.GerarHash(senha);
        var usuario = new Usuario(nome, email, senhaHash);

        await _usuarioRepository.AdicionarAsync(usuario);
        return usuario;
    }
}