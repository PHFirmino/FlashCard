using flashcardAPI.Models;
using flashcardsAPI.Requests;

namespace flashcardAPI.Interfaces
{
    public interface InterfaceServiceFlash
    {
        public List<Flash> AllFlashs();
        public Flash FindByIdFlash(int id);
        public List<Flash> FindByNameFlashs(string question);
        public Flash AddFlash(RequestFlash flash);
        public Flash EditFlash(int id, RequestFlash flash);
        public Flash DeleteFlash(int id);
    }
}
