using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Repository
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entityList);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        IEnumerable<T> GetAllQueryable();
        //DbContextTransaction BeginTransaction();
        //Task SaveChangesAsync();
        int Commit();
    }
}