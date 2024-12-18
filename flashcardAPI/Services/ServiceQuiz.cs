using flashcardAPI.Data;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Models;
using flashcardsAPI.Requests;
using flashcardsAPI.Response;

namespace flashcardsAPI.Services
{
    public class ServiceQuiz : InterfaceServiceQuiz
    {
        private readonly InterfaceRepositoryQuiz _interfaceRepositoryQuiz;
        private readonly InterfaceServiceTeste _interfaceServiceTeste;
        private readonly InterfaceServiceFlashCard _interfaceServiceFlashCard;
        public ServiceQuiz(InterfaceRepositoryQuiz interfaceRepositoryQuiz, InterfaceServiceTeste interfaceServiceTeste, InterfaceServiceFlashCard interfaceServiceFlashCard)
        {
            _interfaceRepositoryQuiz = interfaceRepositoryQuiz;
            _interfaceServiceTeste = interfaceServiceTeste;
            _interfaceServiceFlashCard = interfaceServiceFlashCard;
        }

        public ResponseQuiz Quiz(int idFlashCard, int idTeste)
        {

            var posicaoAnteriorTeste = new Teste();
            var posicaoSeguinteTeste = new Teste();
            var testeEstouIndo = new Teste();

            List<Teste> listaQuiz = _interfaceRepositoryQuiz.ListaQuiz(idFlashCard);

            if (idTeste == 0)
            {
                testeEstouIndo = _interfaceRepositoryQuiz.EstouIndoUm(idFlashCard);
            }
            else
            {
                testeEstouIndo = _interfaceRepositoryQuiz.EstouIndoDois(idTeste);
            }

            var testeUltimo = _interfaceRepositoryQuiz.Ultimo(idFlashCard);

            var posicaoTeste = listaQuiz.IndexOf(testeEstouIndo);
            var posicaoUltimo = listaQuiz.IndexOf(testeUltimo);

            if (posicaoTeste != 0)
            {
                posicaoAnteriorTeste = listaQuiz[posicaoTeste - 1];
            }

            if (posicaoTeste != posicaoUltimo)
            {
                posicaoSeguinteTeste = listaQuiz[posicaoTeste + 1];
            }

            var quantidade = listaQuiz.Count();
            var posicao = posicaoTeste + 1;

            var quiz = new ResponseQuiz();
            quiz.posicaoAnterior = posicaoAnteriorTeste;
            quiz.posicaoEstouIndo = testeEstouIndo;
            quiz.posicaoSeguinte = posicaoSeguinteTeste;
            quiz.quantidade = quantidade;
            quiz.posicao = posicao;

            return quiz;
        }

        public Quiz QuizFinalizar(RequestQuiz requestQuiz)
        {
            var qntFlashCard = _interfaceServiceTeste.QntTesteFlashCard(requestQuiz.IdFlashCard);
            var flashCard = _interfaceServiceFlashCard.FindByIdFlashCard(requestQuiz.IdFlashCard);

            decimal nota = (10m / qntFlashCard) * requestQuiz.Acertos;

            var qntAcertos = 0;
            var qntErros = 0;
            var qntNaoRespondidas = 0;

            if (requestQuiz.Acertos > 0)
            {
                qntFlashCard = qntFlashCard - requestQuiz.Acertos;
                qntAcertos = requestQuiz.Acertos;

            }

            if(requestQuiz.Erros > 0)
            {
                qntFlashCard = qntFlashCard - requestQuiz.Erros;
                qntErros = requestQuiz.Erros;
            }

            qntNaoRespondidas = qntFlashCard;


            var quizFinalizar = _interfaceRepositoryQuiz.QuizFinalizar(flashCard, qntAcertos, qntErros, qntNaoRespondidas, Convert.ToDecimal(nota.ToString("0.##")));

            return quizFinalizar;
        }
    }
}



