namespace flashcardAPI.Models
{
    public class Flash
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Segundos { get; set; }
        public User User { get; set; }
    }
}
