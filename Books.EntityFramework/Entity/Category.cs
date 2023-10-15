using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

[Table("Category")]
public class Category : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    public IList<Book> Books { get; set; }
}