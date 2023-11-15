using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioEntity ViewModelForEntity(this UsuarioViewModel viewModel)
        {
            var senha = "12345"; //TODO implementar o gerador de senha

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
