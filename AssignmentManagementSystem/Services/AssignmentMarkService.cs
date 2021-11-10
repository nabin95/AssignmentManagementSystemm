using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class AssignmentMarkService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<AssignmentMarksModel> GetAllAssignmentMarks()
        {

            return context.AssignmentMarks.ToList();
        }
        public IEnumerable<AssignmentMarksModel> SearchAssignmentMarks(string searchTerm, int page, int recordSize)
        {

            var assginmentMarks = context.AssignmentMarks.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assginmentMarks = assginmentMarks.Where(a => a.AssigmentMarks.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return assginmentMarks.OrderBy(a => a.AssigmentMarksId).Skip(skip).Take(recordSize);

        }
        public int SearchAssignmentMarksCount(string searchTerm)
        {

            var assginmentMarks = context.AssignmentMarks.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assginmentMarks = assginmentMarks.Where(a => a.AssigmentMarks.ToLower().Contains(searchTerm.ToLower()));
            }
            return assginmentMarks.Count();
        }
        public AssignmentMarksModel GetAssignmentMarksById(int ID)
        {

            return context.AssignmentMarks.Find(ID);
        }
        public bool SaveAssignmentMarks(AssignmentMarksModel assginmentMarks)
        {

            context.AssignmentMarks.Add(assginmentMarks);
            return context.SaveChanges() > 0;
        }
        public bool UpdateAssignmentMarks(AssignmentMarksModel assginmentMarks)
        {

            context.Entry(assginmentMarks).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteAssignmentMarks(AssignmentMarksModel assginmentMarks)
        {

            context.Entry(assginmentMarks).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}