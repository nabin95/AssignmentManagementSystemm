using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class TeacherService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<TeacherModel> GetAllTeacher()
        {

            return context.Teacher.ToList();
        }
        public IEnumerable<TeacherModel> SearchTeacher(string searchTerm, int page, int recordSize)
        {

            var teacher = context.Teacher.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                teacher = teacher.Where(a => a.TeacherName.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return teacher.OrderBy(a => a.TeacherId).Skip(skip).Take(recordSize);

        }
        public int SearchTeacherCount(string searchTerm)
        {

            var teacher = context.Teacher.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                teacher = teacher.Where(a => a.TeacherName.ToLower().Contains(searchTerm.ToLower()));
            }
            return teacher.Count();
        }
        public TeacherModel GetTeacherById(int ID)
        {

            return context.Teacher.Find(ID);
        }
        public bool SaveTeacher(TeacherModel teacher)
        {

            context.Teacher.Add(teacher);
            return context.SaveChanges() > 0;
        }
        public bool UpdateTeacher(TeacherModel teacher)
        {

            context.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteTeacher(TeacherModel teacher)
        {

            context.Entry(teacher).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}