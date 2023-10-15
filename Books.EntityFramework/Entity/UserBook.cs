using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

//[Table("UserBook")]
public class UserBook : BaseEntity
{
    public User User { get; set; }
    public int UserId { get; set; }
    
    public Book Book { get; set; }
    public int BookId { get; set; }
}