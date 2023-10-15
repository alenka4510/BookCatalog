namespace Books.EntityFramework.Models;

/// <summary>
/// модель на отображении книги
/// </summary>
public class BookModelView
{
    public string Author { get; set; }
    
    public string Year { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int CountPages { get; set; }
    
    public string Cover { get; set; }
    
    public string Categories { get; set; }
}