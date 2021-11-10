using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class AssignmentStatusService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<AssignmentStatusModel> GetAllAssignmentStatus()
        {

            return context.AssignmentStatus.ToList();
        }
        public IEnumerable<AssignmentStatusModel> SearchAssignmentStatus(string searchTerm, int page, int recordSize)
        {

            var assignmentStatuses = context.AssignmentStatus.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assignmentStatuses = assignmentStatuses.Where(a => a.AssigmentStatus.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return assignmentStatuses.OrderBy(a => a.AssigmentStatusId).Skip(skip).Take(recordSize);

        }
        public int SearchAssignmentStatusCount(string searchTerm)
        {

            var assignmentStatuses = context.AssignmentStatus.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assignmentStatuses = assignmentStatuses.Where(a => a.AssigmentStatus.ToLower().Contains(searchTerm.ToLower()));
            }
            return assignmentStatuses.Count();
        }
        public AssignmentStatusModel GetAssginmentStatusById(int ID)
        {

            return context.AssignmentStatus.Find(ID);
        }
        public bool SaveAssignmentStatus(AssignmentStatusModel assignmentStatuses)
        {

            context.AssignmentStatus.Add(assignmentStatuses);
            return context.SaveChanges() > 0;
        }
        public bool UpdateAssignmentStatus(AssignmentStatusModel assignmentStatuses)
        {

            context.Entry(assignmentStatuses).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteAssignmentStatus(AssignmentStatusModel assignmentStatuses)
        {

            context.Entry(assignmentStatuses).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}