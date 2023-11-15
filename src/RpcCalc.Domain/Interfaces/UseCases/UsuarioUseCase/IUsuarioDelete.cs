using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioDelete
    {
        Task<bool> Execute(Guid id);
    }
}
