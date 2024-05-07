using Iguana.Application.Contracts;
using Iguana.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iguana.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = await _user.GetUsers();
            if(res != null) 
            { 
                return StatusCode(200, new {users = res }); 
            } 
            else 
            { 
                return StatusCode(404, new { msg = "Puede que este usuario ya este registrado" }); 
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserDTO user)
        {
            var response = await _user.postUser(user);
            if(response)
            {
                return StatusCode(200, new { msg = "Usuario creado con exito" });
            }
            else
            {
                return StatusCode(404, new { msg = "Puede que este usuario ya este registrado" });
            }
        }

        [HttpPut("{userID:int}")]
        public async Task<ActionResult> Put([FromBody] UserDTO userObj, int userID)
        {
            var res = await _user.putUser(userObj, userID);
            if(res)
            {
                return StatusCode(200, new { msg = "Usuario actualizado con exito" });
            }
            else
            {
                return StatusCode(404, new { msg = "Asegurate de ingresar los datos correctamente" });
            }
        }

        [HttpDelete("{idUser:int}")]
        public async Task<ActionResult> Delete(int idUser)
        {
            var res = await _user.deleteUser(idUser);
            if (res)
            {
                return StatusCode(200, new { msg = "Registro eliminado" });
            }
            else
            {
                return StatusCode(404, new { msg = "Algo sucedio, intente nuevamente" });
            }
        }
    }
}
