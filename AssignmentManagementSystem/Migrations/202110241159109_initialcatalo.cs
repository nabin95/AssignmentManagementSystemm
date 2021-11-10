namespace AssignmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcatalo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentModels",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        AssigmentMarksId = c.Int(nullable: false),
                        AssigmentStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.AssignmentMarksModels", t => t.AssigmentMarksId, cascadeDelete: true)
                .ForeignKey("dbo.AssignmentStatusModels", t => t.AssigmentStatusId, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.AssigmentMarksId)
                .Index(t => t.AssigmentStatusId);
            
            CreateTable(
                "dbo.AssignmentMarksModels",
                c => new
                    {
                        AssigmentMarksId = c.Int(nullable: false, identity: true),
                        AssigmentMarks = c.String(),
                    })
                .PrimaryKey(t => t.AssigmentMarksId);
            
            CreateTable(
                "dbo.AssignmentStatusModels",
                c => new
                    {
                        AssigmentStatusId = c.Int(nullable: false, identity: true),
                        AssigmentStatus = c.String(),
                    })
                .PrimaryKey(t => t.AssigmentStatusId);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.SubjectModels",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        FacultyId = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.FacultyModels", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.FacultyModels",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignmentModels", "TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.TeacherModels", "FacultyId", "dbo.FacultyModels");
            DropForeignKey("dbo.AssignmentModels", "SubjectId", "dbo.SubjectModels");
            DropForeignKey("dbo.AssignmentModels", "StudentId", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModels", "DepartmentId", "dbo.DepartmentModels");
            DropForeignKey("dbo.AssignmentModels", "AssigmentStatusId", "dbo.AssignmentStatusModels");
            DropForeignKey("dbo.AssignmentModels", "AssigmentMarksId", "dbo.AssignmentMarksModels");
            DropIndex("dbo.TeacherModels", new[] { "FacultyId" });
            DropIndex("dbo.StudentModels", new[] { "DepartmentId" });
            DropIndex("dbo.AssignmentModels", new[] { "AssigmentStatusId" });
            DropIndex("dbo.AssignmentModels", new[] { "AssigmentMarksId" });
            DropIndex("dbo.AssignmentModels", new[] { "TeacherId" });
            DropIndex("dbo.AssignmentModels", new[] { "SubjectId" });
            DropIndex("dbo.AssignmentModels", new[] { "StudentId" });
            DropTable("dbo.FacultyModels");
            DropTable("dbo.TeacherModels");
            DropTable("dbo.SubjectModels");
            DropTable("dbo.DepartmentModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.AssignmentStatusModels");
            DropTable("dbo.AssignmentMarksModels");
            DropTable("dbo.AssignmentModels");
        }
    }
}
