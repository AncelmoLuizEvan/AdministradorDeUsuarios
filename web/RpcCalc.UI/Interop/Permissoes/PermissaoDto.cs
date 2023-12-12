﻿using RpcCalc.UI.Interop.Perfis;

namespace RpcCalc.UI.Interop.Permissoes
{
    public class PermissaoDto
    {
        public Guid Id { get; set; }
        public string Sistema { get; set; } = null!;
        public bool Acessar { get; set; }
        public Guid PerfilId { get; set; }

        public PerfilDto Perfil { get; set; } = null!;
    }
}