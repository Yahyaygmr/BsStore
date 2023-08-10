using Entities.Models;
using Repositories.Cotracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateOneBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeletOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Book with id could notfound. Id : {id}");
            }

            _manager.Book.DeletOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id, trackChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Book with id could notfound. Id : {id}");
            }
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.UpdateOneBook(entity);
            _manager.Save();
        }
    }
}
