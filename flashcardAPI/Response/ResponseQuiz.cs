using flashcardsAPI.Models;

namespace flashcardsAPI.Response
{
    public class ResponseQuiz()
    {
        public Teste posicaoAnterior {  get; set; }
        public Teste posicaoEstouIndo { get; set; }
        public Teste posicaoSeguinte { get; set; }
        public int posicao {  get; set; }
        public int quantidade { get; set; }
    }
}
