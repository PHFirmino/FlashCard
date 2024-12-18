using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InterfaceServiceUser _interfaceServiceUser;
        public UsersController(InterfaceServiceUser interfaceServiceUser) 
        {
            _interfaceServiceUser = interfaceServiceUser;
        }
        [HttpGet("/allUsers")]
        public IActionResult AllUsers()
        {
            try
            {
                var users = _interfaceServiceUser.AllUsers();

                return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/adduser")]
        public IActionResult Adduser([FromBody] User user)
        {
            try
            {
                var userAdicionado = _interfaceServiceUser.AddUser(user);
                return Ok(userAdicionado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/edituser/{id}")]
        public IActionResult Edituser([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                var userEditado = _interfaceServiceUser.EditUser(id, user);
                return Ok(userEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
