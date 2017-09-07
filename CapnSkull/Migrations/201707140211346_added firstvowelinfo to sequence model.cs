namespace CapnSkull.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedfirstvowelinfotosequencemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sequences", "FirstVowelInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sequences", "FirstVowelInfo");
        }
    }
}
