using flashcardAPI.Data;
using flashcardAPI.Interfaces;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;

namespace flashcardsAPI.Services
{
    public class ServiceFlashCard : InterfaceServiceFlashCard
    {
        private readonly InterfaceRepositoryFlashCard _interfaceRepositoryFlashCard;
        private readonly InterfaceServiceFlash _interfaceServiceFlash;
        private readonly InterfaceServiceCard _interfaceServiceCard;
        private readonly InterfaceServiceTeste _interfaceServiceTeste;
        public ServiceFlashCard(InterfaceRepositoryFlashCard interfaceRepositoryFlashCard, InterfaceServiceFlash interfaceServiceFlash, InterfaceServiceCard interfaceServiceCard, InterfaceServiceTeste interfaceServiceTeste)
        {
            _interfaceRepositoryFlashCard = interfaceRepositoryFlashCard;
            _interfaceServiceFlash = interfaceServiceFlash;
            _interfaceServiceCard = interfaceServiceCard;
            _interfaceServiceTeste = interfaceServiceTeste;
        }

        public List<FlashCard> AllFlashCards()
        {
            var flashcards = _interfaceRepositoryFlashCard.AllFlashCards();

            return flashcards;
        }
        public FlashCard FindByIdFlashCard(int id)
        {
            var flashcard = _interfaceRepositoryFlashCard.FindByIdFlashCard(id);

            return flashcard;
        }
        public List<FlashCard> FindByNameFlashCards(string name)
        {
            var flashcards = _interfaceRepositoryFlashCard.FindByNameFlashCards(name);

            return flashcards;
        }
        public FlashCard AddFlashCard(RequestFlashCard flashcard)
        {
            var flashCardAdd = _interfaceRepositoryFlashCard.AddFlashCard(flashcard);
            var flash = _interfaceServiceFlash.FindByIdFlash(flashcard.Flash);

            foreach (var id in flashcard.Card)
            {
                var card = _interfaceServiceCard.FindByIdCards(id);
                _interfaceRepositoryFlashCard.AddTeste(flashCardAdd, flash, card);
            }

            return flashCardAdd;
        }
        public FlashCard EditFlashCard(int id, RequestFlashCard flashCard)
        {
            var flashcardEditado = _interfaceRepositoryFlashCard.EditFlashCard(id, flashCard);

            var flash = _interfaceServiceFlash.FindByIdFlash(flashCard.Flash);
            var testeExcluido = _interfaceServiceTeste.FindByIdFlashCard(flashcardEditado.Id);

            foreach (var item in testeExcluido)
            {
                _interfaceServiceTeste.DeleteByIdTeste(item.Id);
            }

            foreach (var idCard in flashCard.Card)
            {
                var card = _interfaceServiceCard.FindByIdCards(idCard);
                _interfaceRepositoryFlashCard.AddTeste(flashcardEditado, flash, card);
            }

            return flashcardEditado;
        }
        public FlashCard DeleteFlashCard(int id)
        {
            var flashcardExcluido = _interfaceRepositoryFlashCard.DeleteFlashCard(id);

            return flashcardExcluido;
        }
    }
}
