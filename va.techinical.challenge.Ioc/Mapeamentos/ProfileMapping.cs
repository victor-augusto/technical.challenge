using AutoMapper;
using System;
using System.Collections.Generic;
using va.technical.challenge.domain.Dtos.Divisor;

namespace va.techinical.challenge.Ioc.Mapeamentos
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<List<int>, DivisorPrimoResponse>()
                .ConstructUsing(c => new DivisorPrimoResponse(c));

            CreateMap<List<int>, DivisorPrimoRequest>()
                .ConstructUsing(c => new DivisorPrimoRequest(c));

            CreateMap<Tuple<int, List<int>, IList<int>>, DivisorResponse>()
                .ConstructUsing(c => new DivisorResponse(c.Item1, c.Item2, c.Item3));
        }
    }
}
