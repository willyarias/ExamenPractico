using System;
using Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PruebaDbContext _context;
        public ClienteRepository(PruebaDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cliente>> ListCollectionAsync()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        public async Task<Cliente> GetAsync(int id)
        {
            return await _context.Set<Cliente>()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente.Id;
        }

        public async Task<int> UpdateAsync(Cliente cliente)
        {
            _context.Set<Cliente>().Attach(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Cliente>()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _context.Set<Cliente>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Cuenta>> ListCuentas(int id)
        {
            return await _context.Set<Cuenta>()
                .Where(p => p.ClienteId == id)
                .ToListAsync();
        }

        
    }
}
