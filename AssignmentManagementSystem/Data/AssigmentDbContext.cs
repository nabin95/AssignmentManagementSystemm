using AssignmentManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AssignmentManagementSystem.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class AssigmentDbContext :IdentityDbContext<ApplicationUser>
    {
        public AssigmentDbContext() :base("MainConnection")
        {

        }
        public static AssigmentDbContext Create()
        {
            return new AssigmentDbContext();
        }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<TeacherModel> Teacher { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<FacultyModel> Faculty { get; set; }
        public DbSet<SubjectModel> Subject { get; set; }
        public DbSet<AssignmentModel> Assigment { get; set; }
        public DbSet<TeacherSubjectModel> TeacherSubjectModels { get; set; }
        public DbSet<StudentSubjectModel> StudentSubjectModels { get; set; }
        public DbSet<AssignmentStatusModel> AssignmentStatus { get; set; }
        public DbSet<AssignmentMarksModel> AssignmentMarks { get; set; }
    }
   

}