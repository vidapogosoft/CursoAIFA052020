using System;
using System.Collections.Generic;

#nullable disable

namespace Demo1Api.Models
{
    public partial class EmpresaRegistrado
    {
        public int IdEmpresaRegistrado { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdRegistrado { get; set; }
        public string Estado { get; set; }
    }
}
