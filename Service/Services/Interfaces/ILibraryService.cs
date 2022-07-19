using Domain.Models;

using System.Collections.Generic;


namespace Service.Services.Interfaces
{
    public interface ILibraryService
    {
        Library Create(Library library);
        Library Uptade(int id, Library library);
        Library Delete(int id);
        Library GetById(int id);
        List<Library> GetAll();
        List<Library> Search(string search);
    }
}
