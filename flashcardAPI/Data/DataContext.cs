using flashcardAPI.Models;
using flashcardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace flashcardAPI.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Card> Card { get; set; }
        public DbSet<Flash> Flash { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<Teste> Teste { get; set; }
        public DbSet<Quiz> Quiz {  get; set; }
    }

}
