using flashcardAPI.Data;
using flashcardAPI.Models;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Services
{
    public class ServiceTeste : InterfaceServiceTeste
    {
        private readonly InterfaceRepositoryTeste _interfacerepositoryTeste;
        public ServiceTeste(InterfaceRepositoryTeste interfaceRepositoryTeste)
        {
            _interfacerepositoryTeste = interfaceRepositoryTeste;
        }
        public List<ResponseFlashCard> AllTeste()
        {
            var listFlashCard = new List<ResponseFlashCard>();

            var testes = _interfacerepositoryTeste.AllTeste();

            foreach (var item in testes)
            {
                if (!listFlashCard.Exists(x => x.FlashCard.Id == item.FlashCard.Id))
                {
                    var flashCard = new ResponseFlashCard();
                    var listaCards = _interfacerepositoryTeste.Cards(item);

                    flashCard.IdTeste = item.Id;
                    flashCard.FlashCard = item.FlashCard;
                    flashCard.Flash = item.Flash;
                    flashCard.Card = listaCards;

                    listFlashCard.Add(flashCard);
                }
            }

            return listFlashCard;
        }
        public Teste FindByIdTeste(int id)
        {
            var teste = _interfacerepositoryTeste.FindByIdTeste(id);

            return teste;
        }
        public List<ResponseFlashCard> FindByIdName(string name)
        {
            var listFlashCard = new List<ResponseFlashCard>();

            var testes = _interfacerepositoryTeste.FindByIdName(name);

            foreach (var item in testes)
            {
                if (!listFlashCard.Exists(x => x.FlashCard.Id == item.FlashCard.Id))
                {
                    var flashCard = new ResponseFlashCard();
                    var listaCards = _interfacerepositoryTeste.Cards(item);

                    flashCard.IdTeste = item.Id;
                    flashCard.FlashCard = item.FlashCard;
                    flashCard.Flash = item.Flash;
                    flashCard.Card = listaCards;

                    listFlashCard.Add(flashCard);
                }
            }

            return listFlashCard;
        }
        public List<Teste> FindByIdFlashCard(int id)
        {
            var testes = _interfacerepositoryTeste.FindByIdFlashCard(id);

            return testes;
        }
        public Teste AddTeste(RequestTeste requestTeste)
        {
            var testeAdd = _interfacerepositoryTeste.AddTeste(requestTeste);

            return testeAdd;
        }
        public Teste EditTeste(int id, RequestTeste requestTeste)
        {
            var testeEditado = _interfacerepositoryTeste.EditTeste(id, requestTeste);

            return testeEditado;
        }
        public List<Teste> DeleteTeste(int id)
        {
            var testeExcluido = FindByIdFlashCard(id);

            foreach (var item in testeExcluido)
            {
                DeleteByIdTeste(item.Id);
            }

            DeleteByIdFlashCardTeste(id);
            
             return testeExcluido;
        }
        public Teste DeleteByIdTeste(int id)
        {
            var testeExcluido = _interfacerepositoryTeste.DeleteByIdTeste(id);

            return testeExcluido;
        }
        public FlashCard DeleteByIdFlashCardTeste(int id)
        {
            var flashCardExcluido = _interfacerepositoryTeste.DeleteByIdFlashCardTeste(id);

            return flashCardExcluido;
        }

        public int QntTesteFlashCard(int qnt)
        {
            var qntFlashCard = _interfacerepositoryTeste.QntTesteFlashCard(qnt);

            return qntFlashCard;
        }
    }
}
