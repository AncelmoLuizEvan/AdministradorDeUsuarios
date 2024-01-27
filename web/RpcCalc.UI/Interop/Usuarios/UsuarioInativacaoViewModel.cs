using System.Text.Json.Serialization;

namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioInativacaoViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public bool Inativo { get; set; }

        [JsonIgnore]
        public string Nome { get; set; } = string.Empty;

        [JsonIgnore]
        public string _mensagem { get; set; } = string.Empty;
    }
}
