namespace AssignmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initailAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjectModels", "TeacherId", "dbo.TeacherModels");
            DropIndex("dbo.StudentSubjectModels", new[] { "TeacherId" });
            DropPrimaryKey("dbo.StudentSubjectModels");
            AddColumn("dbo.StudentSubjectModels", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentSubjectModels", "StudentId");
            CreateIndex("dbo.StudentSubjectModels", "StudentId");
            AddForeignKey("dbo.StudentSubjectModels", "StudentId", "dbo.StudentModels", "StudentId");
            DropColumn("dbo.StudentSubjectModels", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentSubjectModels", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentSubjectModels", "StudentId", "dbo.StudentModels");
            DropIndex("dbo.StudentSubjectModels", new[] { "StudentId" });
            DropPrimaryKey("dbo.StudentSubjectModels");
            DropColumn("dbo.StudentSubjectModels", "StudentId");
            AddPrimaryKey("dbo.StudentSubjectModels", "TeacherId");
            CreateIndex("dbo.StudentSubjectModels", "TeacherId");
            AddForeignKey("dbo.StudentSubjectModels", "TeacherId", "dbo.TeacherModels", "TeacherId");
        }
    }
}
