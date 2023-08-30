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
            builder.Entity<WatchlistShow>()
                .HasOne(f => f.Show)
                .WithMany(f => f.Watchlists)
                .HasForeignKey(f => f.WatchlistId);
            builder.Entity<WatchlistShow>()
                .HasOne(f => f.Watchlist)
                .WithMany(f => f.Shows)
                .HasForeignKey(f => f.ShowId);
        }
        public DbSet<Followers> Follows { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Show> Shows { get; set; }

    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //Configure user here
    }
}