namespace RpcCalc.Domain.Entities
{
    public class PermissaoEntity : BaseEntity
    {
        public PermissaoEntity() { }

        public PermissaoEntity(string sistema, int acessar, Guid perfilId)
        {
            Sistema = sistema;
            Acessar = acessar;
            PerfilId = perfilId;
        }

        public string Sistema { get; private set; } = null!;
        public int Acessar { get; private set; }
        public Guid PerfilId { get; private set; }

        public virtual PerfilEntity? Perfil { get; private set; }
    }
}
