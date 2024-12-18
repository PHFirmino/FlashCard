using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Interfaces
{
    public interface InterfaceServiceTeste
    {
        public List<ResponseFlashCard> AllTeste();
        public Teste FindByIdTeste(int id);
        public List<ResponseFlashCard> FindByIdName(string name);
        public List<Teste> FindByIdFlashCard(int id);
        public Teste AddTeste(RequestTeste requestTeste);
        public List<Teste> DeleteTeste(int id);
        public Teste DeleteByIdTeste(int id);
        public FlashCard DeleteByIdFlashCardTeste(int id);
        public Teste EditTeste(int id, RequestTeste requestTeste);
        public int QntTesteFlashCard(int qnt);
    }
}
