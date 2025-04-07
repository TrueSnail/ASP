﻿using E_Book_Store.Models;

namespace E_Book_Store.ViewModels.EBooks;

public class EBooksEditViewModel : IViewModel, IViewModelFromModel<EBook>, IViewModelToModel<EBook>
{
    public string Id { get; set; } = "";
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public string? PathToContent { get; set; } = "";
    public decimal Price { get; set; }

    public IViewModelFromModel<EBook> FromModel(EBook eBook)
    {
        Id = eBook.Id;
        Author = eBook.Author;
        Title = eBook.Title;
        PathToContent = eBook.PathToContent;
        Price = eBook.Price;

        return this;
    }

    public EBook ToModel()
    {
        return new()
        {
            Id = Id,
            Author = Author,
            PathToContent = PathToContent,
            Price = Price,
            Title = Title
        };
    }
}
