using Books.EntityFramework.Entity;

namespace Books.EntityFramework.Accessors
{
    /// <summary>
    /// аксессор к книжным дб сетам
    /// </summary>
    public interface IBookAccessor
    {
        IQueryable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksByUser(int userId);

        IQueryable<Book> GetAllBooksByParams(string? author, int categoryId);

        List<CategoryBook> GetCategoryBookByBook(int bookId);

        IEnumerable<Book> GetBooksById(IList<int> bookIds);
    }
}
