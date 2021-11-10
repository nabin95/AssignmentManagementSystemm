namespace AssignmentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjectModels",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.TeacherSubjectModels",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjectModels", "TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.TeacherSubjectModels", "SubjectId", "dbo.SubjectModels");
            DropForeignKey("dbo.StudentSubjectModels", "TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.StudentSubjectModels", "SubjectId", "dbo.SubjectModels");
            DropIndex("dbo.TeacherSubjectModels", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjectModels", new[] { "TeacherId" });
            DropIndex("dbo.StudentSubjectModels", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjectModels", new[] { "TeacherId" });
            DropTable("dbo.TeacherSubjectModels");
            DropTable("dbo.StudentSubjectModels");
        }
    }
}
