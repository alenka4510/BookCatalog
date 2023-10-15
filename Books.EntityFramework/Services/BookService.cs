using Books.EntityFramework.Accessors;
using Books.EntityFramework.Entity;
using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Models;

namespace Books.EntityFramework.Services;

/// <summary>
/// дбаксессор для работы с книгами
/// </summary>
public class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<CategoryBook> _categoryBookRepository;
    private readonly IRepository<UserBook> _userBookRepository;
    private readonly IBookAccessor _bookAccessor;

    public BookService(IRepository<Book> bookRepository, IRepository<CategoryBook> categoryBookitory, IBookAccessor bookAccessor, IRepository<UserBook> userBookRepository)
    {
        _bookRepository = bookRepository;
        _categoryBookRepository = categoryBookitory;
        _bookAccessor = bookAccessor;
        _userBookRepository = userBookRepository;
    }

    /// <summary>
    /// Получить список всех книг
    /// </summary>
    /// <returns></returns>
    public IList<BookModelView> GetAllBooks()
    {
        var books = _bookAccessor.GetAllBooks().Select(rec => new BookModelView
        {
            Author = rec.Author,
            Cover = rec.CoverPath,
            Description = rec.Description,
            Name = rec.Name,
            Year = rec.Year,
            CountPages = rec.CountPages,
            Categories = string.Join(',', rec.CategoryBooks.Select(c => c.Category.Name).ToList())
        }).ToList();

        return books;

    }

    /// <summary>
    /// Получить список по параметрам
    /// </summary>
    /// <returns></returns>
    public IList<BookModelView> GetAllBooksByParams(string? author, int categoryId)
    {
        var bookParam = _bookAccessor.GetAllBooksByParams(author, categoryId)
            .Select(rec => new BookModelView
        {
            Author = rec.Author,
            Cover = rec.CoverPath,
            Description = rec.Description,
            Name = rec.Name,
            Year = rec.Year,
            CountPages = rec.CountPages,
            Categories = string.Join(',', rec.CategoryBooks.Select(c => c.Category.Name).ToList())
        }).ToList();

        return bookParam;
    }

    /// <summary>
    /// Создать книгу 
    /// </summary>
    /// <param name="bookModel"> Данные о книге, прешедшие с UI</param>
    public void CreateBook(BookModel bookModel)
    {
        var newBook =
            new Book()
            {
                Author = bookModel.Author,
                Description = bookModel.Description,
                CoverPath = bookModel.Cover,
                Name = bookModel.Name,
                Year = bookModel.Year,
                CountPages = bookModel.CountPages,
                DateStamp = DateTime.Now,
                IsDeleted = false,
                CategoryBooks = bookModel.CategoryIds.Select(rec => new CategoryBook
                {
                    CategoryId = rec
                }).ToList()
            };

        foreach(var ct in newBook.CategoryBooks)
        {
            ct.Book = newBook;
        }

        _bookRepository.Add(newBook);
    }
    
    /// <summary>
    /// Редактировать
    /// </summary>
    /// <param name="bookModel"></param>
    public void Edit(BookModel bookModel)
    {
        var newBook =
            new Book()
            {
                Id = bookModel.Id,
                Author = bookModel.Author,
                Description = bookModel.Description,
                CoverPath = bookModel.Cover,
                Name = bookModel.Name,
                Year = bookModel.Year,
                CountPages = bookModel.CountPages,
                DateStamp = DateTime.Now,
                IsDeleted = false
            };

        var categoryBook = _bookAccessor.GetCategoryBookByBook(bookModel.Id);
        var linkIdsFromDb = categoryBook.Select(rec => rec.CategoryId);

        var catBookNeedChanges = !(linkIdsFromDb.Count() == bookModel.CategoryIds.Length &&
                                   linkIdsFromDb.Intersect(bookModel.CategoryIds).Count() == linkIdsFromDb.Count());

        if (catBookNeedChanges)
        {
            foreach (var cb in categoryBook)
            {
                cb.IsDeleted = true;
            }
            _categoryBookRepository.UpdateRange(categoryBook);

            var newCBLink = bookModel.CategoryIds.Select(rec => new CategoryBook()
            {
                CategoryId = rec,
                BookId = bookModel.Id
            }).ToList();
            _categoryBookRepository.AddRange(newCBLink);
        }

        _bookRepository.Update(newBook);
    }

    /// <summary>
    /// Удалить книги
    /// </summary>
    /// <param name="bookIds"></param>
    public void DeleteBooks(IList<int> bookIds)
    {
        var books = _bookAccessor.GetBooksById(bookIds);
        foreach (var book in books)
        {
            book.IsDeleted = true;
            book.CategoryBooks.ToList().ForEach(x => x.IsDeleted = true);
            book.UserBooks.ToList().ForEach(x => x.IsDeleted = true);
            _bookRepository.Update(book);
        }
    }
}