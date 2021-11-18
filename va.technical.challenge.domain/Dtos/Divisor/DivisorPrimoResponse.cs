using System.Collections.Generic;

namespace va.technical.challenge.domain.Dtos.Divisor
{
    public class DivisorPrimoResponse
    {
        public DivisorPrimoResponse(IList<int> divisoresPrimos)
        {
            DivisoresPrimos = divisoresPrimos;
        }

        public IList<int> DivisoresPrimos { get; private set; }
    }
}
