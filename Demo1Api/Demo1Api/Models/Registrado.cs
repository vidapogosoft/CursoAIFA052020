using System;
using System.Collections.Generic;

#nullable disable

namespace Demo1Api.Models
{
    public partial class Registrado
    {
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
    }
}
