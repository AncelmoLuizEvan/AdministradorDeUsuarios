using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Mappers
{
    public static class UsuarioPerfilMapper
    {
        public static UsuarioPerfilDto EntityForDto(this UsuarioPerfilEntity entity)
        {
            return new UsuarioPerfilDto()
            {
                PerfilId = entity.PerfilId,
                UsuarioId = entity.UsuarioId
            };
        }

        public static UsuarioPerfilEntity DtoForEntity(this UsuarioPerfilDto dto)
        {
            return new UsuarioPerfilEntity(dto.UsuarioId, 
                dto.PerfilId,
                dto.DataInicio,
                dto.DataFinal);
        }

        public static IEnumerable<UsuarioPerfilDto> EntityForDtoList(this IEnumerable<UsuarioPerfilEntity> entityList)
        {
            return (from entity in entityList
                    select new UsuarioPerfilDto
                    {
                        PerfilId = entity.PerfilId,
                        UsuarioId = entity.UsuarioId,
                        Perfil = entity.Perfil.Descricao,
                        Permissao = entity.Perfil.Permissoes.First().Sistema
                    }).ToList();
        }
    }
}
