﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RpcCalc.Domain.Interop.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O CNPJ-CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 14 números")]
        public string CnpjCpf { get; set; } = null!;

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = null!;

        [JsonIgnore]
        public string Login { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; } = null!;
        public string? Celular { get; set; }

        public List<UsuarioRoleDto> Roles { get; set; } = null!;
        public List<UsuarioPerfilDto> UsuarioPerfis { get; set; } = null!;
    }
}
