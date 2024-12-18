using flashcardAPI.Models;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;

namespace flashcardsAPI.Interfaces
{
    public interface InterfaceRepositoryFlashCard
    {
        public List<FlashCard> AllFlashCards();
        public FlashCard FindByIdFlashCard(int id);
        public List<FlashCard> FindByNameFlashCards(string name);
        public FlashCard AddFlashCard(RequestFlashCard flashcard);
        public FlashCard EditFlashCard(int id, RequestFlashCard flashcard);
        public FlashCard DeleteFlashCard(int id);
        public FlashCard AddTeste(FlashCard flashCard, Flash flash, Card card);
    }
}
