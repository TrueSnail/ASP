using System.ComponentModel.DataAnnotations;

namespace E_Book_Store.Models;

public class EBook
{
    public EBook()
    {
        EBookId = new Guid();
    }

    [Key]
    public Guid EBookId { get; set; }
    [Required]
    public required string Author { get; set; }
    [Required]
    public required string Title { get; set; }
    public string? PathToContent { get; set; }
    [Required]
    public required decimal Price { get; set; }
}
