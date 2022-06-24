using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class DtoMovimientoRequest
    {
        [Required]
        public int CuentaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
        public bool TipoMovimiento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public decimal Saldo { get; set; }
    }
}
