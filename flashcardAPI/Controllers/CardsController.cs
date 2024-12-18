using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using flashcardAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  CardsController : ControllerBase
    {
        private readonly InterfaceServiceCard _serviceCard;
        public CardsController(InterfaceServiceCard interfaceServiceCard) 
        {
            _serviceCard = interfaceServiceCard;
        }

        [HttpGet("/allcards")]
        public IActionResult AllCards()
        {
            try
            {
                var cards = _serviceCard.AllCards();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/findbyidcard/{id}")]
        public IActionResult FindByIdCards([FromRoute] int id) 
        {
            try
            {
                var card = _serviceCard.FindByIdCards(id);
                
                if(card != null)
                {
                    return Ok(card);
                }

                return Ok("Nenhum card encontrado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/findbyquestioncard")]
        public IActionResult FindByQuestionCard([FromQuery] string question)
        {
            try
            {
                var cards = _serviceCard.FindByQuestionCard(question);

                if (cards.Count() != 0)
                {
                    return Ok(cards);
                }

                return Ok("Nenhum card encontrado");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("/addcard")]
        public IActionResult AddCard([FromBody] Card card)
        {
            try
            {
                var cardAdicionado = _serviceCard.AddCard(card);
                return Ok(cardAdicionado);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/editcard/{id}")]
        public IActionResult EditCard([FromRoute] int id, [FromBody] Card card)
        {
            try
            {
                var cardEditado = _serviceCard.EditCard(id, card);
                return Ok(cardEditado);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/deletecard/{id}")]
        public IActionResult DeleteCard([FromRoute] int id)
        {
            try
            {
                var cardExcluido = _serviceCard.DeleteCard(id);

                return Ok(cardExcluido);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
