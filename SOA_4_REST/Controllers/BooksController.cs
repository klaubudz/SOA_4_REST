using BookRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOA_4_REST.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookDB _bookDB;

        public BooksController(IBookDB bookDB)
        {
            _bookDB = bookDB;
        }

        public List<Book> Get()
        {
            return _bookDB.GetAll();
        }

        public Book Get(int Id)
        {
            return _bookDB.Get(Id);
        }

        public List<Book> Get([FromUri] string search)
        {
            var allBooks = _bookDB.GetAll();
            return allBooks.FindAll(e => e.BookTitle.ToUpper().Contains(search.ToUpper()));
        }

        public int Post([FromBody] Book book)
        {
            return _bookDB.Create(book);
        }

        public Book Put([FromBody] Book book, int Id)
        {
            book.Id = Id;
            return _bookDB.Update(book);
        }

        public void Delete(int Id)
        {
            _bookDB.Delete(Id);
        }
    }
}
