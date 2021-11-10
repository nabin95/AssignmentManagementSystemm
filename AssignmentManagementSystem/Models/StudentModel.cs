using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        [ForeignKey("DepartmentModel")]
        public int DepartmentId { get; set; }
        public virtual DepartmentModel DepartmentModel { get; set; }
        public string Email { get; set; }
    }
    public class StudentActionModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DepartmentModel DepartmentModels { get; set; }
        public string Email { get; set; }
        public IEnumerable<DepartmentModel> Departments { get; set; }
       
    }
    public class StudentListingModel
    {
        public IEnumerable<StudentModel> Students { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
}