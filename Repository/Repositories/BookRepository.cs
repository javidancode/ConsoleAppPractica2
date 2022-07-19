using Domain.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public void Create(Book data)
        {
            try
            {
                if (data is null) throw new DllNotFoundException("Data notfound");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Book data)
        {
            throw new NotImplementedException();
        }

        public Book Get(Predicate<Book> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll(Predicate<Book> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Book data)
        {
            throw new NotImplementedException();
        }
    }
}
