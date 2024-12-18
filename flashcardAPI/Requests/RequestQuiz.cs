namespace flashcardsAPI.Requests
{
    public class RequestQuiz
    {
        public int IdFlashCard { get; set; }
        public int Acertos { get; set; }
        public int Erros { get; set; }
    }
}
