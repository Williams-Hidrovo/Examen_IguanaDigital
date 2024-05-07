using Iguana.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iguana.Api.Controllers
{
    [Route("api/cargo")]
    [ApiController]

    public class CargosController : Controller
    {
        private readonly ICargo _cargo;
        
        public CargosController(ICargo cargo)
        {
            _cargo = cargo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = await _cargo.GetCargos();
            if (res == null) 
            { 
                return StatusCode(404, new { msg = "No hay cargos registrados" }); 
            } 
            else 
            { 
                return StatusCode(200, new { msg = "Lista de cargos actualizada.", arrayCargos = res }); 
            }
        }
    }
}
