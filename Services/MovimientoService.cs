using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Dto.Request;
using Dto.Response;
using Entities;

namespace Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _repository;
        public MovimientoService(IMovimientoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoMovimientoResponse>> ListAsync()
        {
            var collection = await _repository.ListCollectionAsync();

            return collection.Select(x => new DtoMovimientoResponse
            {
                MovimientoId = x.MovimientoId,
                CuentaId = x.CuentaId,
                Fecha = x.Fecha,
                TipoMovimiento = x.TipoMovimiento,
                Valor = x.Valor,
                Saldo = x.Saldo
            }).ToList();
        }

        public async Task<ICollection<DtoMovimientoResponse>> ListCuentaAsync(int id)
        {
            var collection = await _repository.ListCollectionCuentaAsync(id);

            return collection.Select(x => new DtoMovimientoResponse
            {
                MovimientoId = x.MovimientoId,
                CuentaId = x.CuentaId,
                Fecha = x.Fecha,
                TipoMovimiento = x.TipoMovimiento,
                Valor = x.Valor,
                Saldo = x.Saldo
            }).ToList();
        }

        public async Task<DtoMovimientoResponse> GetByIdAsync(int id)
        {
            var mov = await _repository.GetAsync(id);

            if (mov == null)
                return null;

            return new DtoMovimientoResponse
            {
                MovimientoId = mov.MovimientoId,
                CuentaId = mov.CuentaId,
                Fecha = mov.Fecha,
                TipoMovimiento = mov.TipoMovimiento,
                Valor = mov.Valor,
                Saldo = mov.Saldo
            };
        }

        public async Task<int> CreateAsync(DtoMovimientoRequest request)
        {
            if(!request.TipoMovimiento)
            {
                var listaMov = await _repository.ListCollectionCuentaAsync(request.CuentaId);
                var hoy = DateTime.Now;
                var cantidadHoy = listaMov.Where(x => x.Fecha.Year == hoy.Year
                                                    && x.Fecha.Month == hoy.Month
                                                    && x.Fecha.Day == hoy.Day
                                                    && x.TipoMovimiento == false).Sum(a => a.Valor);
                if(((cantidadHoy + request.Valor)*-1) > 1000)
                {
                    return -2;
                }

                var movFinal = listaMov.OrderByDescending(a => a.MovimientoId).FirstOrDefault();
                if((movFinal.Saldo + request.Valor) < 0)
                {
                    return -1;
                }
            }
            
            return await _repository.CreateAsync(new Movimiento
            {
                CuentaId = request.CuentaId,
                Fecha = request.Fecha,
                TipoMovimiento = request.TipoMovimiento,
                Valor = request.Valor,
                Saldo = request.Saldo
            });
        }

        public async Task<int> UpdateAsync(int id, DtoMovimientoRequest request)
        {
            return await _repository.UpdateAsync(new Movimiento
            {
                MovimientoId = id,
                CuentaId = request.CuentaId,
                Fecha = request.Fecha,
                TipoMovimiento = request.TipoMovimiento,
                Valor = request.Valor,
                Saldo = request.Saldo
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
