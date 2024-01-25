namespace RpcCalc.Domain.Entities
{
    public class PerfilEntity : BaseEntity
    {
        public PerfilEntity() { }

        public PerfilEntity(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; } = null!;
        public string? Descricao { get; private set; }

        public ICollection<UsuarioPerfilEntity> UsuariosPerfis { get; private set; } = new HashSet<UsuarioPerfilEntity>();

        public void AtualizarDados(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao ?? string.Empty;
            DataAtualizacao = DateTime.Now;
        }
    }
}
