using RpcCalc.APP.Interop.Perfis;

namespace RpcCalc.APP.Mappers
{
    public static class PerfilMapper
    {
        public static PerfilDto ViewModelForDto(this PerfilViewModel viewModel)
        {
            return new PerfilDto()
            {
                Nome = viewModel.Nome!,
                Descricao = viewModel.Descricao
            };
        }

        public static PerfilViewModel DtoForViewModel(this PerfilDto dto)
        {
            return new PerfilViewModel()
            {
                Nome = dto.Nome!,
                Descricao = dto.Descricao
            };
        }
    }
}
