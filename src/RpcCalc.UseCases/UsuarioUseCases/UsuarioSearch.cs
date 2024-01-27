using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;
using RpcCalc.UseCases.UsuarioUseCases.Helpers;
using SecureIdentity.Password;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioSearch : IUsuarioSearch
    {
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepositoryReadOnly _repositoryUsuarioPerfilReadOnly;

        public UsuarioSearch(IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly repositoryUsuarioPerfilReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryUsuarioPerfilReadOnly = repositoryUsuarioPerfilReadOnly;
        }

        public async Task<UsuarioDto?> Capturar(Guid id)
        {
            var result = await _repositoryReadOnly.Capturar(id);
            if (result is null)
                return null;

            var usuario = result.EntityForDto();
            var usuarioPerfil = await _repositoryUsuarioPerfilReadOnly.CapiturarPorUsuario(usuario.Id);

            var entityForDtoList = usuarioPerfil.EntityForDtoList();
            usuario.UsuarioPerfis = entityForDtoList.ToList();

            return usuario;
        }

        public async Task<IEnumerable<UsuarioDto>?> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return Enumerable.Empty<UsuarioDto>();
        }

        public async Task<LoginDto?> ValidarLogin(string email, string senha, string sistema)
        {
            var result = await _repositoryReadOnly.ObterPorLogin(email);

            if (result == null)
                throw new ValidacaoLoginExcption("Usuário não localizado, senha inválida ou Inativo");

            if (!PasswordHasher.Verify(result.Senha, senha))
                throw new ValidacaoLoginExcption("Usuário não localizado ou Senha inválida");

            var temPerfil = result.UsuarioPerfis.FirstOrDefault(x => x.Permissao.Sistema.Equals(sistema));

            if (temPerfil is null)
                throw new ValidacaoLoginExcption("Usuário sem perfil para esse sistema");

            var dataFinalAcesso = temPerfil.DataFinal;

            if (dataFinalAcesso < DateTime.Now && dataFinalAcesso is not null)
                throw new ValidacaoLoginExcption("Permissão de acesso expirada! Entre em contado com o administrador do sistema");
            if (result is not null)
                return result.EntityForLoginDto();

            return null;
        }

        public async Task<UsuarioDto?> ObterPorEmail(string email)
        {
            var result = await _repositoryReadOnly.ObterPorLogin(email);
            if (result is null)
                return null;

            var usuario = result.EntityForDto();
            var usuarioPerfil = await _repositoryUsuarioPerfilReadOnly.CapiturarPorUsuario(usuario.Id);

            var entityForDtoList = usuarioPerfil.EntityForDtoList();
            usuario.UsuarioPerfis = entityForDtoList.ToList();

            return usuario;

        }
    }
}
