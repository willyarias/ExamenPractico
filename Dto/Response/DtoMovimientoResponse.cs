using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class DtoMovimientoResponse
    {
        public int MovimientoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }

        public bool TipoMovimiento { get; set; }

        public decimal Valor { get; set; }
        
        public decimal Saldo { get; set; }
    }
}
