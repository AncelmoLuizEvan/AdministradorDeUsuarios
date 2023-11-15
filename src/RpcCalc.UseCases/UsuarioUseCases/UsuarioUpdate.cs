using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioUpdate : IUsuarioUpdate
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;

        public UsuarioUpdate(IUsuarioRepository repository, IUsuarioRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<UsuarioDto> Execute(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                var usuario = await _repositoryReadOnly.Capturar(id);

                usuario!.AtualizarDados(viewModel.CnpjCpf, viewModel.Nome, viewModel.Login, viewModel.Email, viewModel.Celular);

                await _repository.Alterar(usuario);

                return usuario.EntityForDto();
            }
            catch (Exception ex)
            {
                var logErro = ex.Message;
                throw;
            }
        }
    }
}
