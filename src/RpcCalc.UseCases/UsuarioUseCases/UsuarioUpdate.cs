using MySqlX.XDevAPI.Common;
using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioUpdate : IUsuarioUpdate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;

        public UsuarioUpdate(IUnitOfWork unitOfWork, 
            IUsuarioRepository repository, 
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepository usuarioPerfilRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryUsuarioPerfil = usuarioPerfilRepository;
        }

        public async Task<UsuarioDto> Execute(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var usuario = await _repositoryReadOnly.Capturar(id);

                usuario!.AtualizarDados(viewModel.CnpjCpf, viewModel.Nome, viewModel.Login, viewModel.Email, viewModel.Celular);

                await _repository.Alterar(usuario);

                foreach (var usuarioPerfil in viewModel.UsuarioPerfis)
                {
                    usuarioPerfil.UsuarioId = usuario!.Id;

                    var jaCadastrado = usuario.UsuarioPerfis.Any(x => x.UsuarioId == usuarioPerfil.UsuarioId && x.PerfilId == usuarioPerfil.PerfilId && x.PermissaoId == usuarioPerfil.PermissaoId);
                    
                    if (jaCadastrado) 
                        continue;

                    var usuarioPerfilEntity = usuarioPerfil.DtoForEntity(usuarioPerfil.Perfil);
                    await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);
                }

                _unitOfWork.Commit();

                return usuario.EntityForDto();
            }
            catch (Exception ex)
            {
                var logErro = ex.Message;
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
