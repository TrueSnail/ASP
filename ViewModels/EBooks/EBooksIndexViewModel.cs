using AutoMapper;
using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksIndexViewModel
{
    public List<EBooksIndexItemViewModel> EBooks { get; set; } = new();
}
