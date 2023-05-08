using MyApiNetCore6.Data;
using MyApiNetCore6.Models;
using System.Drawing.Printing;

namespace MyApiNetCore6.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> getAllBooksAsync();
        public Task<BookModel> getAllBookAsync(int id);
        public Task<int> AddBookAsync(BookModel model);
        public Task UpdateBookAsync(int id, BookModel model);
        public Task DeleteBookAsync(int id);

    }
}
