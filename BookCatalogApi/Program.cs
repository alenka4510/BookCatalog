using Books.EntityFramework;
using Books.EntityFramework.Accessors;
using Books.EntityFramework.Entity;
using Books.EntityFramework.Interfaces;
using Books.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BooksDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("DbConnection")), ServiceLifetime.Transient);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserBooksService, UserBooksService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRepository<Book>, Repository<Book>>();
builder.Services.AddTransient<IRepository<User>, Repository<User>>();
builder.Services.AddTransient<IRepository<CategoryBook>, Repository<CategoryBook>>();
builder.Services.AddTransient<IBookAccessor, BookAccessor>();
builder.Services.AddTransient<IRepository<UserBook>, Repository<UserBook>>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();