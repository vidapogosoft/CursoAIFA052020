using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Demo2Api.Interfaces;
using Demo2Api.Model.Entidades;
using Demo2Api.Model;

namespace Demo2Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IData _IData;
        public List<DTORegistrados> ListRegistrado;

        public VentasController(IData IData)
        {
            _IData = IData;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IData.ListRegistrado);
        }


        // GET api/<VentasController>/5
        [HttpGet("{Identificacion}", Name = "GetDatos")]
        public IActionResult GetDatos(string Identificacion)
        {
            return Ok(_IData.DatosRegistrado(Identificacion));
        }

        // POST api/<VentasController>
        [HttpPost]
        public IActionResult Post([FromBody] Registrado NewItem)
        {
            return Ok(

            _IData.InsertRegistrado1(NewItem)

            ) ;

        }

        [HttpPost]
        [Route("Registrados2")]
        public IActionResult Post2([FromBody] Registrado NewItem)
        {
            _IData.InsertRegistrado1(NewItem);

            return Ok(NewItem);

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
