using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.MotivoInativacao;

namespace RpcCalc.Domain.Mappers
{
    public static class MotivoInativacaoMapper
    {
        public static MotivoInativacaoEntity ViewModelForEntity(this MotivoInativacaoViewModel viewModel)
        {
            return new MotivoInativacaoEntity(viewModel.Descricao, viewModel.Usuario);
        }

        public static MotivoInativacaoDto EntityForDto(this MotivoInativacaoEntity entity)
        {
            return new MotivoInativacaoDto()
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                UsuarioId = entity.UsuarioId
            };
        }

        public static IEnumerable<MotivoInativacaoDto> EntityForDtoList(this IEnumerable<MotivoInativacaoEntity> entityList)
        {
            return (from entity in entityList
                    select new MotivoInativacaoDto
                    {
                        Id = entity.Id,
                        Descricao = entity.Descricao,
                        UsuarioId = entity.UsuarioId
                    }).ToList();
        }
    }
}
