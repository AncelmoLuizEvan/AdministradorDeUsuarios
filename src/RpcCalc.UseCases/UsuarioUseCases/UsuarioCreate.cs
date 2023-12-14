using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioCreate : IUsuarioCreate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;

        private DateTime DataInicio { get; set; }
        private DateTime? DataFinal { get; set; }

        public UsuarioCreate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IUsuarioPerfilRepository repositoryUsuarioPerfil)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = usuarioRepositoryReadOnly;
            _repositoryUsuarioPerfil = repositoryUsuarioPerfil;
        }

        public async Task<UsuarioDto> Execute(UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var entity = viewModel.ViewModelForEntity();

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                foreach (var usuarioPerfil in viewModel.UsuarioPerfis)
                {
                    CalculaIntervaloPerfil(usuarioPerfil.Perfil);

                    usuarioPerfil.UsuarioId = result!.Id;
                    usuarioPerfil.DataInicio = DataInicio;
                    usuarioPerfil.DataFinal = DataFinal;

                    var usuarioPerfilEntity = usuarioPerfil.DtoForEntity();
                    await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);
                }

                _unitOfWork.Commit();

                if (result is not null)
                    return result.EntityForDto();

                return new UsuarioDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                _unitOfWork.Rollback();
                throw;
            }

        }

        private void CalculaIntervaloPerfil(string perfil)
        {
            switch (perfil)
            {
                case "Anual":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddHours(1);
                    break;
                case "Semestral":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddMonths(6);
                    break;
                case "Vitalicio":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddHours(30);
                    break;
            }
        }
    }
}
