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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoClienteResponse>> ListAsync()
        {
            var collection = await _repository.ListCollectionAsync();

            return collection.Select(x => new DtoClienteResponse
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Genero = x.Genero,
                Edad = x.Edad,
                Identificacion = x.Identificacion,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Contraseña = x.Contraseña,
                Estado = x.Estado
            })
            .ToList();
        }
        public async Task<DtoClienteResponse> GetByIdAsync(int id)
        {
            var cliente = await _repository.GetAsync(id);

            if (cliente == null)
                return null;

            return new DtoClienteResponse
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Contraseña = cliente.Contraseña,
                Estado = cliente.Estado
            };
        }

        public async Task<int> CreateAsync(DtoClienteRequest request)
        {
            return await _repository.CreateAsync(new Cliente
            {
                Nombre = request.Nombre,
                Genero = request.Genero,
                Edad = request.Edad,
                Identificacion = request.Identificacion,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Contraseña = request.Contraseña,
                Estado = request.Estado
            });
        }

        public async Task<int> UpdateAsync(int id, DtoClienteRequest request)
        {
            return await _repository.UpdateAsync(new Cliente
            {
                Id = id,
                Nombre = request.Nombre,
                Genero = request.Genero,
                Edad = request.Edad,
                Identificacion = request.Identificacion,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Contraseña = request.Contraseña,
                Estado = request.Estado
            });
        }

        public async  Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async  Task<ICollection<DtoClienteCuentas>> GetCuentasAsync(int id)
        {
            var collection = await _repository.ListCuentas(id);
            var cliente = await _repository.GetAsync(id);

            if (cliente == null)
                return null;


            return collection.Select(p => new DtoClienteCuentas
            {
                Cliente = cliente.Nombre,
                NumeroCuenta = p.NumeroCuenta,
                TipoCuenta = p.TipoCuenta,
                SaldoIncial = p.SaldoIncial,
                Estado = p.Estado
            })
            .ToList();
        }

        
    }
}
