using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Demo1Api.Models;
using Demo1Api.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo1Api.Controllers.Ventas
{
    [Route("api/Ventas/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private readonly DBRegistradosContext _context;

        public VentasController(DBRegistradosContext context)
        {
            _context = context;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public async Task<IEnumerable<DTORegistrados>> Get()
        {
            return await _context.DTORegister.FromSqlRaw("ConsRegistrados")
                .ToListAsync();
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
