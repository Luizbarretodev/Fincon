using Fincon.Domain.Entities.Auth;

namespace Fincon.Application.Interfaces;

public interface IJwtGenerator
{
    string GerarToken(Usuario usuario);
}