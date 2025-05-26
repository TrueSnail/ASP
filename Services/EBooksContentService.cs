using E_Book_Store.Data;
using E_Book_Store.Models;

namespace E_Book_Store.Services;

public class EBooksContentService : IEBooksContentService
{
    const string PATH_PREFIX = "/EBookContent/";

    private readonly IRepository<EBook> EBookRepository;

    public EBooksContentService(IRepository<EBook> eBookRepository)
    {
        EBookRepository = eBookRepository;
    }

    public void DeleteContent(EBook eBook)
    {
        if (eBook.PathToContent != null)
        {
            File.Delete(eBook.PathToContent);
            eBook.PathToContent = null;
            EBookRepository.Update(eBook);
            EBookRepository.Save();
        }
    }

    public string GetContent(EBook eBook)
    {
        if (eBook.PathToContent == null) return "";
        else return File.ReadAllText(eBook.PathToContent);
    }

    public void SetContent(EBook eBook, string content)
    {
        string? PathToContent = eBook.PathToContent;
        if (PathToContent == null)
        {
            PathToContent = Environment.CurrentDirectory + PATH_PREFIX + eBook.Id + ".txt";
            eBook.PathToContent = PathToContent;
            EBookRepository.Update(eBook);
            EBookRepository.Save();
        }

        File.WriteAllText(PathToContent, content);
    }
}
