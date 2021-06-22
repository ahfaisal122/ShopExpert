namespace ShopEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Gender], [Name], [Utype], [ShopExpertId]) VALUES (N'4b91f4c4-ceb7-4d39-a469-372cb9c767a7', N'admin@ShopExpert.com', 0, N'AIq6I5N8WyCZIZCqF3mLQMJjibi/fBgD3em3mqWDiL8ke68cLrDexE80GySillA1lw==', N'80170eb6-b5cb-4f87-845f-2f453100cad6', NULL, 0, 0, NULL, 1, 0, N'admin@ShopExpert.com', N'User', N'ShopExpertAdmin', N'User', N'Admin')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Gender], [Name], [Utype], [ShopExpertId]) VALUES (N'5c5f99f9-a5d0-44c1-88c8-72d71a5222e6', N'bintu3003@gmail.com', 0, N'AOERZYavHCa/I6wejMvOyFexXrVBE4PlwkAaLjTHzWjgDu24fMCON9n+EWVYrROvmA==', N'8e05751d-982b-4165-a3c8-facc3a272584', NULL, 0, 0, NULL, 1, 0, N'bintu3003@gmail.com', N'User', N'Oishee Bintey Hoque', N'User', N'bintu3003')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Gender], [Name], [Utype], [ShopExpertId]) VALUES (N'e2907562-b376-4a17-8ada-79544cf7fd65', N'orka@gmai.com', 0, N'APJ3uV9MNMqLXXOTa7Ph+lE0wsg4hVt+ImoKTMg7sMqCInSq19BgV7oqYvTCAZm0YA==', N'5035cee7-2893-4703-a1b3-49ed8d6d3200', NULL, 0, 0, NULL, 1, 0, N'orka@gmai.com', N'PageOwner', N'Orka', N'User', N'BdB')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd6128a60-5007-4b01-a4bf-88ad1dc0b81c', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'72acb5f3-5d39-4423-a649-576bde8636a0', N'Owner')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2907562-b376-4a17-8ada-79544cf7fd65', N'72acb5f3-5d39-4423-a649-576bde8636a0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4b91f4c4-ceb7-4d39-a469-372cb9c767a7', N'd6128a60-5007-4b01-a4bf-88ad1dc0b81c')


              

             ");

        }

    public override void Down()
        {
        }
    }
}
