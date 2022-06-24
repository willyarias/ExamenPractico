using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Cliente : Persona
    {

        [Required]
        [StringLength(50)]
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
    }
}
