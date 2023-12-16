using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Mappers
{
    public static class UsuarioRoleMapper
    {
        public static UsuarioRoleEntity DtoForEntity(this UsuarioRoleDto dto)
        {
            return new UsuarioRoleEntity(dto.UsuarioId, dto.RoleId);
        }

        public static IEnumerable<UsuarioRoleDto> EntityForDtoList(this IEnumerable<UsuarioRoleEntity> entityList)
        {
            return (from entity in entityList
                    select new UsuarioRoleDto
                    {
                        UsuarioId = entity.UsuarioId,
                        RoleId = entity.RoleId,
                        Role = entity.Role.EntityForDto()
                    }).ToList();
        }
    }
}
