using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using Demo1Api.Models;
using Demo1Api.Interfaces;
using System.Transactions;

using Microsoft.EntityFrameworkCore;

using Demo1Api.Entidades;

namespace Demo1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IData _IData;
        public List<Registrado> ListRegistrado;

        public ClientesController(IData IData)
        {
            _IData = IData;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IData.ListRegistrado);
        }

        // GET api/<ClientesController>/0919172551
        [HttpGet("{Identificacion}", Name ="Get")]
        public IActionResult Get(string Identificacion)
        {
            return Ok(_IData.DatosRegistrado(Identificacion));
        }

        // GET api/<ClientesController>/5/0919172551
        [HttpGet("{Id}/{Identificacion}", Name = "Get2")]
        public IActionResult Get2(int Id, string Identificacion)
        {
            Id = 0;
            return Ok(_IData.DatosRegistrado(Identificacion));
        }

        // GET api/<ClientesController>/RegistradoDatos/5/0919172551
        [HttpGet("RegistradoDatos/{Id}/{Identificacion}", Name = "Get3")]
        public IActionResult Get3(int Id, string Identificacion)
        {
            Id = 0;
            return Ok(_IData.DatosRegistrado(Identificacion));
        }

        // GET: api/<ClientesController>/EmpresasRegistrados
        [HttpGet]
        [Route("EmpresasRegistrados")]
        public IActionResult GetEmpresasRegistrados()
        {
            return Ok(_IData.DatosRegistradosEmpresas);
        }


        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Registrado NewItem)
        {
            try
            {

                if (NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error");
                }

                //coloca el DA

                _IData.InsertRegistrado(NewItem);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(NewItem);

        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Registrado Item)
        {

            try
            {
                ListRegistrado = new List<Registrado>();

                if (Item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error");
                }

                ListRegistrado = _IData.ItemExists(Item.IdRegistrado);

                if(ListRegistrado.Count == 0)
                {
                    return NotFound("No exkiste");
                }

                _IData.UpdateRegistrado(Item);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();

        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{IdRegistrado}")]
        public IActionResult Delete(int IdRegistrado)
        {
            try
            {
                ListRegistrado = new List<Registrado>();

                ListRegistrado = _IData.ItemExists(IdRegistrado);

                if (ListRegistrado.Count == 0)
                {
                    return NotFound("No exkiste");
                }

                using (TransactionScope trans = new TransactionScope() )
                {
                    _IData.DeleteRegistrado(IdRegistrado);
                    trans.Complete();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();

        }
    }
}
