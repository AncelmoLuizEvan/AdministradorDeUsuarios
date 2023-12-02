using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Permissao;

namespace RpcCalc.Domain.Mappers
{
    public static class PermissaoMapper
    {
        public static PermissaoEntity ViewModelForEntity(this PermissaoViewModel viewModel)
        {
            var acessar = (viewModel.Acessar) ? 1 : 0;

            return new PermissaoEntity(viewModel.Sistema, acessar, viewModel.PerfilId);
        }

        public static PermissaoDto EntityForDto(this PermissaoEntity entity)
        {
            return new PermissaoDto()
            {
                Id = entity.Id,
                Sistema = entity.Sistema,
                Acessar = entity.Acessar == 1 ? true : false,
                PerfilId = entity.PerfilId,
                Perfil = entity.Perfil!.EntityForDto()
            };
        }

        public static IEnumerable<PermissaoDto> EntityForDtoList(this IEnumerable<PermissaoEntity> entityList)
        {
            return (from entity in entityList
                    select new PermissaoDto
                    {
                        Id = entity.Id,
                        Sistema = entity.Sistema,
                        Acessar = entity.Acessar == 1 ? true : false,
                        PerfilId = entity.PerfilId
                    }).ToList();
        }
    }
}
