namespace Mighty_Maestro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TEST : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MaestroId = c.Int(nullable: false),
                        AnswerQuestion = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Maestro", t => t.MaestroId, cascadeDelete: false)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: false)
                .Index(t => t.MaestroId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Maestro",
                c => new
                    {
                        MaestroId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MaestroName = c.String(),
                        TotalPoints = c.Int(nullable: false),
                        ScalesPoints = c.Int(nullable: false),
                        ChordsPoints = c.Int(nullable: false),
                        KeysPoints = c.Int(nullable: false),
                        ProgressionsPoints = c.Int(nullable: false),
                        VenueAchieved = c.String(),
                        Password = c.String(),
                        VenueId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaestroId)
                .ForeignKey("dbo.Instructor", t => t.ProfessorId, cascadeDelete: false)
                .ForeignKey("dbo.Venue", t => t.VenueId, cascadeDelete: false)
                .Index(t => t.VenueId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Stage = c.Int(nullable: false),
                        Name = c.String(),
                        PointsRequired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VenueId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        QuestionQuestion = c.String(),
                        QuestionPoints = c.Int(nullable: false),
                        GenreType = c.Int(nullable: false),
                        VenueName = c.Int(nullable: false),
                        Venue_VenueId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Venue", t => t.Venue_VenueId)
                .Index(t => t.Venue_VenueId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        CorrectAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Answer", t => t.AnswerId, cascadeDelete: false)
                .ForeignKey("dbo.Instructor", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.TeacherId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Feedback", "TeacherId", "dbo.Instructor");
            DropForeignKey("dbo.Feedback", "AnswerId", "dbo.Answer");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Answer", "MaestroId", "dbo.Maestro");
            DropForeignKey("dbo.Maestro", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.Question", "Venue_VenueId", "dbo.Venue");
            DropForeignKey("dbo.Maestro", "ProfessorId", "dbo.Instructor");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Feedback", new[] { "AnswerId" });
            DropIndex("dbo.Feedback", new[] { "TeacherId" });
            DropIndex("dbo.Question", new[] { "Venue_VenueId" });
            DropIndex("dbo.Maestro", new[] { "ProfessorId" });
            DropIndex("dbo.Maestro", new[] { "VenueId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropIndex("dbo.Answer", new[] { "MaestroId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Feedback");
            DropTable("dbo.Question");
            DropTable("dbo.Venue");
            DropTable("dbo.Instructor");
            DropTable("dbo.Maestro");
            DropTable("dbo.Answer");
        }
    }
}
