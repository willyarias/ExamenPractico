using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICuentaService
    {
        Task<ICollection<DtoCuentaResponse>> ListAsync();

        Task<ICollection<DtoCuentaResponse>> ListClienteAsync(int id);

        Task<DtoCuentaResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(DtoCuentaRequest request);

        Task<int> UpdateAsync(int id, DtoCuentaRequest request);

        Task DeleteAsync(int id);
    }
}
