using flashcardAPI.Models;

namespace flashcardAPI.Interfaces
{
    public interface InterfaceRepositoryCard
    {
        public List<Card> AllCards();
        public Card FindByIdCards(int id);
        public List<Card> FindByQuestionCard(string question);
        public Card AddCard(Card card);
        public Card EditCard(int id, Card card);
        public Card DeleteCard(int id);
    }
}
