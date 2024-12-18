using flashcardsAPI.Interfaces;
using flashcardsAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardsController : ControllerBase
    {
        private readonly InterfaceServiceFlashCard _interfaceServiceFlashCard;
        public FlashCardsController(InterfaceServiceFlashCard interfaceServiceFlashCard)
        {
            _interfaceServiceFlashCard = interfaceServiceFlashCard;
        }

        [HttpGet("/allflashcards")]
        public IActionResult AllFlashCards()
        {
            try
            {
                var flashCards = _interfaceServiceFlashCard.AllFlashCards();

                return Ok(flashCards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/findbyidflashcard/{id}")]
        public IActionResult FindByIdFlashCard([FromRoute] int id)
        {
            try
            {
                var flashCard = _interfaceServiceFlashCard.FindByIdFlashCard(id);

                return Ok(flashCard);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/findbynameflashcards")]
        public IActionResult FindByNameFlashCards([FromQuery] string name)
        {
            try
            {
                var flashCards = _interfaceServiceFlashCard.FindByNameFlashCards(name);

                return Ok(flashCards);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("/addflashcard")]
        public IActionResult AddFlashCard([FromBody] RequestFlashCard flashCard)
        {
            try
            {
                var flashCardAdd = _interfaceServiceFlashCard.AddFlashCard(flashCard);

                return Ok(flashCardAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/editflashcard/{id}")]
        public IActionResult EditFlashCard([FromRoute] int id,[FromBody] RequestFlashCard flashCard)
        {
            try
            {
                var flashCardEditado = _interfaceServiceFlashCard.EditFlashCard(id, flashCard);

                return Ok(flashCardEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/deleteflashcard/{id}")]
        public IActionResult DeleteFlashCard([FromRoute] int id)
        {
            try
            {
                var flashCardExcluido = _interfaceServiceFlashCard.DeleteFlashCard(id);

                return Ok(flashCardExcluido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
