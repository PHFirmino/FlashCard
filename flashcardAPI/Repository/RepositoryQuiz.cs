using flashcardAPI.Data;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Migrations;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;
using Microsoft.EntityFrameworkCore;

namespace flashcardsAPI.Repository
{
    public class RepositoryQuiz : InterfaceRepositoryQuiz
    {
        private readonly DataContext _dataContext;
        public RepositoryQuiz(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Models.Quiz QuizFinalizar(FlashCard flashCard, int acertos, int erros, int naoRespondidas, decimal nota)
        {
            var quizFinalizar = new Models.Quiz();
            quizFinalizar.FlashCard = flashCard;
            quizFinalizar.Acertos = acertos;
            quizFinalizar.Erros = erros;
            quizFinalizar.NaoRespondidas = naoRespondidas;
            quizFinalizar.Nota = nota;

            _dataContext.Quiz.Add(quizFinalizar);
            _dataContext.SaveChanges();
          
            return quizFinalizar;
        }
        public List<Teste> ListaQuiz(int id)
        {
            var testes = _dataContext.Teste.Include(x => x.FlashCard).Include(x => x.Flash.User).Include(x => x.Card).Where(x => x.FlashCard.Id == id).ToList();

            return testes;
        }
        public Teste EstouIndoUm(int id)
        {
            var estouIndoUm = _dataContext.Teste.Include(x => x.FlashCard).Include(x => x.Flash.User).Include(x => x.Card).FirstOrDefault(x => x.FlashCard.Id == id);

            return estouIndoUm;
        }
        public Teste EstouIndoDois(int id)
        {
            var estouIndoDois = _dataContext.Teste.Include(x => x.FlashCard).Include(x => x.Flash.User).Include(x => x.Card).FirstOrDefault(x => x.Id == id);

            return estouIndoDois;
        }
        public Teste Ultimo(int id)
        {
            var ultimo = _dataContext.Teste.Where(x => x.FlashCard.Id == id).OrderByDescending(x => x.Id).FirstOrDefault();

            return ultimo;
        }
    }
}
