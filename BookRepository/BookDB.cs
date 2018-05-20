using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Models;

namespace BookRepository
{
    public class BookDB : IBookDB
    {
        //connection string
        private readonly string _connectionString = @"C:\DB\SOA_4";

        // nazwa kolekcji
        private readonly string _collectionName = "Books";


        public int Create(Book book)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<Book>(_collectionName);

                return collection.Insert(book);     // Insert zwraca Id
            }
        }

        public Book Get(int Id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<Book>(_collectionName);

                return collection.FindById(Id);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<Book>(_collectionName);

                return collection.FindAll().ToList();
            }
        }

        public void Delete(int Id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<Book>(_collectionName);

                collection.Delete(e => e.Id == Id);
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<Book>(_collectionName);

                collection.Update(book);
                return collection.FindById(book.Id);
            }
        }
    }
}
