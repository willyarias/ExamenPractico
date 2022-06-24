﻿using System;

namespace Dto.Response
{
    public class DtoClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; }

        public string Identificacion { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
    }
}
