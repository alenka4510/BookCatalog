using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

[Table("User")]
public class User : BaseEntity
{
    [Column("user_name")]
    public string UserName { get; set; }
    
    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
    
    [Column("is_admin")]
    [DefaultValue(false)]
    public bool IsAdmin { get; set; }
    
    public Book[] Books { get; set; }
}