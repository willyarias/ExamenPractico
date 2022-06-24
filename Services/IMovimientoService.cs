using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IMovimientoService
    {
        Task<ICollection<DtoMovimientoResponse>> ListAsync();

        Task<ICollection<DtoMovimientoResponse>> ListCuentaAsync(int id);

        Task<DtoMovimientoResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(DtoMovimientoRequest request);

        Task<int> UpdateAsync(int id, DtoMovimientoRequest request);

        Task DeleteAsync(int id);
    }
}
