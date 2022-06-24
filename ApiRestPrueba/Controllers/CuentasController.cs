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
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _service;
        public CuentasController(ICuentaService service)
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
        [Route("Cliente/{id:int}")]

        public async Task<IActionResult> GetCliente(int id)
        {
            return Ok(await _service.ListClienteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoCuentaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.CreateAsync(request);

            return Created($"/{response}", new
            {
                Id = response
            });
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, DtoCuentaRequest request)
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
