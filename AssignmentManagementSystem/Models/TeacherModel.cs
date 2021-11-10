using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class TeacherModel
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        [ForeignKey("FacultyModel")]
        public int FacultyId { get; set; }
        public  virtual FacultyModel FacultyModel { get; set; }
        public string Email { get; set; }
    }
    public class TeacherListingModel
    {
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }

    }
    public class TeacherActionModel
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
      
        public int FacultyId { get; set; }
        public FacultyModel FacultyModel { get; set; }
        public string Email { get; set; }
        public IEnumerable<FacultyModel> Faculty { get; set; }
    }
}