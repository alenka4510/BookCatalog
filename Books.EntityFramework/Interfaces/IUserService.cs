using Books.EntityFramework.Entity;

namespace Books.EntityFramework.Interfaces;

/// <summary>
/// аксессор для работы с пользовательскими данными
/// </summary>
public interface IUserService
{
    //AuthenticateResponse Authenticate(AuthenticateRequest model);
    
    /// <summary>
    /// регистрация - создание нового пользователя
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
   // AuthenticateResponse Register(UserModel userModel);
    
    /// <summary>
    /// получить всех пользователей
    /// </summary>
    /// <returns></returns>
    IEnumerable<User> GetAll();
    
    /// <summary>
    /// получить пользователя по ид
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    User GetById(int id);
}