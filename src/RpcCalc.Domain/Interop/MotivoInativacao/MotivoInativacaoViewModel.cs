using System.ComponentModel.DataAnnotations;

namespace RpcCalc.Domain.Interop.MotivoInativacao
{
    public class MotivoInativacaoViewModel
    {
        [Required]
        public string Descricao { get; set; }
    }
}
