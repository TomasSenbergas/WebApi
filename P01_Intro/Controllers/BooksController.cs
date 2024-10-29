using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_Intro.Models;

namespace P01_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> _books;

        public BooksController()
        {
            //Generate random list of books where at least 3 authors are the same
            _books = new List<Book>()
            {
                new Book(1, "Book 1", new List<Author> { new Author(1, "Author 1", "Surname 1"), new Author(2, "Author 2", "Surname 2") }, 2021),
                new Book(2, "Book 2", new List<Author> { new Author(3, "Author 3", "Surname 3"), new Author(4, "Author 4", "Surname 4") }, 2020),
                new Book(3, "Book 3", new List<Author> { new Author(1, "Author 1", "Surname 1") }, 2019),
                new Book(4, "Book 4", new List<Author> { new Author(6, "Author 6", "Surname 6"), new Author(7, "Author 7", "Surname 7") }, 2018),
                new Book(5, "Book 5", new List<Author> { new Author(1, "Author 1", "Surname 1"), new Author(9, "Author 9", "Surname 9") }, 2017),
                new Book(6, "Book 6", new List<Author> { new Author(4, "Author 4", "Surname 4") }, 2016),
                new Book(7, "Book 7", new List<Author> { new Author(10, "Author 10", "Surname 10"), new Author(11, "Author 11", "Surname 11") }, 2015),
                new Book(8, "Book 8", new List<Author> { new Author(12, "Author 12", "Surname 12"), new Author(10, "Author 10", "Surname 10") }, 2014),

            };

        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        [HttpGet("{id:int:min(1)}")]
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        //metodas kuris filtruoja todo pagal tipa
        [HttpGet("GetBookByTitle")]
        public Book? GetBookByTitle(string title)
        {
            return _books.Find(x => x.Pavadinimas == title);
        }

        //[HttpGet("GetByAuthorAndTitle")]
        //public IEnumerable<Book>? GetByAuthorAndTitle(string title, string? author)
        //{
        //    //Neivedus nieko grazina klaida
        //    if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
        //    {
        //        throw new Exception("Nepateikti filtravimo parametrai");
        //    }
        //    return _books.Where(x => x.Pavadinimas.Contains(title) || x.Autorius == author);
        //}

        [HttpGet("GetByAuthor")]
        public IEnumerable<Book>? GetByAuthor(string author)
        {
            return _books.Where(x => x.Autoriai.Any(y => y.Vardas == author || y.Pavarde == author));
        }



    }
}
