using AssignmentManagementSystem.Data;
using AssignmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Services
{
    public class AssignmentService
    {
        AssigmentDbContext context = new AssigmentDbContext();
        public IEnumerable<AssignmentModel> GetAllAssignment()
        {
          
            return context.Assigment.ToList();
        }
        public IEnumerable<AssignmentModel> SearchAssignment(string searchTerm, int page, int recordSize)
        {

            var assignment = context.Assigment.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assignment = assignment.Where(a => a.AssignmentStatusModel.AssigmentStatus.ToLower().Contains(searchTerm.ToLower()));
            }
            var skip = (page - 1) * recordSize;
            return assignment.OrderBy(a => a.AssignmentId).Skip(skip).Take(recordSize);

        }
        public int SearchAssigmentCount(string searchTerm)
        {

            var assignment = context.Assigment.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                assignment = assignment.Where(a => a.AssignmentStatusModel.AssigmentStatus.ToLower().Contains(searchTerm.ToLower()));
            }
            return assignment.Count();
        }
        public AssignmentModel GetAssignmentById(int ID)
        {
           
            return context.Assigment.Find(ID);
        }
        public bool SaveAssignment(AssignmentModel assignment)
        {
          
            context.Assigment.Add(assignment);
            return context.SaveChanges() > 0;
        }
        public bool UpdateAssignment(AssignmentModel assignment)
        {
            
            context.Entry(assignment).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteAssignment(AssignmentModel assignment)
        {
           
            context.Entry(assignment).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}