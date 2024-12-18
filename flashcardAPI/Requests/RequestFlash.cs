using flashcardAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace flashcardsAPI.Requests
{
    public class RequestFlash
    {
        public string Nome { get; set; }
        public int Segundos { get; set; }
        public int User { get; set; }
    }
}
