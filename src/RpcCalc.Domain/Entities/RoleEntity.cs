namespace RpcCalc.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public RoleEntity() { }

        public RoleEntity(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<UsuarioRoleEntity> Usuarios { get; private set; }
    }
}
