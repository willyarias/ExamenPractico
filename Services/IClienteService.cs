using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IClienteService
    {
        Task<ICollection<DtoClienteResponse>> ListAsync();

        Task<DtoClienteResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(DtoClienteRequest request);

        Task<int> UpdateAsync(int id, DtoClienteRequest request);

        Task DeleteAsync(int id);
        Task<ICollection<DtoClienteCuentas>> GetCuentasAsync(int id);
    }
}