using flashcardAPI.Data;
using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using Microsoft.EntityFrameworkCore;
using DataContext = flashcardAPI.Data.DataContext;

namespace flashcardAPI.Repository
{
    public class RepositoryCard : InterfaceRepositoryCard
    {
        private readonly DataContext _dataContext;
        public RepositoryCard(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }
        public List<Card> AllCards()
        {
            return _dataContext.Card.ToList();
        }
        public Card FindByIdCards(int id)
        {
            var card = _dataContext.Card.FirstOrDefault(x => x.Id == id);
            return card;
        }
        public List<Card> FindByQuestionCard(string question)
        {
            var cards = _dataContext.Card.Where(x => x.Pergunta.ToUpper().Contains(question.ToUpper())).ToList();
            return cards;
        }
        public Card AddCard(Card card)
        {
            _dataContext.Card.Add(card);
            _dataContext.SaveChanges();

            return card; 
        }

        public Card DeleteCard(int id)
        {
            var cardExcluido = _dataContext.Card.FirstOrDefault(x => x.Id == id);

            _dataContext.Remove(cardExcluido);
            _dataContext.SaveChanges();

            return cardExcluido;
        }

        public Card EditCard(int id, Card card)
        {
            var cardEditado = _dataContext.Card.FirstOrDefault(x => x.Id == id);
            cardEditado.Pergunta = card.Pergunta;
            cardEditado.Resposta = card.Resposta;

            _dataContext.SaveChanges();

            return cardEditado;
        }
    }
}
