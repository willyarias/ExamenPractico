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
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _repository;
        public CuentaService(ICuentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoCuentaResponse>> ListAsync()
        {
            var collection = await _repository.ListCollectionAsync();

            return collection.Select(x => new DtoCuentaResponse
                {
                    CuentaId = x.CuentaId,
                    ClienteId= x.ClienteId,
                    NumeroCuenta = x.NumeroCuenta,
                    TipoCuenta = x.TipoCuenta,
                    SaldoIncial = x.SaldoIncial,
                    Estado = x.Estado
                }).ToList();
        }

        public async Task<ICollection<DtoCuentaResponse>> ListClienteAsync(int id)
        {
            var collection = await _repository.ListCollectionClienteAsync(id);

            return collection.Select(x => new DtoCuentaResponse
            {
                CuentaId = x.CuentaId,
                ClienteId = x.ClienteId,
                NumeroCuenta = x.NumeroCuenta,
                TipoCuenta = x.TipoCuenta,
                SaldoIncial = x.SaldoIncial,
                Estado = x.Estado
            }).ToList();
        }

        public async Task<DtoCuentaResponse> GetByIdAsync(int id)
        {
            var cuenta = await _repository.GetAsync(id);

            if (cuenta == null)
                return null;

            return new DtoCuentaResponse
            {
                CuentaId = cuenta.CuentaId,
                ClienteId = cuenta.ClienteId,
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoIncial = cuenta.SaldoIncial,
                Estado = cuenta.Estado
            };
        }

        public async Task<int> CreateAsync(DtoCuentaRequest request)
        {
            return await _repository.CreateAsync(new Cuenta
            {
                ClienteId = request.ClienteId,
                NumeroCuenta = request.NumeroCuenta,
                TipoCuenta = request.TipoCuenta,
                SaldoIncial = request.SaldoIncial,
                Estado = request.Estado
            });
        }

        public async Task<int> UpdateAsync(int id, DtoCuentaRequest request)
        {
            return await _repository.UpdateAsync(new Cuenta
            {
                CuentaId = id,
                ClienteId = request.ClienteId,
                NumeroCuenta = request.NumeroCuenta,
                TipoCuenta = request.TipoCuenta,
                SaldoIncial = request.SaldoIncial,
                Estado = request.Estado
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
