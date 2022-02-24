namespace ConsoleApp4.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public List<Editorial> Editorials { get; set; }
    }
}
