namespace BugSquash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5f6ccf24-a177-412c-b200-07eb37509fb5', N'admin@bugsquash.com', 0, N'AHjBqbzbeQmwtkeKteT9OTHVj0yrOlrmy++FgjR1vvFWuytYiEanC5+kmIwpUpYHGg==', N'bd511ba0-76c3-440f-b51d-1fb9ff3a315d', NULL, 0, 0, NULL, 1, 0, N'admin@bugsquash.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5bdff51-92a9-484e-bd9e-9edd073120ba', N'guest@bugsquash.com', 0, N'AAp4BvVN+gJjdX0LNgZwN+wSBS3GmVRO4G0zpIMSkMo49bm2jjpX9+E1VoWVk2eVRw==', N'aeec24a0-cef6-433f-9383-aa45af4da3c2', NULL, 0, 0, NULL, 1, 0, N'guest@bugsquash.com')


            INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'5342b6b9-f1fc-4d4d-ae34-924c45110663', N'CanManageTickets')


                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f6ccf24-a177-412c-b200-07eb37509fb5', N'5342b6b9-f1fc-4d4d-ae34-924c45110663')
");

        }

        public override void Down()
        {
        }
    }
}
