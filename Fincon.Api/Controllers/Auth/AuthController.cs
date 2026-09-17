using Fincon.Api.Models;
using Fincon.Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RegistraUsuarioUseCase _registraUsuarioUseCase;

    public AuthController(RegistraUsuarioUseCase registraUsuarioUseCase)
    {
        _registraUsuarioUseCase = registraUsuarioUseCase;
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
}