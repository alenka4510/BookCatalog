using Books.EntityFramework.Entity;
using Books.EntityFramework.Interfaces;

namespace Books.EntityFramework.Services;

/// <summary>
/// Базовая функциональность для работы с сущносятми
/// </summary>
/// <typeparam name="T"></typeparam>
public class Repository<T>: IRepository<T> where T: BaseEntity
{
    protected readonly BooksDbContext _context;

    public Repository(BooksDbContext context)
    {
        _context = context;
    }

    public IList<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public IList<T> GetByIds(IList<int> ids)
    {
        return _context.Set<T>().Where(rec => ids.Contains(rec.Id)).ToList();
    }
    
    public T? GetById(int id)
    {
        return _context.Set<T>().FirstOrDefault(rec => rec.Id == id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
    
    public void AddRange(IList<T>? newEntities)
    {
        if (newEntities == null || !newEntities.Any())
        {
            return;
        }

        _context.Set<T>().AddRange(newEntities);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
    
    public void Update(T? newEntity)
    {
        if (newEntity == null)
        {
            return;
        }
 
        _context.Set<T>().Update(newEntity);
        _context.SaveChanges();
    }
    
    public void UpdateRange(IList<T>? newEntities)
    {
        if (newEntities == null || !newEntities.Any())
        {
            return;
        }
 
        _context.Set<T>().UpdateRange(newEntities);
        _context.SaveChanges();
    }
}