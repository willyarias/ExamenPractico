using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Request;
using Services;

namespace ApiRestPrueba.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _service;
        public MovimientosController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetByIdAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet]
        [Route("Cuenta/{id:int}")]

        public async Task<IActionResult> GetCliente(int id)
        {
            return Ok(await _service.ListCuentaAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoMovimientoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.CreateAsync(request);
            var msj = "Registrado Exitosamente";
            if(response == -1)
            {
                msj = "Saldo No Disponible";
            } else
            {
                if(response == -2)
                {
                    msj = "Cupo diario excedido";
                }
            }
            

            return Created($"/{response}", new
            {
                Id = response,
                Mensaje = msj
            });
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, DtoMovimientoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.UpdateAsync(id, request);

            return Accepted(new
            {
                Id = response
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Accepted(new
            {
                Id = id
            });
        }
    }
}
