using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;

namespace Business.Concrete
{
    public class BookService:IBookService
    {
        private readonly IBookDal _bookDal;

        public BookService(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            return await _bookDal.AddAsync(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookDal.DeleteAsync(new Book { Id = id });
        }

        public async Task<bool> EditBookAsync(Book book)
        {
            return await _bookDal.UpdateAsync(book);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookDal.GetAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookDal.GetAllAsync();
        }
    }
}
