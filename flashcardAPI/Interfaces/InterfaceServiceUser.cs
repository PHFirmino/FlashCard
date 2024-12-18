using flashcardAPI.Models;

namespace flashcardAPI.Interfaces
{
    public interface InterfaceServiceUser
    {
        public List<User> AllUsers();
        public User AddUser(User user);
        public User EditUser(int id, User user);
        public User LoginUser(User user);
    }
}
