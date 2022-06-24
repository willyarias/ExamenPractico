using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly PruebaDbContext _context;
        public CuentaRepository(PruebaDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cuenta>> ListCollectionAsync()
        {
            return await _context.Set<Cuenta>().ToListAsync();
        }

        public async  Task<ICollection<Cuenta>> ListCollectionClienteAsync(int id)
        {
            return await _context.Set<Cuenta>().Where(x => x.ClienteId == id).ToListAsync();
        }

        public async Task<Cuenta> GetAsync(int id)
        {
            return await _context.Set<Cuenta>()
                .Where(x => x.CuentaId == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Cuenta cuenta)
        {
            await _context.Set<Cuenta>().AddAsync(cuenta);
            await _context.SaveChangesAsync();
            return cuenta.CuentaId;
        }

        public async Task<int> UpdateAsync(Cuenta cuenta)
        {
            _context.Set<Cuenta>().Attach(cuenta);
            _context.Entry(cuenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cuenta.CuentaId;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Cuenta>()
                .SingleOrDefaultAsync(p => p.CuentaId == id);

            if (entity != null)
            {
                _context.Set<Cuenta>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

    }
}
