using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.Interfaces;
public interface ICategoriaEntradaRepository
{
    Task CriaEntradaAsync(CategoriaEntrada Entrada);
}