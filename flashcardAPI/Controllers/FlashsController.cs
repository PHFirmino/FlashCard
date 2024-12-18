using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using flashcardsAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashsController : ControllerBase
    {
        private readonly InterfaceServiceFlash _interfaceServiceFlash;

        public FlashsController(InterfaceServiceFlash interfaceServiceFlash)
        {
            _interfaceServiceFlash = interfaceServiceFlash;
        }

        [HttpGet("/allflashs")]
        public IActionResult AllFlashs() 
        {
            try
            {
                var flashs = _interfaceServiceFlash.AllFlashs();

                return Ok(flashs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/findbyidflash/{id}")]
        public IActionResult Findbyidflash([FromRoute] int id)
        {
            try
            {
                var flash = _interfaceServiceFlash.FindByIdFlash(id);

                return Ok(flash);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/findbynameflash")]
        public IActionResult Findbynameflash([FromQuery] string name)
        {
            try
            {
                var flashs = _interfaceServiceFlash.FindByNameFlashs(name);

                return Ok(flashs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("/addflash")]
        public IActionResult Addflash([FromBody] RequestFlash flash)
        {
            try
            {
                var flashAdicionado = _interfaceServiceFlash.AddFlash(flash);

                return Ok(flashAdicionado);
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/editflash/{id}")]
        public IActionResult Editflash([FromRoute] int id, [FromBody] RequestFlash flash)
        {
            try
            {
                var flashEditado = _interfaceServiceFlash.EditFlash(id, flash);

                return Ok(flashEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/deleteflash/{id}")]
        public IActionResult Deleteflash([FromRoute] int id)
        {
            try
            {
                var flashExcluido = _interfaceServiceFlash.DeleteFlash(id);

                return Ok(flashExcluido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
