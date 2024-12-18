using flashcardAPI.Models;
using flashcardsAPI.Models;

namespace flashcardsAPI.Response
{
    public class ResponseFlashCard
    {
        public int IdTeste { get; set; }
        public Flash Flash { get; set; }
        public FlashCard FlashCard { get; set; }
        public List<Card> Card {  get; set; } 
    }
}
