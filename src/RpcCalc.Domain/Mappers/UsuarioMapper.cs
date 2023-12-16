using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioEntity ViewModelForEntity(this UsuarioViewModel viewModel, string senha)
        {

            return new UsuarioEntity(
                viewModel.CnpjCpf!,
                viewModel.Nome!,
                viewModel.Login!,
                senha,
                viewModel.Email!,
                DateTime.Now,
                DateTime.Now,
                viewModel.Celular,
                0,
                0);
        }

        public static UsuarioDto EntityForDto(this UsuarioEntity entity)
        {
            return new UsuarioDto()
            {
                Id = entity.Id,
                CnpjCpf = entity.CnpjCpf,
                Nome = entity.Nome,
                Login = entity.Login,
                Email = entity.Email,
                Celular = entity.Celular,
                Inativo = entity.Inativo == 1 ? true : false,
                Roles = entity.Roles.EntityForDtoList().ToList()
            };
        }

        public static LoginDto EntityForLoginDto(this UsuarioEntity entity)
        {
            return new LoginDto()
            {
               Nome = entity.Nome,
               Email = entity.Email,
            };
        }

        public static IEnumerable<UsuarioDto> EntityForDtoList(this IEnumerable<UsuarioEntity> entityList)
        {
            return (from entity in entityList
                    select new UsuarioDto
                    {
                        Id = entity.Id,
                        CnpjCpf = entity.CnpjCpf,
                        Nome = entity.Nome,
                        Login = entity.Login,
                        Email = entity.Email,
                        Celular = entity.Celular,
                        Inativo = entity.Inativo == 1 ? true : false,
                    }).ToList();
        }
    }
}
