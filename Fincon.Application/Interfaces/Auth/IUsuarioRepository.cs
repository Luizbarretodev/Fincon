using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces.Auth;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario);
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<bool> EmailExisteAsync(string email);
}