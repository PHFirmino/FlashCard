using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Interfaces
{
    public interface InterfaceRepositoryQuiz
    {
        public List<Teste> ListaQuiz(int id);
        public Teste EstouIndoUm(int id);
        public Teste EstouIndoDois(int id);
        public Teste Ultimo(int id);
        public Quiz QuizFinalizar(FlashCard flashCard, int acertos, int erros, int naoRespondidas, decimal nota);
    }
}
