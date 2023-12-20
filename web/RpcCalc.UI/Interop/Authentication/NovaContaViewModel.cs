using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RpcCalc.UI.Interop.Authentication
{
    public class NovaContaViewModel
    {
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 14 números")]
        [RegularExpression(@"([0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "Número CPF incorreto!")]
        public string CnpjCpf { get; set; } = null!;

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail correto")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"\(\d{2}\)\d{4,5}\-\d{4}", ErrorMessage = "Número de telefone incorreto!")]
        public string? Celular { get; set; }

        [JsonIgnore]
        public int Num1 { get; set; } = new Random().Next(1, 10);
        [JsonIgnore]
        public int Num2 { get; set; } = new Random().Next(1, 10);
        [JsonIgnore]
        public string Resultado { get; set; }

        [JsonIgnore]
        public string _mensagem { get; set; } = string.Empty;
    }
}
