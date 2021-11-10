using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentManagementSystem.Models
{
    public class AssignmentModel
    {
        [Key]
        public int AssignmentId { get; set; }
        [ForeignKey("StudentModel")]
        public int StudentId { get; set; }
        public virtual StudentModel StudentModel { get; set; }
        [ForeignKey("SubjectModel")]
        public int SubjectId { get; set; }
        public virtual SubjectModel SubjectModel { get; set; }
        [ForeignKey("TeacherModel")]
        public int TeacherId { get; set; }
        public virtual TeacherModel TeacherModel { get; set; }
        [ForeignKey("AssignmentMarksModel")]
        public int AssigmentMarksId { get; set; }
        public virtual AssignmentMarksModel AssignmentMarksModel { get; set; }
        [ForeignKey("AssignmentStatusModel")]
        public int AssigmentStatusId { get; set; }
        public virtual AssignmentStatusModel AssignmentStatusModel { get; set; }

    }
    public class AssignmentMarksModel
    {
        [Key]
        public int AssigmentMarksId { get; set; }
        public string AssigmentMarks { get; set; }
    }
    public class AssignmentStatusModel
    {
        [Key]
        public int AssigmentStatusId { get; set; }
        public string AssigmentStatus { get; set; }
    }
 
    public class AssignmentActionModel
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public virtual StudentModel StudentModel { get; set; }
        
        public int SubjectId { get; set; }
        public virtual SubjectModel SubjectModel { get; set; }
    
        public int TeacherId { get; set; }
        public virtual TeacherModel TeacherModel { get; set; }
       
        public int AssigmentMarksId { get; set; }
        public virtual AssignmentMarksModel AssignmentMarksModel { get; set; }
       
        public int AssigmentStatusId { get; set; }
        public virtual AssignmentStatusModel AssignmentStatusModel { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }
        public IEnumerable<AssignmentStatusModel> AssignmentStatus { get; set; }
        public IEnumerable<AssignmentMarksModel> AssignmentMarks { get; set; }
    }
    public class AssignmentListingModel
    {
        public IEnumerable<AssignmentModel> Assignments { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class AssignmentStatusListingModel
    {
        public IEnumerable<AssignmentStatusModel> AssignmentStatus { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class AssignmentStatusActionModel
    {
        public int AssigmentStatusId { get; set; }
        public string AssigmentStatus { get; set; }
    }
    public class AssignmentMarkListingModel
    {
        public IEnumerable<AssignmentMarksModel> AssignmentMarks { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class AssignmentMarkActionModel
    {
        public int AssigmentMarksId { get; set; }
        public string AssigmentMarks { get; set; }
    }
}