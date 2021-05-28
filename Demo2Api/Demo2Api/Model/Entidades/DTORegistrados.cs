using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Demo2Api.Model.Entidades
{
    public class DTORegistrados
    {
        [Key]
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

    }
}
