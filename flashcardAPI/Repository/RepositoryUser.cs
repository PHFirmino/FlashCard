using flashcardAPI.Data;
using flashcardAPI.Interfaces;
using flashcardAPI.Models;

namespace flashcardAPI.Repository
{
    public class RepositoryUser : InterfaceRepositoryUser
    {
        private readonly DataContext _dataContext;
        public RepositoryUser(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<User> AllUsers()
        {
            var users = _dataContext.User.ToList();
            return users;
        }
        public User AddUser(User user)
        {
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();

            return user;
        }

        public User EditUser(int id, User user)
        {
            var userEditado = _dataContext.User.FirstOrDefault(x => x.Id == id);
            userEditado.Nome = user.Nome;
            userEditado.Email = user.Email;

            _dataContext.SaveChanges();

            return userEditado;
        }

        public User LoginUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
