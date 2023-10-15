using AutoMapper;
using Books.EntityFramework.Entity;
using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Models;
using Microsoft.Extensions.Configuration;

namespace Books.EntityFramework.Services;

/// <summary>
/// аксессор для работы с пользовательскими данными
/// </summary>
public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IRepository<User> userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    /*public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _userRepository
            .GetAll()
            .FirstOrDefault(x => x.FirstName == model.Username && x.Password == model.Password);

        if (user == null)
        {
            // todo: need to add logger
            return null;
        }

        var token = _configuration.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }*/

    /// <summary>
    /// регистрация - создание нового пользователя
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
    /*public AuthenticateResponse Register(UserModel userModel)
    {
        var user = new User()
        {
            UserName = userModel.UserName,
            FirstName = userModel.FirstName,
            Password = userModel.Password,
            IsAdmin = userModel.IsAdmin,
            LastName = userModel.LastName,
            DateStamp = DateTime.Now,
            IsDeleted = false,
        };

        _userRepository.Add(user);

        var response = Authenticate(new AuthenticateRequest
        {
            Username = user.UserName,
            Password = user.Password
        });

        return response;
    }*/

    /// <summary>
    /// получить всех пользователей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    /// <summary>
    /// получить пользователя по ид
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User GetById(int id)
    {
        return _userRepository.GetById(id);
    }
}