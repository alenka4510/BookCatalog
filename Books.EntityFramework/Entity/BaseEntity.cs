using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.EntityFramework.Entity;

/// <summary>
/// базовая сущность
/// </summary>
public class BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date_stamp", TypeName = "timestamp without time zone")]
    public DateTime DateStamp { get; set; } = DateTime.Now;
    
    [Column("deleted")]
    public bool IsDeleted { get; set; }
}