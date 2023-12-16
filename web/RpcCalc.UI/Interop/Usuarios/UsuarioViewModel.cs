using RpcCalc.UI.Interop.Roles;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O CNPJ-CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 14 números")]
        public string CnpjCpf { get; set; } = null!;

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string? Nome { get; set; } = null!;

        [Required(ErrorMessage = "O Login é obrigatório")]
        public string? Login { get; set; } = null!;

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; } = null!;

        public string? Celular { get; set; }

        public List<UsuarioRoleDto> Roles { get; set; } = new List<UsuarioRoleDto>();

        public List<UsuarioPerfilDto> UsuarioPerfis { get; set; } = new List<UsuarioPerfilDto>();

        [JsonIgnore]
        public string _mensagemPerfil { get; set; } = string.Empty;

        [JsonIgnore]
        public string _mensagemRole { get; set; } = string.Empty;
    }
}
