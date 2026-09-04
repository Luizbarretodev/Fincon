using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;

public interface ISenhaHasher
{
    string GerarHash(string senha);
    bool VerificarHash(string senhaHash, string senhaDigitada);
}