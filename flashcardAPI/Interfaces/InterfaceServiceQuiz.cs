using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Interfaces
{
    public interface InterfaceServiceQuiz
    {
        public ResponseQuiz Quiz(int idFlashCard, int idTeste);
        public Quiz QuizFinalizar(RequestQuiz requestQuiz);
    }
}
