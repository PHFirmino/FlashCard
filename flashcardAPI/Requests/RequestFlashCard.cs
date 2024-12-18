using flashcardAPI.Models;

namespace flashcardsAPI.Requests
{
    public class RequestFlashCard
    {
        public string Nome { get; set; }
        public int Flash { get; set; }
        public List<int> Card { get; set; }
        public int FlashCard { get; set; }
    }
}
