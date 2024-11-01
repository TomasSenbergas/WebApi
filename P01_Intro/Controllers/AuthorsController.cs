﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_Intro.Models;

namespace P01_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private static List<Author> _authors = new List<Author>()
            {
                new Author(1, "Author 1", "Surname 1"),
                new Author(2, "Author 2", "Surname 2"),
                new Author(3, "Author 3", "Surname 3"),
                new Author(4, "Author 4", "Surname 4"),
                new Author(5, "Author 5", "Surname 5"),
                new Author(6, "Author 6", "Surname 6"),
                new Author(7, "Author 7", "Surname 7"),
                new Author(8, "Author 8", "Surname 8"),
                new Author(9, "Author 9", "Surname 9"),
                new Author(10, "Author 10", "Surname 10"),
                new Author(11, "Author 11", "Surname 11"),
                new Author(12, "Author 12", "Surname 12"),
            };



        private static List<Book> _books = new List<Book>()
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

        private static int _index = _authors.Count() + 1;

        public AuthorsController()
        {

        }
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return _authors;
        }

        [HttpGet("{id:int:min(1)}")]
        public Author? GetAuthorById(int id)
        {
            return _authors.Find(x => x.Id == id);
        }

        //[HttpGet("{id:int:min(1)}/Books")]
        //public IEnumerable<Book>? GetBooksByAuthorId(int id)
        //{
        //    return _books.Where(x => x.Autoriai.Any(author => author.Id == id));
        //}

        //[HttpGet("{id:int:min(1)}/BooksByTitle")]
        //public IEnumerable<Book>? GetBooksByAuthorIdAndTitle([FromRoute] int id, [FromQuery] string? title)
        //{
        //    return _books.Where(x => x.Autoriai.Any(author => author.Id == id) && (string.IsNullOrEmpty(title) || x.Pavadinimas.Contains(title)));
        //}


        //[HttpGet("{authorId:int:min(1)}/{bookId:int:min(1)}")]
        //public IEnumerable<Book>? GetBookByAuthorIdAndBookId(int authorId, int bookId)
        //{
        //    return _books.Where(x => x.Autoriai.Any(author => author.Id == authorId) && x.Id == bookId);
        //}

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] AuthorDTO newAuthor)
        {
            Author author = new Author { Id = _index++, Vardas = newAuthor.Vardas, Pavarde = newAuthor.Pavarde };
            _authors.Add(author);
        }
        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorDTO newAuthor)
        {
            var author = _authors.FirstOrDefault(x => x.Id == id);
            author.Vardas = newAuthor.Vardas;
            author.Pavarde = newAuthor.Pavarde;
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _authors.FirstOrDefault(x => x.Id == id);
            _authors.Remove(author);
        }







    }
}
