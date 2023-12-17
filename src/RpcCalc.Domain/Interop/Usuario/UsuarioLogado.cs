﻿namespace RpcCalc.Domain.Interop.Usuario
{
    public class UsuarioLogado
    {
        public bool Sucesso { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; } = string.Empty;
        public UsuarioInfo? Usuario { get; set; }
    }

    public class UsuarioInfo
    {
        public UsuarioInfo(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
