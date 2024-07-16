using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;
using MyWebApi.Repo.Interface;

namespace MyWebApi.Repo.Services
{
    public class BookRepository : IBook
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
         return  _context.Books.ToList();
        }

        public Book GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
