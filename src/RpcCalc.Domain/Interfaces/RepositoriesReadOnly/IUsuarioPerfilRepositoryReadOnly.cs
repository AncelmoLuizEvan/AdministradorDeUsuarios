﻿using RpcCalc.Domain.Entities;

namespace RpcCalc.Domain.Interfaces.RepositoriesReadOnly
{
    public interface IUsuarioPerfilRepositoryReadOnly : IRepositoryReadOnly<UsuarioPerfilEntity>
    {
        Task<IEnumerable<UsuarioPerfilEntity>> CapiturarPorUsuario(Guid usuarioId);
    }
}
