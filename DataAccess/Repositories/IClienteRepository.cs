using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Repositories
{
    public interface IClienteRepository
    {
        Task<ICollection<Cliente>> ListCollectionAsync();

        Task<Cliente> GetAsync(int id);

        Task<int> CreateAsync(Cliente cliente);

        Task<int> UpdateAsync(Cliente cliente);

        Task DeleteAsync(int id);

        Task<ICollection<Cuenta>> ListCuentas(int id);
    }
}
