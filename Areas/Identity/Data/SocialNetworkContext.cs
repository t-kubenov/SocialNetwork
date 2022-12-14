using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Areas.Identity.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Data;

public class SocialNetworkContext : IdentityDbContext<SocialNetworkUser>
{
    public DbSet<CommunityDB> Communities { get; set; }
    public DbSet<FriendsDB> Friendships { get; set; }
    public DbSet<CommunityMemberDB> CommunityMembers { get; set; }

    public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
