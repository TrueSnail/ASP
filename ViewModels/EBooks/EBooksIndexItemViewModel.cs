using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksIndexItemViewModel : IViewModelFromModel<EBook>
{
    public string Id { get; set; } = "";
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public decimal Price { get; set; }

    public IViewModelFromModel<EBook> FromModel(EBook eBook)
    {
        Id = eBook.Id;
        Author = eBook.Author;
        Title = eBook.Title;
        Price = eBook.Price;

        return this;
    }
}
