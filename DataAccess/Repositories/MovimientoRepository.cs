using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly PruebaDbContext _context;
        public MovimientoRepository(PruebaDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Movimiento>> ListCollectionAsync()
        {
            return await _context.Set<Movimiento>().ToListAsync();
        }

        public async Task<ICollection<Movimiento>> ListCollectionCuentaAsync(int id)
        {
            return await _context.Set<Movimiento>().Where(x => x.CuentaId == id).ToListAsync();
        }

        public async Task<Movimiento> GetAsync(int id)
        {
            return await _context.Set<Movimiento>()
               .Where(x => x.MovimientoId == id)
               .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Movimiento movimiento)
        {
            await _context.Set<Movimiento>().AddAsync(movimiento);
            await _context.SaveChangesAsync();
            return movimiento.MovimientoId;
        }

        public async Task<int> UpdateAsync(Movimiento movimiento)
        {
            _context.Set<Movimiento>().Attach(movimiento);
            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movimiento.MovimientoId;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Movimiento>()
                .SingleOrDefaultAsync(p => p.MovimientoId == id);

            if (entity != null)
            {
                _context.Set<Movimiento>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
