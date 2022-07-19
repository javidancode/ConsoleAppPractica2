using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private BookRepository _bookRepository;
        private LibraryRepository _libraryRepository;

        private int _count;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public Book Create(int libraryId, Book book)
        {
            var library = _libraryRepository.Get(m => m.Id == libraryId);
            if (library is null) return null;
            book.Id = _count;
            book.Library = library;
            _bookRepository.Create(book);
            _count++;
            return book;
        }
    }
}
