namespace Books.EntityFramework.Models;

/// <summary>
/// модель для сохранения книги
/// </summary>
public class BookModel
{
    public int Id { get; set; }
    
    public string Author { get; set; }
    
    public string Year { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int CountPages { get; set; }
    
    public string Cover { get; set; }
    
    public int[] CategoryIds { get; set; }
}