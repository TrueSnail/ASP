using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksCreateViewModel
{
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public decimal Price { get; set; }
}
