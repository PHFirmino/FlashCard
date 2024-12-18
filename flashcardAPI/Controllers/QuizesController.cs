using flashcardsAPI.Interfaces;
using flashcardsAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace flashcardsAPI.Controllers
{
    public class QuizesController : Controller
    {
        private readonly InterfaceServiceQuiz _interfaceServiceQuiz;
        public QuizesController(InterfaceServiceQuiz interfaceServiceQuiz)
        {
            _interfaceServiceQuiz = interfaceServiceQuiz;
        }
        [HttpGet("/quiz")]
        public IActionResult Quizes([FromQuery] int idFlashCard, [FromQuery] int idTeste = 0)
        {
            var quiz = _interfaceServiceQuiz.Quiz(idFlashCard, idTeste);

            return Ok(quiz);
        }
        [HttpPost("/finalizar")]
        public IActionResult QuizesFinalizar([FromBody] RequestQuiz requestQuiz)
        {
            var quiz = _interfaceServiceQuiz.QuizFinalizar(requestQuiz);

            return Ok(quiz);
        }
    }
}
