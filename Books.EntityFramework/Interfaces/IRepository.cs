using Books.EntityFramework.Entity;

namespace Books.EntityFramework.Interfaces;

/// <summary>
/// Базовая функциональность для работы с сущносятми
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository <T> where T: BaseEntity
{
    IList<T> GetAll();
    
    IList<T> GetByIds(IList<int> ids);

    T? GetById(int id);
    
    void Add(T entity);

    void AddRange(IList<T>? newEntities);
    
    void Update(T? entity);

    void UpdateRange(IList<T>? newEntities);
}