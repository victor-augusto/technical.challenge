using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;

namespace va.technical.challenge.domain.Interfaces
{
    public interface IDivisorService
    {
        Task<DivisorResponse> ObterDivisoresAsync(DivisorRequest divisor);
    }
}
