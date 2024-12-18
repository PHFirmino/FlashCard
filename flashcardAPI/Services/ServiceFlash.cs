using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using flashcardsAPI.Requests;

namespace flashcardAPI.Services
{
    public class ServiceFlash : InterfaceServiceFlash
    {
        private readonly InterfaceRepositoryFlash _interfaceRepositoryFlash;
        public ServiceFlash(InterfaceRepositoryFlash interfaceRepositoryFlash) 
        {
            _interfaceRepositoryFlash = interfaceRepositoryFlash;
        }
        public List<Flash> AllFlashs()
        {
            var flashs = _interfaceRepositoryFlash.AllFlashs();

            return flashs;
        }
        public Flash FindByIdFlash(int id)
        {
            var flash = _interfaceRepositoryFlash.FindByIdFlash(id);

            return flash;
        }
        public List<Flash> FindByNameFlashs(string name)
        {
            var flashs = _interfaceRepositoryFlash.FindByNameFlashs(name);

            return flashs;
        }
        public Flash AddFlash(RequestFlash flash)
        {
            var flashAdicionado = _interfaceRepositoryFlash.AddFlash(flash);

            return flashAdicionado;
        }
        public Flash EditFlash(int id, RequestFlash flash)
        {
            var flashEditado = _interfaceRepositoryFlash.EditFlash(id, flash);

            return flashEditado;
        }
        public Flash DeleteFlash(int id)
        {
            var flashExcluido = _interfaceRepositoryFlash.DeleteFlash(id);

            return flashExcluido;
        }
    }
}
