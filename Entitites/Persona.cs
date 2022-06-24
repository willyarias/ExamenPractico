using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Persona 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
    }
}
