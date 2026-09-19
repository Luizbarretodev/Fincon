using Fincon.Application.Interfaces;
using Fincon.Application.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Auth;

public class LoginUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ISenhaHasher _senhaHasher;
    private readonly IJwtGenerator _jwtGenerator;

    public LoginUseCase(IUsuarioRepository usuarioRepository, ISenhaHasher senhaHasher, IJwtGenerator jwtGenerator)
    {
        _usuarioRepository = usuarioRepository;
        _senhaHasher = senhaHasher;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<string> ExecutarAsync(string email, string senha)
    {
        var usuario = await _usuarioRepository.ObterPorEmailAsync(email);

        if (usuario is null)
        {
            throw new ArgumentException("Email ou senha inválidos");
        }

        var verificaSenha = _senhaHasher.VerificarHash(usuario.SenhaHash, senha);

        if (!verificaSenha)
        {
            throw new ArgumentException("Email ou senha inválidos");
        }

        var token = _jwtGenerator.GerarToken(usuario);

        return token;
    }
}