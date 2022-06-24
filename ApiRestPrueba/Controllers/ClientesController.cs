using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiRestPrueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController :ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoClienteRequest request)
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
        public async Task<IActionResult> Put(int id, DtoClienteRequest request)
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

        [HttpGet]
        [Route("{id:int}/Cuentas")]
        public async Task<IActionResult> GetCuentas(int id)
        {
            return Ok(await _service.GetCuentasAsync(id));
        }
    }
}
