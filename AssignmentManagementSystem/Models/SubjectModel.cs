using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class SubjectModel
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
       
    }
 
    public class TeacherSubjectModel
    {
        [Key]
        [ForeignKey("TeacherModel")]
        public int TeacherId { get; set; }
        public TeacherModel TeacherModel { get; set; }
        [ForeignKey("SubjectModel")]
        public int SubjectId { get; set; }
        public SubjectModel SubjectModel { get; set; }
    }
    public class StudentSubjectModel
    {
        [Key]
        [ForeignKey("StudentModel")]
        public int StudentId { get; set; }
        public StudentModel StudentModel { get; set; }
        [ForeignKey("SubjectModel")]
        public int SubjectId { get; set; }
        public SubjectModel SubjectModel { get; set; }
    }
    public class SubjectListingModel
    {
        public IEnumerable<SubjectModel> Subjects { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class SubjectActionModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}