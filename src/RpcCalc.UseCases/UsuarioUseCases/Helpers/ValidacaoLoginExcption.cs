namespace RpcCalc.UseCases.UsuarioUseCases.Helpers
{
    [Serializable]
    public class ValidacaoLoginExcption : Exception
    {
        public ValidacaoLoginExcption() { }

        public ValidacaoLoginExcption(string mensagem)
            : base(String.Format("Erro ao realizar o login: {0}", mensagem))
        {

        }
    }
}
