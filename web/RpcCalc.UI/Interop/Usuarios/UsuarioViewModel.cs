using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O CNPJ-CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 14 números")]
        [RegularExpression(@"([0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "Número CPF incorreto!")]

        public string CnpjCpf { get; set; } = null!;

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string? Nome { get; set; } = null!;

        [JsonIgnore]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; } = null!;

        [RegularExpression(@"\(\d{2}\)\d{4,5}\-\d{4}", ErrorMessage = "Número de telefone incorreto!")]
        public string? Celular { get; set; }

        public bool Inativo { get; set; }

        public List<UsuarioRoleDto> Roles { get; set; } = new List<UsuarioRoleDto>();

        public List<UsuarioPerfilDto> UsuarioPerfis { get; set; } = new List<UsuarioPerfilDto>();

        [JsonIgnore]
        public string _mensagemPerfil { get; set; } = string.Empty;

        [JsonIgnore]
        public string _mensagemRole { get; set; } = string.Empty;

        [JsonIgnore]
        public string _mensagem { get; set; } = string.Empty;
    }
}
