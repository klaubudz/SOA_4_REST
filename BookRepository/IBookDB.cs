using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository
{
    public interface IBookDB
    {
        int Create(Book book);
        Book Get(int Id);
        List<Book> GetAll();
        Book Update(Book book);
        void Delete(int Id);
    }
}
