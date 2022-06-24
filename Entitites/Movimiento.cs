using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovimientoId { get; set; }
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
        public bool TipoMovimiento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public decimal Saldo { get; set; }
    }
}
