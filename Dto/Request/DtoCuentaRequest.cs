using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class DtoCuentaRequest
    {
        [Required]
        public int ClienteId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string NumeroCuenta { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoCuenta { get; set; }

        [Required]
        public decimal SaldoIncial { get; set; }
        public bool Estado { get; set; }
    }
}
