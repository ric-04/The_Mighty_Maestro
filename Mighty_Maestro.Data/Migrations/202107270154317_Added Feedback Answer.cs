namespace Mighty_Maestro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeedbackAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedback", "FeedbackAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedback", "FeedbackAnswer");
        }
    }
}
