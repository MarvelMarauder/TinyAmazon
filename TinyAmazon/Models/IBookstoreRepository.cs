using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyAmazon.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book p);
        public void CreateBook(Book p);
        public void DeleteBook(Book p);

    }
}
