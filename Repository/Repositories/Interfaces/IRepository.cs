using Domain.Common;
using System;
using System.Collections.Generic;


namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
