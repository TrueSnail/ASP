using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksIndexViewModel : IViewModelFromModel<IEnumerable<EBook>>
{
    public List<EBooksIndexItemViewModel> EBooks { get; set; } = new();

    public IViewModelFromModel<IEnumerable<EBook>> FromModel(IEnumerable<EBook> eBooks)
    {
        EBooks = eBooks.Select(ebook => (new EBooksIndexItemViewModel().FromModel(ebook) as EBooksIndexItemViewModel)!).ToList();

        return this;
    }
}
