using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : ControllerBase
    {
        private readonly InterfaceServiceTeste _interfaceServiceTeste;
        public TestesController(InterfaceServiceTeste interfaceServiceTeste)
        {
            _interfaceServiceTeste = interfaceServiceTeste;
        }


        [HttpGet("/alltestes")]
        public IActionResult AllTestes()
        {
            var testes = _interfaceServiceTeste.AllTeste();

            return Ok(testes);
        }
        [HttpGet("/findbyidteste/{id}")]
        public IActionResult FindByIdTeste([FromRoute] int id)
        {
            return Ok();
        }
        [HttpGet("/findbynametestes")]
        public IActionResult FindByNameTestes([FromQuery] string name)
        {
            var testes = _interfaceServiceTeste.FindByIdName(name);
            return Ok(testes);
        }
        [HttpPost("/addteste")]
        public IActionResult AddTeste(RequestTeste teste)
        {
            return Ok();
        }
        [HttpPut("/editteste/{id}")]
        public IActionResult EditTeste([FromRoute] int id, [FromBody] RequestTeste teste)
        {
            return Ok();
        }
        [HttpDelete("/deleteteste/{id}")]
        public IActionResult DeleteTeste([FromRoute] int id)
        {
            var testeExcluido = _interfaceServiceTeste.DeleteTeste(id);
            try
            {
                return Ok(testeExcluido);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
