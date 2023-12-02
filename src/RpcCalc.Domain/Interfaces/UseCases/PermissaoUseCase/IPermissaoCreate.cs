using RpcCalc.Domain.Interop.Permissao;

namespace RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase
{
    public interface IPermissaoCreate
    {
        Task<PermissaoDto> Execute(PermissaoViewModel viewModel);
    }
}
