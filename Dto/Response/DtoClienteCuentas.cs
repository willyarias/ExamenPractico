using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class DtoClienteCuentas
    {
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }

        public string TipoCuenta { get; set; }

        public decimal SaldoIncial { get; set; }
        public bool Estado { get; set; }
    }
}
