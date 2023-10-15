using Books.EntityFramework.Entity;
using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Models;
using System.Linq;
using Books.EntityFramework.Accessors;

namespace Books.EntityFramework.Services;

public class UserBooksService : IUserBooksService
{
    private readonly IRepository<UserBook> _userBooksLinks;
    private readonly IRepository<Book> _books;
    private readonly IBookAccessor _bookAccessor;

    public UserBooksService(IRepository<UserBook> userBooksLinks, IRepository<Book> books, IBookAccessor bookAccessor)
    {
        _userBooksLinks = userBooksLinks;
        _books = books;
        _bookAccessor = bookAccessor;
    }

    public void AddBooks(int userId, IEnumerable<int> bookIds)
    {
        var userBookLink = bookIds.Select(rec => new UserBook()
        {
            BookId = rec,
            UserId = userId,
            DateStamp = DateTime.Now,
        }).ToList();

        _userBooksLinks.AddRange(userBookLink);
    }

    public void DeleteBook(int userId, IEnumerable<int> bookIds)
    {
        var userBookLinks =
            _userBooksLinks.GetAll().Where(rec => rec.UserId == userId && bookIds.Contains(rec.BookId));
        
        foreach (var userBookLink in userBookLinks)
        {
            userBookLink.IsDeleted = true;
        }

        _userBooksLinks.UpdateRange(userBookLinks.ToList());
    }
    
    public IList<BookModelView> GetBooksByUser(int userId)
    {
        return _bookAccessor.GetAllBooksByUser(userId).Select(rec => new BookModelView
        {
            Author = rec.Author,
            Cover = rec.CoverPath,
            Description = rec.Description,
            Name = rec.Name,
            Year = rec.Year,
            CountPages = rec.CountPages,
            Categories = string.Join(',', rec.CategoryBooks.Select(c => c.Category.Name).ToList())
        }).ToList();
    }
}