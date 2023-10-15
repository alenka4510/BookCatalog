using Books.EntityFramework.Models;

namespace Books.EntityFramework.Interfaces;

/// <summary>
/// дбаксессор для работы с книгами
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Создать книгу 
    /// </summary>
    /// <param name="bookModel"> Данные о книге, прешедшие с UI</param>
    void CreateBook(BookModel bookModel);

    /// <summary>
    /// Редактировать
    /// </summary>
    /// <param name="bookModel"></param>
    void Edit(BookModel bookModel);

    /// <summary>
    /// Удалить книги
    /// </summary>
    /// <param name="bookIds"></param>
    void DeleteBooks(IList<int> bookIds);

    /// <summary>
    /// Получить все книги для отображения
    /// </summary>
    /// <returns></returns>
    IList<BookModelView> GetAllBooks();

    /// <summary>
    /// получить книги по параметрам 
    /// </summary>
    /// <param name="author"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    IList<BookModelView> GetAllBooksByParams(string? author, int categoryId);
}