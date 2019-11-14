namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'081ca98d-2b63-4799-9e73-29a6147522cc', N'teste@gmail.com', 0, N'ACZ6nvZk3YN1fqiBQcvFCawa3l7xDl6b9tPVuwFKNwhYhSmGSpWAVXMo0uHj/VyITA==', N'd5a46842-c31c-45f2-a3b5-6047e22977f3', NULL, 0, 0, NULL, 1, 0, N'teste@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b6e9d7a7-d98e-4bec-8a1e-14fd12173874', N'admin@gmail.com', 0, N'AB5NeubdESQ0tyct74xD7FEapqJ3yEH82rYGjsKi7L/4Ph6fTuH+lskp6axZuQHw8w==', N'699af925-70d3-4658-911c-e75bd6e3f477', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b2a77bae-a7ea-43cd-8a28-48a170e99a42', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b6e9d7a7-d98e-4bec-8a1e-14fd12173874', N'b2a77bae-a7ea-43cd-8a28-48a170e99a42')
");
        }
        
        public override void Down()
        {
        }
    }
}
