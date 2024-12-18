using flashcardAPI.Models;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Interfaces
{
    public interface InterfaceRepositoryTeste
    {
        public List<Teste> AllTeste();
        public Teste FindByIdTeste(int id);
        public List<Teste> FindByIdName(string name);
        public List<Teste> FindByIdFlashCard(int id);
        public Teste AddTeste(RequestTeste requestTeste);
        public List<Teste> DeleteTeste(int id);
        public Teste EditTeste(int id, RequestTeste requestTeste);
        public Teste DeleteByIdTeste(int id);
        public FlashCard DeleteByIdFlashCardTeste(int id);
        public List<Card> Cards(Teste item);
        public int QntTesteFlashCard(int id);

    }
}
