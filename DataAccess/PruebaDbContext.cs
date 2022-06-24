using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext()
        {

        }

        public PruebaDbContext(DbContextOptions<PruebaDbContext> options)
            : base(options)
        {

        }
        /*
        public DbSet<Persona> Personas { get; set; }
        */
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

    }
}
