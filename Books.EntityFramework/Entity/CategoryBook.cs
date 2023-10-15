using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

//[Table("CategoryBook")]
public class CategoryBook : BaseEntity
{
    public Book Book { get; set; }
    
    public int BookId { get; set; }
    
    public Category Category { get; set; }
    
    public int CategoryId { get; set; }
}