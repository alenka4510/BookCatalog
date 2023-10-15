using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogApi.Controllers;

/// <summary>
/// Контроллер пользования книжной полкой из роли обычного юзера
/// </summary>
[ApiController]
[Route("[controller]")]
//[Authorize(Roles="user")]
public class UserController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IUserBooksService _userBooksService;

    public UserController(IBookService bookService, IUserBooksService userBooksService)
    {
        _bookService = bookService;
        _userBooksService = userBooksService;
    }


    /// <summary>
    /// Полуить книги пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetBooksForUser")]
    public IList<BookModelView> GetBooksForUser(int userId)
    {
        return _userBooksService.GetBooksByUser(userId);
    }

    /// <summary>
    /// Добавить книгу в коллекцию
    /// </summary>
    /// <param name="userId">Идентификатор пользователя кому добавляются книги</param>
    /// <param name="books">Коллекция идентификаторов книг</param>
    [HttpPost]
    [Route("AddBooksToCollection")]
    public void AddBooksToCollection(int userId, IList<int> bookIds)
    {
        _userBooksService.AddBooks(userId, bookIds);
    }

    /// <summary>
    /// Удалить книги из коллекции
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="books">Коллекция идентификаторов книг</param>
    [HttpPost]
    [Route("DeleteBooks")]
    public void DeleteBooks(int userId, IList<int> bookIds)
    {
        _userBooksService.DeleteBook(userId, bookIds);
    }

    /// <summary>
    /// Поиск книги по автору или категории или по тому и тому
    /// </summary>
    /// <param name="author">Автор</param>
    /// <param name="categoryId">Ид категории</param>
    [HttpPost]
    [Route("SearchBooks")]
    public IList<BookModelView> SearchBooks(string author = null, int categoryId = 0)
    {
        return _bookService.GetAllBooksByParams(author, categoryId);
    }
}