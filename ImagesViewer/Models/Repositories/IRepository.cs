using System;
using System.Linq;

namespace ImagesViewer.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void SaveChanges();
    }
}
