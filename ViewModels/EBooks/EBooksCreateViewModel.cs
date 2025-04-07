using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksCreateViewModel : IViewModel, IViewModelToModel<EBook>
{
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public string? PathToContent { get; set; } = "";
    public decimal Price { get; set; }

    public EBook ToModel()
    {
        return new()
        {
            Author = Author,
            PathToContent = PathToContent,
            Price = Price,
            Title = Title
        };
    }
}
