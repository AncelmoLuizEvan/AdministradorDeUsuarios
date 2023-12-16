using RpcCalc.UI.Interop.Usuarios;

namespace RpcCalc.UI.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto ViewModelForDto(this UsuarioViewModel viewModel)
        {
            return new UsuarioDto()
            {
                CnpjCpf = viewModel.CnpjCpf!,
                Nome = viewModel.Nome!,
                Login = viewModel.Login!,
                Email = viewModel.Email!,
                Celular = viewModel.Celular,
            };
        }

        public static UsuarioViewModel DtoForViewModel(this UsuarioDto dto)
        {
            return new UsuarioViewModel()
            {
                CnpjCpf = dto.CnpjCpf!,
                Nome = dto.Nome!,
                Login = dto.Login!,
                Email = dto.Email!,
                Celular = dto.Celular!,
                UsuarioPerfis = dto.UsuarioPerfis,
                Roles = dto.Roles
            };
        }
    }
}
