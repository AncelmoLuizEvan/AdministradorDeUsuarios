﻿using System.ComponentModel.DataAnnotations;

namespace RpcCalc.UI.Interop.Permissoes
{
    public class PermissaoViewModel
    {
        [Required(ErrorMessage = "O Nome do sistema é obrigatório")]
        public string Sistema { get; set; } = null!;

        public bool Acessar { get; set; } = false;
    }
}
