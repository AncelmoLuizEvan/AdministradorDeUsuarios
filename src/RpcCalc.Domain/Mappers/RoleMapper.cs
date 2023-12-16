using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto EntityForDto(this RoleEntity entity)
        {
            return new RoleDto()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao
            };
        }

        public static IEnumerable<RoleDto> EntityForDtoList(this IEnumerable<RoleEntity> entityList)
        {
            return (from entity in entityList
                    select new RoleDto
                    {
                        Id = entity.Id,
                        Descricao = entity.Descricao,
                        Nome = entity.Nome,
                    }).ToList();
        }

        public static IEnumerable<RoleEntity> ViewModelForEntityList(this IEnumerable<RoleDto> dtoList)
        {
            return (from dto in dtoList
                    select new RoleEntity(dto.Nome, dto.Descricao)
                    {
                        Id = dto.Id
                    }).ToList();
        }
    }
}
