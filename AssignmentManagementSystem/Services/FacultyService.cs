using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class FacultyService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<FacultyModel> GetAllFaculty()
        {

            return context.Faculty.ToList();
        }
        public IEnumerable<FacultyModel> SearchFaculty(string searchTerm, int page, int recordSize)
        {

            var faculty = context.Faculty.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                faculty = faculty.Where(a => a.FacultyName.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return faculty.OrderBy(a => a.FacultyId).Skip(skip).Take(recordSize);

        }
        public int SearchFacultyCount(string searchTerm)
        {

            var faculty = context.Faculty.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                faculty = faculty.Where(a => a.FacultyName.ToLower().Contains(searchTerm.ToLower()));
            }
            return faculty.Count();
        }
        public FacultyModel GetFacultyById(int ID)
        {

            return context.Faculty.Find(ID);
        }
        public bool SaveFaculty(FacultyModel faculty)
        {

            context.Faculty.Add(faculty);
            return context.SaveChanges() > 0;
        }
        public bool UpdateFaculty(FacultyModel faculty)
        {

            context.Entry(faculty).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteFaculty(FacultyModel faculty)
        {

            context.Entry(faculty).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}