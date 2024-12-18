using flashcardAPI.Data;
using flashcardAPI.Interfaces;
using flashcardAPI.Models;
using flashcardsAPI.Requests;
using Microsoft.EntityFrameworkCore;
using DataContext = flashcardAPI.Data.DataContext;

namespace flashcardAPI.Repository
{
    public class RepositoryFlash : InterfaceRepositoryFlash
    {
        private readonly DataContext _dataContext;

        public RepositoryFlash(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Flash> AllFlashs()
        {
            var flashs = _dataContext.Flash.Include(x => x.User).ToList();

            return flashs;
        }
        public Flash FindByIdFlash(int id)
        {
            var flash = _dataContext.Flash.Include(x => x.User).FirstOrDefault(x => x.Id == id);

            return flash;
        }
        public List<Flash> FindByNameFlashs(string name)
        {
            var flashs = _dataContext.Flash.Include(x => x.User).Where(x => x.Nome.ToUpper().Contains(name.ToUpper())).ToList();

            return flashs;
        }
        public Flash AddFlash(RequestFlash flash)
        {
            Flash flashAdd = new Flash();
            flashAdd.Nome = flash.Nome;
            flashAdd.Segundos = flash.Segundos;
            flashAdd.User = _dataContext.User.FirstOrDefault(x => x.Id == flash.User);

            _dataContext.Add(flashAdd);

            _dataContext.SaveChanges();

            return flashAdd;
        }
        public Flash EditFlash(int id, RequestFlash flash)
        {
            var flashEditado = _dataContext.Flash.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            flashEditado.Nome = flash.Nome;
            flashEditado.Segundos = flash.Segundos;

            _dataContext.SaveChanges();

            return flashEditado;
            
        }
        public Flash DeleteFlash(int id)
        {
            var flashExcluido = _dataContext.Flash.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            _dataContext.Remove(flashExcluido);

            _dataContext.SaveChanges();

            return flashExcluido;
        }
    }
}
