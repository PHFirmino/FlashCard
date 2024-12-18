using flashcardAPI.Interfaces;
using flashcardAPI.Models;

namespace flashcardAPI.Services
{
    public class ServiceCard : InterfaceServiceCard
    {
        private readonly InterfaceRepositoryCard _repositoryCard;
        public ServiceCard(InterfaceRepositoryCard interfaceRepositoryCard)
        {
            _repositoryCard = interfaceRepositoryCard;
        }
        public List<Card> AllCards()
        {
            return _repositoryCard.AllCards();
        }
        public Card FindByIdCards(int id)
        {
            return _repositoryCard.FindByIdCards(id);
        }
        public List<Card> FindByQuestionCard(string question)
        {
            var cards = _repositoryCard.FindByQuestionCard(question);

            return cards;

        }
        public Card AddCard(Card card)
        {
            var cardAdicionado = _repositoryCard.AddCard(card);

            return cardAdicionado;
        }

        public Card DeleteCard(int id)
        {
            var cardExcluido = _repositoryCard.DeleteCard(id);

            return cardExcluido;
        }

        public Card EditCard(int id, Card card)
        {
            var cardEditado = _repositoryCard.EditCard(id, card);

            return cardEditado;
        }
    }
}
