namespace EC.DataAccess.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentContent = c.Binary(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.ExaminationAnswers",
                c => new
                    {
                        ExaminationAnswerId = c.Int(nullable: false, identity: true),
                        ExaminationId = c.Int(nullable: false),
                        ExaminationQuestionId = c.Int(nullable: false),
                        Answer = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExaminationAnswerId)
                .ForeignKey("dbo.Examinations", t => t.ExaminationId)
                .ForeignKey("dbo.ExaminationQuestions", t => t.ExaminationQuestionId)
                .Index(t => t.ExaminationId)
                .Index(t => t.ExaminationQuestionId);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        ExaminationId = c.Int(nullable: false, identity: true),
                        ExaminationName = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExaminationId);
            
            CreateTable(
                "dbo.ExaminationQuestions",
                c => new
                    {
                        ExaminationQuestionId = c.Int(nullable: false, identity: true),
                        ExaminationId = c.Int(nullable: false),
                        ExaminationQuestionText = c.String(),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExaminationQuestionId)
                .ForeignKey("dbo.Examinations", t => t.ExaminationId)
                .Index(t => t.ExaminationId);
            
            CreateTable(
                "dbo.ScheduledTasks",
                c => new
                    {
                        ScheduledTaskId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Note = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduledTaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ScheduledTask_ScheduledTaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.ScheduledTasks", t => t.ScheduledTask_ScheduledTaskId)
                .Index(t => t.ScheduledTask_ScheduledTaskId);
            
            CreateTable(
                "dbo.ScheduledTaskTemplateContents",
                c => new
                    {
                        ScheduledTaskTemplateContentId = c.Int(nullable: false, identity: true),
                        ScheduledTaskId = c.Int(nullable: false),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ScheduledTaskTemplate_ScheduledTaskTemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduledTaskTemplateContentId)
                .ForeignKey("dbo.ScheduledTaskTemplates", t => t.ScheduledTaskTemplate_ScheduledTaskTemplateId)
                .Index(t => t.ScheduledTaskTemplate_ScheduledTaskTemplateId);
            
            CreateTable(
                "dbo.ScheduledTaskTemplates",
                c => new
                    {
                        ScheduledTaskTemplateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduledTaskTemplateId);
            
            CreateTable(
                "dbo.Theories",
                c => new
                    {
                        TheoryId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TheoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EMail = c.String(),
                        Phone = c.String(),
                        UserType = c.Int(nullable: false),
                        PWD = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduledTaskTemplateContents", "ScheduledTaskTemplate_ScheduledTaskTemplateId", "dbo.ScheduledTaskTemplates");
            DropForeignKey("dbo.Tasks", "ScheduledTask_ScheduledTaskId", "dbo.ScheduledTasks");
            DropForeignKey("dbo.ExaminationQuestions", "ExaminationId", "dbo.Examinations");
            DropForeignKey("dbo.ExaminationAnswers", "ExaminationQuestionId", "dbo.ExaminationQuestions");
            DropForeignKey("dbo.ExaminationAnswers", "ExaminationId", "dbo.Examinations");
            DropIndex("dbo.ScheduledTaskTemplateContents", new[] { "ScheduledTaskTemplate_ScheduledTaskTemplateId" });
            DropIndex("dbo.Tasks", new[] { "ScheduledTask_ScheduledTaskId" });
            DropIndex("dbo.ExaminationQuestions", new[] { "ExaminationId" });
            DropIndex("dbo.ExaminationAnswers", new[] { "ExaminationQuestionId" });
            DropIndex("dbo.ExaminationAnswers", new[] { "ExaminationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Theories");
            DropTable("dbo.ScheduledTaskTemplates");
            DropTable("dbo.ScheduledTaskTemplateContents");
            DropTable("dbo.Tasks");
            DropTable("dbo.ScheduledTasks");
            DropTable("dbo.ExaminationQuestions");
            DropTable("dbo.Examinations");
            DropTable("dbo.ExaminationAnswers");
            DropTable("dbo.Documents");
        }
    }
}
