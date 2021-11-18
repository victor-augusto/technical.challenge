using System.Collections.Generic;

namespace va.technical.challenge.domain.Dtos.Divisor
{
    public class DivisorResponse
    {
        public DivisorResponse(int numero, IList<int> divisoresNaturais, IList<int> divisoresPrimos)
        {
            Numero = numero;
            DivisoresNaturais = divisoresNaturais;
            DivisoresPrimos = divisoresPrimos;
        }

        public int Numero { get; private set; }
        public IList<int> DivisoresNaturais { get; private set; }
        public IList<int> DivisoresPrimos { get; private set; }
    }
}
