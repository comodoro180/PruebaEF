
using ConsoleApp4.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new BookStore())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    var authors = new List<Author>
    {
        new Author
        {
            AuthorId = 1,
            FirstName ="Carson",
            LastName ="Alexander",
            BirthDate = DateTime.Parse("1985-09-01"),
            Books = new List<Book>()
            {
                new Book { Title = "Introduction to Machine Learning", BookId = 1},
                new Book { Title = "Advanced Topics on Machine Learning", BookId = 2},
                new Book { Title = "Introduction to Computing", BookId = 3}
            }
        },
        new Author
        {
            AuthorId = 2,
            FirstName ="Meredith",
            LastName ="Alonso",
            BirthDate = DateTime.Parse("1970-09-01"),
            Books = new List<Book>()
            {
                new Book { Title = "Introduction to Microeconomics", BookId = 4}
            }
        },
        new Author
        {
            AuthorId = 3,
            FirstName ="Arturo",
            LastName ="Anand",
            BirthDate = DateTime.Parse("1963-09-01"),
            Books = new List<Book>()
            {
                new Book { Title = "Calculus I", BookId = 5},
                new Book { Title = "Calculus II", BookId = 6}
            }
        }
    };

    context.Authors.AddRange(authors);
    context.SaveChanges();
}

using (var context = new BookStore())
{
    var list = context.Authors
        .Include(a => a.Books)
        .ToList();

    foreach (var author in list)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);

        foreach (var book in author.Books)
        {
            Console.WriteLine("\t" + book.Title);
        }
    }
}