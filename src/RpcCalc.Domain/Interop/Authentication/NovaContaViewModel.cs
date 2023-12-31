﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RpcCalc.Domain.Interop.Authentication
{
    public class NovaContaViewModel
    {
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 14 números")]
        public string CnpjCpf { get; set; } = null!;

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail correto")]
        public string Email { get; set; } = null!;

        public string? Celular { get; set; }

        [JsonIgnore]
        public string? Login { get; set; }

        [JsonIgnore]
        public int Role { get; set; }

        [JsonIgnore]
        public int Perfil { get; set; }
    }
}
