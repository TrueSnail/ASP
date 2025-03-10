using System.ComponentModel.DataAnnotations;

namespace E_Book_Store.Models;

public class EBook
{
    [Key]
    public string Id { get; set; }
    [Required]
    public required string Author { get; set; }
    [Required]
    public required string Title { get; set; }
    public string? PathToContent { get; set; }
    [Required]
    public required decimal Price { get; set; }

    public EBook()
    {
        Id = new Guid().ToString();
    }
}
