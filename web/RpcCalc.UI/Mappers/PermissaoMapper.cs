using RpcCalc.UI.Interop.Permissoes;

namespace RpcCalc.UI.Mappers
{
    public static class PermissaoMapper
    {
        public static PermissaoDto ViewModelForDto(this PermissaoViewModel viewModel)
        {
            return new PermissaoDto()
            {
                Sistema = viewModel.Sistema,
                Acessar = viewModel.Acessar
            };
        }

        public static PermissaoViewModel DtoForViewModel(this PermissaoDto dto)
        {
            return new PermissaoViewModel()
            {
                Sistema = dto.Sistema!,
                Acessar = dto.Acessar
            };
        }
    }
}
