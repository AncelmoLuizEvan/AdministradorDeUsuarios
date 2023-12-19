namespace RpcCalc.Domain.Entities
{
    public class UsuarioPerfilEntity : BaseEntity
    {
        public UsuarioPerfilEntity() { }

        public UsuarioPerfilEntity(Guid usuarioId, Guid perfilId, Guid permissaoId, string perfil)
        {
            UsuarioId = usuarioId;
            PerfilId = perfilId;
            PermissaoId = permissaoId;

            CalculaIntervaloPerfil(perfil);
        }

        public Guid UsuarioId { get; private set; }
        public UsuarioEntity Usuario { get; set; }

        public Guid PerfilId { get; private set; }
        public PerfilEntity Perfil { get; set; }

        public Guid PermissaoId { get; private set; }
        public PermissaoEntity Permissao { get; set; }

        public DateTime DataInicio { get; private set; }
        public DateTime? DataFinal { get; private set; }


        private void CalculaIntervaloPerfil(string perfil)
        {
            switch (perfil)
            {
                case "Anual":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddHours(1);
                    break;
                case "Semestral":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddMonths(6);
                    break;
                case "Vitalicio":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddHours(30);
                    break;
                case "Mensal":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddMonths(1);
                    break;
                case "Semana":
                    DataInicio = DateTime.Now;
                    DataFinal = DateTime.Now.AddDays(7);
                    break;
            }
        }
    }
}
