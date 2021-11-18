using System.Collections.Generic;

namespace va.technical.challenge.domain.Modelos
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public IList<Erro> Erros { get; set; }
    }
}
