using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;

namespace va.technical.challenge.services
{
    public class DivisorService : IDivisorService
    {
        private readonly IMapper _mapper;
        private readonly IDivisorPrimoService _divisorPrimoService;

        public DivisorService(IMapper mapper, IDivisorPrimoService divisorPrimoService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _divisorPrimoService = divisorPrimoService ?? throw new ArgumentNullException(nameof(divisorPrimoService));
        }

        public async Task<DivisorResponse> ObterDivisoresAsync(DivisorRequest divisor)
        {
            if (divisor.Numero <= 0)
                throw await Task.FromResult(new ArgumentException("O campo número deve ser maior que zero."));

            var divisoresNaturais = new List<int>();

            for (int i = 1; i < divisor.Numero; i++)
            {
                if (divisor.Numero % i == 0)
                    divisoresNaturais.Add(i);
            }

            var primosRequest = _mapper.Map<DivisorPrimoRequest>(divisoresNaturais);

            var divisoresPrimos = await _divisorPrimoService.ObterDivisoresPrimosAsync(primosRequest);

            return _mapper.Map<DivisorResponse>(Tuple.Create(divisor.Numero, divisoresNaturais, divisoresPrimos.DivisoresPrimos));
        }
    }
}
