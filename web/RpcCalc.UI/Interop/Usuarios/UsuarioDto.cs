﻿namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string CnpjCpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Celular { get; set; }
        public bool Inativo { get; set; }
    }
}
