using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using WatchlistReact.Models;

namespace WatchlistReact.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Followers>()
                .HasOne(f => f.Follower)
                .WithMany(f=>f.FollowedAccounts)
                .HasForeignKey(fol => fol.FollowerId);
            builder.Entity<Followers>()
                .HasOne(f => f.FollowedAccount)
                .WithMany(fo => fo.Followers)
                .HasForeignKey(fol => fol.AccountId);
        }
        public DbSet<Followers> Follows { get; set; }
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //Configure user here
    }
}