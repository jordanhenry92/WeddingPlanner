namespace WeddingPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPersonToAttendee : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Attendees");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Attendees", newName: "People");
        }
    }
}
