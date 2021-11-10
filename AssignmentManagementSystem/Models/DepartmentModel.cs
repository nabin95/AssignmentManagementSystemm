using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class DepartmentListingModel
    {
        public IEnumerable<DepartmentModel> Departments { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class DepartmentActionModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}