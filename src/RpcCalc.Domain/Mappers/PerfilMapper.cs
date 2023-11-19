using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.Domain.Mappers
{
    public static class PerfilMapper
    {
        public static PerfilEntity ViewModelForEntity(this PerfilViewModel viewModel)
        {
            return new PerfilEntity(viewModel.Nome, viewModel.Descricao);
        }

        public static PerfilDto EntityForDto(this PerfilEntity entity)
        {
            return new PerfilDto()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao
            };
        }

        public static IEnumerable<PerfilDto> EntityForDtoList(this IEnumerable<PerfilEntity> entityList)
        {
            return (from entity in entityList
                    select new PerfilDto
                    {
                        Id = entity.Id,
                        Nome = entity.Nome,
                        Descricao = entity.Descricao
                    }).ToList();
        }
    }
}
