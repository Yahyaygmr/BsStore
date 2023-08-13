using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParamaters bookParamaters, bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return PagedList<Book>.ToPagedList(books, bookParamaters.PageNumber, bookParamaters.PageSize);
        }

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateOneBook(Book book)
        {
            Update(book);
        }
    }
}
