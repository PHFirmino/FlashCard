using flashcardAPI.Interfaces;
using flashcardAPI.Models;

namespace flashcardAPI.Services
{
    public class ServiceUser : InterfaceServiceUser
    {
        private readonly InterfaceRepositoryUser _interfaceRepositoryUser;
        public ServiceUser(InterfaceRepositoryUser interfaceRepositoryUser) 
        {
            _interfaceRepositoryUser = interfaceRepositoryUser;
        }
        public List<User> AllUsers()
        {
            var users = _interfaceRepositoryUser.AllUsers();

            return users;
        }
        public User AddUser(User user)
        {
            var userAdicionado = _interfaceRepositoryUser.AddUser(user);

            return userAdicionado;
        }

        public User EditUser(int id, User user)
        {
            var userEditado = _interfaceRepositoryUser.EditUser(id, user);

            return userEditado;
        }

        public User LoginUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
