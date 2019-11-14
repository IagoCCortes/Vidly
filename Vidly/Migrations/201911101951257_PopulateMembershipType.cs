namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) values (1, 0, 0, 0, 'Pay as You Go')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) values (2, 30, 1, 10, 'Monthly')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) values (3, 90, 3, 15, 'Quarterly')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) values (4, 300, 12, 20, 'Annual')");
        }
        
        public override void Down()
        {
        }
    }
}
