namespace va.technical.challenge.domain.Modelos
{
    public class Erro
    {
        public Erro(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public string Codigo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
