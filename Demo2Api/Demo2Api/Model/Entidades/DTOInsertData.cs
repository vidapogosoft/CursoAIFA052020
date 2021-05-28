using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Demo2Api.Model.Entidades
{
    public class DTOInsertData
    {
        [Key]
        public int Id { get; set; }
        public string Mensaje { get; set; }
    }
}
