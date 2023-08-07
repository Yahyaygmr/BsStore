using Entities.Models;
using Repositories.Cotracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book)
        {
            Create(book);
        }

        public void DeletOneBook(Book book)
        {
            Delete(book);
        }

        public IQueryable<Book> GetAllBooks(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(x => x.Id);
        }

        public IQueryable<Book> GetOneBookById(int id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }

        public void UpdateOneBook(Book book)
        {
            Update(book);
        }
    }
}
