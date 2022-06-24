using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class DtoClienteRequest
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Genero { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Identificacion { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Contraseña { get; set; }

        public bool Estado { get; set; }
    }
}
