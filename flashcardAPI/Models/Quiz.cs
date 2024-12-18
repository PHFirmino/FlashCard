namespace flashcardsAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public FlashCard FlashCard { get; set; }
        public int Acertos { get; set; }
        public int Erros {  get; set; }
        public int NaoRespondidas {  get; set; }
        public decimal Nota { get; set; }

    }
}
