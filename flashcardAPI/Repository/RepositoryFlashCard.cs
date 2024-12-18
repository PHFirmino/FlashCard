using flashcardAPI.Data;
using flashcardAPI.Models;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using Microsoft.EntityFrameworkCore;

namespace flashcardsAPI.Repository
{
    public class RepositoryFlashCard : InterfaceRepositoryFlashCard
    {
        private readonly DataContext _dataContext;
        public RepositoryFlashCard(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<FlashCard> AllFlashCards()
        {
            var flashCards = _dataContext.FlashCards.OrderBy(x => x.Id).ToList();
            
            return flashCards;
        }
        public FlashCard FindByIdFlashCard(int id)
        {
            var flashCard = _dataContext.FlashCards.FirstOrDefault(x => x.Id == id);

            return flashCard;
        }
        public List<FlashCard> FindByNameFlashCards(string name)
        {
            var flashCards = _dataContext.FlashCards.Where(x => x.Nome.ToUpper().Contains(name.ToUpper())).OrderBy(x => x.Id).ToList();

            return flashCards;
        }
        public FlashCard AddFlashCard(RequestFlashCard flashCard)
        {
            var flashCardAdd = new FlashCard();
            flashCardAdd.Nome = flashCard.Nome;
            
            _dataContext.FlashCards.Add(flashCardAdd);
            _dataContext.SaveChanges();

            return flashCardAdd;
        }
        public FlashCard EditFlashCard(int id, RequestFlashCard flashCard)
        {
            var flashCardEditado = _dataContext.FlashCards.FirstOrDefault(x => x.Id == id);
            flashCardEditado.Nome = flashCard.Nome;

            _dataContext.SaveChanges();

            return flashCardEditado;
        }

        public FlashCard DeleteFlashCard(int id)
        {
            var flashcardExcluido = _dataContext.FlashCards.FirstOrDefault(x => x.Id == id);

            _dataContext.FlashCards.Remove(flashcardExcluido);
            _dataContext.SaveChanges();

            return flashcardExcluido;
        }
        public FlashCard AddTeste(FlashCard flashCard, Flash flash, Card card)
        {
            var flashCardAddFk = new Teste();
            flashCardAddFk.FlashCard = flashCard;
            flashCardAddFk.Flash = flash;
            flashCardAddFk.Card = card;

            _dataContext.Teste.Add(flashCardAddFk);
            _dataContext.SaveChanges();

            return flashCard;
        }
    }
}