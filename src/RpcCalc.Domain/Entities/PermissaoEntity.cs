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
        public Guid PerfilId { get; private set; }
        public PerfilEntity Perfil { get; private set; } = new PerfilEntity();
    }
}
