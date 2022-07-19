using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class LibraryService : ILibraryService
    {
        private LibraryRepository _libraryRepository;
        private int _count;
        public LibraryService()
        {
            _libraryRepository = new LibraryRepository();
        }

        public Library Create(Library library)
        {
            library.Id = _count;
            _libraryRepository.Create(library);
            _count++;
            return library;
        }

        public Library Delete(int id)
        {
            Library library = GetById(id);
            _libraryRepository.Delete(library);
            return library;
        }

        public List<Library> GetAll()
        {
            return _libraryRepository.GetAll();

        }

        public Library GetById(int id)
        {
            var library = _libraryRepository.Get(m => m.Id == id);
            if (library is null) return null;
            return library;
        }

        public List<Library> Search(string search)
        {
            return _libraryRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.Trim().ToLower()));
        }

        public Library Uptade(int id, Library library)
        {
            Library dbLibrary = GetById(id);
            if (dbLibrary is null) return null;
            library.Id = dbLibrary.Id;
            _libraryRepository.Update(library);
            return dbLibrary;
        }
    }
}
