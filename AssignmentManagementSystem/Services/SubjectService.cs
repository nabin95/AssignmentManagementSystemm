using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class SubjectService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<SubjectModel> GetAllSubject()
        {

            return context.Subject.ToList();
        }
        public IEnumerable<SubjectModel> SearchSubject(string searchTerm, int page, int recordSize)
        {

            var subject = context.Subject.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                subject = subject.Where(a => a.SubjectName.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return subject.OrderBy(a => a.SubjectId).Skip(skip).Take(recordSize);

        }
        public int SearchSubjectCount(string searchTerm)
        {

            var subject = context.Subject.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                subject = subject.Where(a => a.SubjectName.ToLower().Contains(searchTerm.ToLower()));
            }
            return subject.Count();
        }
        public SubjectModel GetSubjectById(int ID)
        {

            return context.Subject.Find(ID);
        }
        public bool SaveSubject(SubjectModel subject)
        {

            context.Subject.Add(subject);
            return context.SaveChanges() > 0;
        }
        public bool UpdateSubject(SubjectModel subject)
        {

            context.Entry(subject).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteSubject(SubjectModel subject)
        {

            context.Entry(subject).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}