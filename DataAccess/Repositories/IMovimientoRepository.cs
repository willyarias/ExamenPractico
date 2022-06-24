using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Repositories
{
    public interface IMovimientoRepository
    {
        Task<ICollection<Movimiento>> ListCollectionAsync();

        Task<ICollection<Movimiento>> ListCollectionCuentaAsync(int id);

        Task<Movimiento> GetAsync(int id);

        Task<int> CreateAsync(Movimiento movimiento);

        Task<int> UpdateAsync(Movimiento movimiento);

        Task DeleteAsync(int id);
    }
}
