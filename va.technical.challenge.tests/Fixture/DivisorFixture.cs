using System.Collections.Generic;
using System.Linq;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.services;
using Xunit;

namespace va.technical.challenge.tests.Fixture
{
    [CollectionDefinition(nameof(DivisorFixtureCollection))]
    public class DivisorFixtureCollection : ICollectionFixture<DivisorFixture> { }

    public class DivisorFixture : FakerUtils
    {
        public DivisorService GetDivisorServiceInstance() => GetInstance<DivisorService>();
        public DivisorPrimoService GetDivisorPrimoInstance() => GetInstance<DivisorPrimoService>();

        public DivisorRequest GetDivisorRequest(bool isValid = true)
        {
            return CreateFakerObject<DivisorRequest>()
                .CustomInstantiator(c => new DivisorRequest(isValid ? c.Random.Int(1, 1000) : c.Random.Int(-100, 0)));
        }

        public DivisorPrimoRequest GetDivisorPrimoRequest(bool isNull = false)
        {
            return CreateFakerObject<DivisorPrimoRequest>()
                .CustomInstantiator(c => new DivisorPrimoRequest(isNull ? new List<int>() : c.Random.ArrayElements<int>(new[] { 1, 2, 5, 10 }).ToList()));
        }

        public DivisorResponse GetDivisorResponse()
        {
            return CreateFakerObject<DivisorResponse>()
                .CustomInstantiator(c => new DivisorResponse(c.Random.Int(1, 1000),
                                                             c.Random.ArrayElements<int>(new[] { 1, 2, 4, 6, 12 }),
                                                             c.Random.ArrayElements<int>(new[] { 2, 3 })));
        }

        public DivisorPrimoResponse GetDivisorPrimoResponse(bool isNull = false)
        {
            return CreateFakerObject<DivisorPrimoResponse>()
                .CustomInstantiator(c => new DivisorPrimoResponse(isNull ? new List<int>() : c.Random.ArrayElements<int>(new[] { 2, 3, 5 }).ToList()));
        }
    }
}
