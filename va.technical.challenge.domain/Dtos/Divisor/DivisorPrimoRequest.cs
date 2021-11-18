using System.Collections.Generic;

namespace va.technical.challenge.domain.Dtos.Divisor
{
    public class DivisorPrimoRequest
    {
        public DivisorPrimoRequest(IList<int> divisores)
        {
            Divisores = divisores;
        }

        public IList<int> Divisores { get; private set; }
    }
}
