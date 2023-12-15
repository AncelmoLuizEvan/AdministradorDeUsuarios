namespace RpcCalc.Domain.Entities
{
    public class PermissaoEntity : BaseEntity
    {
        public PermissaoEntity() { }

        public PermissaoEntity(string sistema, int acessar)
        {
            Sistema = sistema;
            Acessar = acessar;
        }

        public string Sistema { get; private set; } = null!;
        public int Acessar { get; private set; }

        public ICollection<UsuarioPerfilEntity> UsuariosPerfis { get; private set; } = new HashSet<UsuarioPerfilEntity>();
    }
}
