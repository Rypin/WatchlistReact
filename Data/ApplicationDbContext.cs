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
            //create m-m relationship for user>user (followers)
            builder.Entity<Followers>()
                .HasOne(f => f.Follower)
                .WithMany(f=>f.FollowedAccounts)
                .HasForeignKey(fol => fol.FollowerId);
            builder.Entity<Followers>()
                .HasOne(f => f.FollowedAccount)
                .WithMany(fo => fo.Followers)
                .HasForeignKey(fol => fol.AccountId);
            // 1-m relationship for user>watchlist
            builder.Entity<Watchlist>()
                .HasOne(f => f.User)
                .WithMany(f => f.Watchlists);
            //M-M for Watchlist>Show
            builder.Entity<WatchlistShow>()
                .HasOne(f => f.Show)
                .WithMany(f => f.Watchlists)
                .HasForeignKey(f => f.WatchlistId);
            builder.Entity<WatchlistShow>()
                .HasOne(f => f.Watchlist)
                .WithMany(f => f.Shows)
                .HasForeignKey(f => f.ShowId);
            //1-M for User>ShowStatus and Shows>ShowStatus
            builder.Entity<ShowStatus>()
                .HasOne(f => f.User)
                .WithMany(f => f.ShowStatuses)
                .HasForeignKey(f => f.UserId);
            builder.Entity<ShowStatus>()
                .HasOne(f => f.Show)
                .WithMany(f => f.ShowStatuses)
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