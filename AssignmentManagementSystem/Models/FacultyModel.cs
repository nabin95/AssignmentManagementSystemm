using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class FacultyModel
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
    public class FacultyListingModel
    {
        public IEnumerable<FacultyModel> Faculties { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class FacultyActionModel
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
}