namespace RpcCalc.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public UsuarioEntity() { }

        public UsuarioEntity(string cnpjCpf,
                             string nome,
                             string login,
                             string senha,
                             string email,
                             DateTime? dataHoraAcesso,
                             DateTime? dataHoraInclusao,
                             string? celular,
                             int? emailVerificado,
                             int? inativo)
        {
            CnpjCpf = cnpjCpf;
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            DataHoraAcesso = dataHoraAcesso;
            DataHoraInclusao = dataHoraInclusao;
            Celular = celular;
            EmailVerificado = emailVerificado;
            Inativo = inativo;
        }

        public string CnpjCpf { get; private set; } = null!;
        public string Nome { get; private set; } = null!;
        public string Login { get; private set; } = null!;
        public string Senha { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public DateTime? DataHoraAcesso { get; private set; }
        public DateTime? DataHoraInclusao { get; private set; }
        public string? Celular { get; private set; }
        public int? EmailVerificado { get; private set; }
        public int? Inativo { get; private set; }

        public ICollection<MotivoInativacaoEntity>? MotivoInativacaoEntities { get; private set; }
        public ICollection<UsuarioPerfilEntity> UsuarioPerfis { get; private set; }
        public ICollection<UsuarioRoleEntity> Roles { get; private set; }

        public void AtualizarDados(string cnpjCpf,
           string nome,
           string login,
           string email,
           string? celular)
        {
            CnpjCpf = cnpjCpf;
            Nome = nome;
            Login = login;
            Email = email;
            Celular = celular;
            DataAtualizacao = DateTime.Now;
        }

        public void AtivarInativar(int ativarInativar)
        {
            Inativo = ativarInativar;
        }
    }
}
