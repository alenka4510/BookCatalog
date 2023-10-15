using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

[Table("Book")]
public class Book : BaseEntity
{
    [Column("author")]
    public string Author { get; set; }
    
    [Column("year")]
    public string Year { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("count_pages")]
    public int CountPages { get; set; }
    
    [Column("cover_path")]
    public string CoverPath { get; set; }

    public IList<Category> Categories { get; set; }
    public IList<CategoryBook> CategoryBooks { get; set; }
    public User[] Users { get; set; }
    public IList<UserBook> UserBooks { get; set; }
}