﻿namespace RpcCalc.Domain.Interop.Usuario
{
    public class LoginDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<RoleDto> Roles { get; set; } = null!;
    }
}
