using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class DepartmentService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<DepartmentModel> GetAllDepartment()
        {

            return context.Department.ToList();
        }
        public IEnumerable<DepartmentModel> SearchDepartment(string searchTerm, int page, int recordSize)
        {

            var department = context.Department.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                department = department.Where(a => a.DepartmentName.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return department.OrderBy(a => a.DepartmentId).Skip(skip).Take(recordSize);

        }
        public int SearchDepartmentCount(string searchTerm)
        {

            var department = context.Department.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                department = department.Where(a => a.DepartmentName.ToLower().Contains(searchTerm.ToLower()));
            }
            return department.Count();
        }
        public DepartmentModel GetDepartmentById(int ID)
        {

            return context.Department.Find(ID);
        }
        public bool SaveDepartment(DepartmentModel department)
        {

            context.Department.Add(department);
            return context.SaveChanges() > 0;
        }
        public bool UpdateDepartment(DepartmentModel department)
        {

            context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteDepartment(DepartmentModel department)
        {

            context.Entry(department).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}