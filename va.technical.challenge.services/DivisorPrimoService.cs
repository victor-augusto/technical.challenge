using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;

namespace va.technical.challenge.services
{
    public class DivisorPrimoService : IDivisorPrimoService
    {
        private readonly IMapper _mapper;

        public DivisorPrimoService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DivisorPrimoResponse> ObterDivisoresPrimosAsync(DivisorPrimoRequest request)
        {
            var divisoresPrimos = new List<int>();

            foreach (var divisor in request.Divisores)
            {
                if (divisor <= 1)
                    continue;
                if (divisor == 2)
                    divisoresPrimos.Add(divisor);
                if (divisor % 2 == 0)
                    continue;

                var isPrimo = true;
                for (int i = 3; i <= divisor; i++)
                {
                    if (divisor != i && divisor % i == 0)
                        isPrimo = false;
                }
                if (isPrimo)
                    divisoresPrimos.Add(divisor);
            }

            return await Task.FromResult(_mapper.Map<DivisorPrimoResponse>(divisoresPrimos));
        }
    }
}
