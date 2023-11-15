namespace RpcCalc.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }
    }
}
