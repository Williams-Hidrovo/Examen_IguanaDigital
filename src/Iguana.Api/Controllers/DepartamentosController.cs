using Iguana.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Iguana.Api.Controllers
{
    [Route("api/departamentos")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private readonly IDepartamento _departamento;

        public DepartamentosController(IDepartamento departamento)
        {
            _departamento = departamento;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = await _departamento.GetDepartamentos();
            if (res == null)
            {
                return StatusCode(404, new { msg = "Sin departamentos registrados" });
            }
            else
            {
                return StatusCode(200, new { msg = "Lista de departamentos actualizada", arrayCargos = res });
            }
        }
    }
}
