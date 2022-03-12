using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyAmazon.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
        public void CreateBook(Book p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteBook(Book p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}
