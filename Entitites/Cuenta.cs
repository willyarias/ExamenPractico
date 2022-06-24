using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuentaId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

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
