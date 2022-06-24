using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Repositories
{
    public interface ICuentaRepository
    {
        Task<ICollection<Cuenta>> ListCollectionAsync();

        Task<ICollection<Cuenta>> ListCollectionClienteAsync(int id);

        Task<Cuenta> GetAsync(int id);

        Task<int> CreateAsync(Cuenta cuenta);

        Task<int> UpdateAsync(Cuenta cuenta);

        Task DeleteAsync(int id);
    }
}
