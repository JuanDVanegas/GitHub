namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "__mig_tmp__0", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "__mig_tmp__0", newName: "IX_FollowerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.Followings", name: "__mig_tmp__0", newName: "IX_FolloweeId");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "FolloweeId");
            RenameColumn(table: "dbo.Followings", name: "__mig_tmp__0", newName: "FollowerId");
        }
    }
}
