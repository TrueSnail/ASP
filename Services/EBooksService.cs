using E_Book_Store.Data;
using E_Book_Store.Models;

namespace E_Book_Store.Services;

public class EBooksService : IEBooksService
{
    private readonly IRepository<EBook> EBookRepository;

    public EBooksService(IRepository<EBook> eBookRepository)
    {
        EBookRepository = eBookRepository;
    }

    public void Create(EBook eBook)
    {
        EBookRepository.Insert(eBook);
        EBookRepository.Save();
    }

    public void Delete(string Id)
    {
        var eBook = EBookRepository.GetById(Id);
        if (eBook != null) EBookRepository.Delete(Id);
        EBookRepository.Save();
    }

    public IEnumerable<EBook> GetAll() => EBookRepository.GetAll();

    public EBook? GetById(string Id)
    {
        if (string.IsNullOrEmpty(Id)) return null;
        return EBookRepository.GetById(Id);
    }

    public IEnumerable<EBook> GetPage(int pageSize, int pageNumber) => EBookRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);

    public void Update(EBook eBook)
    {
        EBookRepository.Update(eBook);
        EBookRepository.Save();
    }
}
