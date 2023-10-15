using Books.EntityFramework.Models;

namespace Books.EntityFramework.Interfaces;

/// <summary>
/// пользовательская работа с книжной полкой
/// </summary>
public interface IUserBooksService
{
    void AddBooks(int userId, IEnumerable<int> bookIds);

    void DeleteBook(int userId, IEnumerable<int> bookIds);

    IList<BookModelView> GetBooksByUser(int userId);
}