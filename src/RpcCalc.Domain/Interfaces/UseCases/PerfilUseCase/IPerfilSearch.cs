using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase
{
    public interface IPerfilSearch
    {
        Task<IEnumerable<PerfilDto>> Listar();
        Task<PerfilDto?> Capturar(Guid id);
    }
}
