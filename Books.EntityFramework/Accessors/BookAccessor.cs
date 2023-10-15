using Books.EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace Books.EntityFramework.Accessors
{
    /// <summary>
    /// аксессор к книжным дб сетам
    /// </summary>
    public class BookAccessor : IBookAccessor
    {
        private readonly BooksDbContext _bookContext;

        public BookAccessor(BooksDbContext bookContext)
        {
            _bookContext = bookContext;
        }

        /// <summary>
        /// Получить все книги для отображения, включая категории
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> GetAllBooks()
        {
            var data = _bookContext.Books
                .AsNoTracking()
                .Include(x => x.CategoryBooks)
                .ThenInclude(x => x.Category);

            return data;
        }

        /// <summary>
        /// Получить книги по параметрам 
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="categoryId">ид категории</param>
        /// <returns></returns>
        public IQueryable<Book> GetAllBooksByParams(string? author, int categoryId)
        {
            var data = _bookContext.Books
                .AsNoTracking()
                .Where(rec => (string.IsNullOrEmpty(author)) || rec.Author == author)
                .Where(rec => (categoryId == 0) || rec.CategoryBooks.Select(c => c.Category.Id).Contains(categoryId))
                .Include(x => x.CategoryBooks)
                .ThenInclude(x => x.Category);

            return data;
        }

        /// <summary>
        /// Получить все книги для отобрпажения пользователю, включая категории
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetAllBooksByUser(int userId)
        {
            var data = _bookContext.UserBooks
                .AsNoTracking()
                .Include(x => x.Book)
                .ThenInclude(x => x.CategoryBooks)
                .ThenInclude(x => x.Category)
                .Select(x => x.Book);

            return data;
        }

        /// <summary>
        /// Получить все книги по ид
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksById(IList<int> bookIds)
        {
            var data = _bookContext.Books
                .AsNoTracking()
                .Where(x => bookIds.Contains(x.Id))
                .Include(c => c.CategoryBooks)
                .Include(ub => ub.UserBooks);

            return data;
        }

        /// <summary>
        /// Получить линку категории и книги по книге
        /// </summary>
        /// <param name="bookId">ид книги</param>
        public List<CategoryBook> GetCategoryBookByBook(int bookId)
        {
            return _bookContext.CategoryBooks
                .AsNoTracking()
                .Where(rec => rec.BookId == bookId)
                .ToList();
        }
    }
}

