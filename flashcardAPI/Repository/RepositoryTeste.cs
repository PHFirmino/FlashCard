using flashcardAPI.Data;
using flashcardAPI.Models;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;
using Microsoft.EntityFrameworkCore;

namespace flashcardsAPI.Repository
{
    public class RepositoryTeste : InterfaceRepositoryTeste
    {
        private readonly DataContext _dataContext;

        public RepositoryTeste(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Teste> AllTeste()
        {

            var testes = _dataContext.Teste.Include(x => x.FlashCard).Include(x => x.Flash.User).Include(x => x.Card).ToList();

            return testes;
        }
        public Teste FindByIdTeste(int id)
        {
            var teste = _dataContext.Teste.Include(x => x.Flash).Include(x => x.Card).FirstOrDefault(x => x.Id == id);

            return teste;
        }
        public List<Teste> FindByIdName(string name)
        {
            var testes = _dataContext.Teste.Include(x => x.FlashCard).Include(x => x.Flash.User).Include(x => x.Card).Where(x => x.FlashCard.Nome.ToUpper().Contains(name.ToUpper())).ToList();

            return testes;
        }
        public List<Teste> FindByIdFlashCard(int id)
        {
            var testes = _dataContext.Teste.Where(x => x.FlashCard.Id == id).ToList();

            return testes;
        }

        public Teste AddTeste(RequestTeste requestTeste)
        {
            return new Teste();
        }

        public Teste EditTeste(int id, RequestTeste requestTeste)
        {
            throw new NotImplementedException();
        }
        public List<Teste> DeleteTeste(int id)
        {
            try
            {
                var testeExcluido = _dataContext.Teste.Where(x => x.FlashCard.Id == id).ToList();
                foreach (var item in testeExcluido)
                {
                    _dataContext.Teste.Remove(item);
                }

                var flashExcluido = _dataContext.FlashCards.FirstOrDefault(x => x.Id == id);
                _dataContext.FlashCards.Remove(flashExcluido);

                _dataContext.SaveChanges();

                return testeExcluido;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Teste DeleteByIdTeste(int id)
        {
            var testeExcluido = _dataContext.Teste.FirstOrDefault(x => x.Id == id);
            _dataContext.Teste.Remove(testeExcluido);

            _dataContext.SaveChanges();

            return testeExcluido;
        }
        public FlashCard DeleteByIdFlashCardTeste(int id)
        {
            var flashCardExcluido = _dataContext.FlashCards.FirstOrDefault(x => x.Id == id);
            _dataContext.FlashCards.Remove(flashCardExcluido);

            _dataContext.SaveChanges();

            return flashCardExcluido;
        }

        public List<Card> Cards(Teste item)
        {
            var cards = _dataContext.Teste.Where(x => x.FlashCard == item.FlashCard).Select(x => new Card()
            {
                Id = x.Card.Id,
                Pergunta = x.Card.Pergunta,
                Resposta = x.Card.Resposta

            }).ToList();

            return cards;
        }
        public int QntTesteFlashCard(int id)
        {
            var qntFlashCard = _dataContext.Teste.Where(x => x.FlashCard.Id == id).Count();

            return qntFlashCard;
        }
    }
}
