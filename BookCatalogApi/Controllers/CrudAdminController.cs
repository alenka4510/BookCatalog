using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogApi.Controllers;

/// <summary>
/// Контроллер для работы с книгами из под роли админа
/// </summary>
[ApiController]
[Route("CrudAdmin")]
//[Authorize(Roles="admin")]
public class CrudAdminController : ControllerBase
{
    private readonly IBookService _bookService;

    public CrudAdminController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Получить все книги
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IList<BookModelView> Get()
    {
        return _bookService.GetAllBooks();
    }

    /// <summary>
    /// Добавить книгу в базу
    /// </summary>
    /// <param name="books"></param>
    [HttpPost]
    [Route("AddBooks")]
    public void AddBooks(BookModel book)
    {
        _bookService.CreateBook(book);
    }

    /// <summary>
    /// Удалить книги из базы
    /// </summary>
    /// <param name="books"></param>
    [HttpPost]
    [Route("DeleteBooks")]
    public void DeleteBooks(IList<int> bookIds)
    {
        _bookService.DeleteBooks(bookIds);
    }

    /// <summary>
    /// Редактировать книгу
    /// </summary>
    /// <param name="books"></param>
    [HttpPost]
    [Route("EditBook")]
    public void EditBook(BookModel book)
    {
        _bookService.Edit(book);
    }
}