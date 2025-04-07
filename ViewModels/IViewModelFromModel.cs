using E_Book_Store.ViewModels.EBooks;

namespace E_Book_Store.ViewModels;

public interface IViewModelFromModel<T>
{
    public IViewModelFromModel<T> FromModel(T model);
}
