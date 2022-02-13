using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Abstract
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<bool> AddBookAsync(Book book);

        Task<bool> EditBookAsync(Book book);

        Task<bool> DeleteBookAsync(int id);
    }
}
