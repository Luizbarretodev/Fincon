using Fincon.Api.Models.Auth;
using Fincon.Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RegistraUsuarioUseCase _registraUsuarioUseCase;
    private readonly LoginUseCase _loginUseCase;

    public AuthController(RegistraUsuarioUseCase registraUsuarioUseCase, LoginUseCase loginUseCase)
    {
        _registraUsuarioUseCase = registraUsuarioUseCase;
        _loginUseCase = loginUseCase;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
    {
        try
        {
            var usuario = await _registraUsuarioUseCase.ExecutarAsync(request.Nome, request.Email, request.Senha);
            return Ok(new { usuario.Id, usuario.Nome, usuario.Email });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = await _loginUseCase.ExecutarAsync(request.Email, request.Senha);
            return Ok(new { token });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}