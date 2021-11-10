using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManagementSystem.Services
{
    public class StudentService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<StudentModel> GetAllStudent()
        {

            return context.Student.ToList();
        }
        public IEnumerable<StudentModel> SearchStudent(string searchTerm, int page, int recordSize)
        {

            var student = context.Student.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                student = student.Where(a => a.StudentName.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return student.OrderBy(a => a.StudentId).Skip(skip).Take(recordSize);

        }
        public int SearchStudentCount(string searchTerm)
        {

            var student = context.Student.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                student = student.Where(a => a.StudentName.ToLower().Contains(searchTerm.ToLower()));
            }
            return student.Count();
        }
        public StudentModel GetStudentById(int ID)
        {

            return context.Student.Find(ID);
        }
        public bool SaveStudent(StudentModel student)
        {

            context.Student.Add(student);
            return context.SaveChanges() > 0;
        }
        public bool UpdateStudent(StudentModel student)
        {

            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteStudent(StudentModel student)
        {

            context.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
      
    }
}