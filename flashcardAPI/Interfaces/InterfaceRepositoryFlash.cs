using flashcardAPI.Models;
using flashcardsAPI.Requests;

namespace flashcardAPI.Interfaces
{
    public interface InterfaceRepositoryFlash
    {
        public List<Flash> AllFlashs();
        public Flash FindByIdFlash(int id);
        public List<Flash> FindByNameFlashs(string question);
        public Flash AddFlash(RequestFlash card);
        public Flash EditFlash(int id, RequestFlash card);
        public Flash DeleteFlash(int id);
    }
}
