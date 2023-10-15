using Books.EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace Books.EntityFramework;

/// <summary>
/// Context
/// </summary>
public class BooksDbContext: DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryBook> CategoryBooks { get; set; }
    public DbSet<UserBook> UserBooks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Books)
            .UsingEntity(
                "UserBook",
                l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UsersId").HasPrincipalKey(nameof(User.Id)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                j => j.HasKey("UsersId", "BooksId"));
        
        modelBuilder.Entity<Book>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Books)
            .UsingEntity(
                "CategoryBook",
                l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.Id)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                j => j.HasKey("CategoryId", "BooksId"));

        modelBuilder.Entity<CategoryBook>()
            .HasIndex(c => new { c.BookId, c.CategoryId, c.IsDeleted }).IsUnique().HasFilter("deleted = false");

        modelBuilder.Entity<UserBook>()
            .HasIndex(u => new { u.UserId, u.BookId, u.IsDeleted }).IsUnique().HasFilter("deleted = false");


        modelBuilder.Entity<CategoryBook>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<UserBook>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
    }
}