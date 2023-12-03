using RpcCalc.APP.Interop.Permissoes;

namespace RpcCalc.APP.Mappers
{
    public static class PermissaoMapper
    {
        public static PermissaoDto ViewModelForDto(this PermissaoViewModel viewModel)
        {
            return new PermissaoDto()
            {
                Sistema = viewModel.Sistema,
                PerfilId = viewModel.PerfilId,
                Acessar = viewModel.Acessar
            };
        }

        public static PermissaoViewModel DtoForViewModel(this PermissaoDto dto)
        {
            return new PermissaoViewModel()
            {
                Sistema = dto.Sistema!,
                PerfilId = dto.PerfilId,
                Perfil = dto.Perfil.Descricao!,
                Acessar = dto.Acessar
            };
        }
    }
}
