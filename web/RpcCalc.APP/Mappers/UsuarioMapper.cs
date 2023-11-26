﻿using RpcCalc.APP.Interop.Usuarios;

namespace RpcCalc.APP.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto ViewModelForDto(this UsuarioViewModel viewModel)
        {
            return new UsuarioDto()
            {
                CnpjCpf = viewModel.CnpjCpf!,
                Nome = viewModel.Nome!,
                Login = viewModel.Login!,
                Email = viewModel.Email!,
                Celular = viewModel.Celular,
            };
        }

        public static UsuarioViewModel DtoForViewModel(this UsuarioDto dto)
        {
            return new UsuarioViewModel()
            {
                CnpjCpf = dto.CnpjCpf!,
                Nome = dto.Nome!,
                Login = dto.Login!,
                Email = dto.Email!,
                Celular = dto.Celular!,
            };
        }
    }
}
