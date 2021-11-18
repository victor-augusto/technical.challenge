using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;

namespace va.technical.challenge.domain.Interfaces
{
    public interface IDivisorPrimoService
    {
        Task<DivisorPrimoResponse> ObterDivisoresPrimosAsync(DivisorPrimoRequest request);
    }
}
