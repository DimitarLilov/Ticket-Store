namespace TicketStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TicketStore.Data.Models;

    public class TicketStoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public TicketStoreDbContext(DbContextOptions<TicketStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigureUserIdentityRelations(builder);
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserTickets>()
                .HasKey(ut => new { ut.UserId, ut.TicketId });

            builder.Entity<UserTickets>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(ut => ut.UserId);

            builder.Entity<UserTickets>()
                .HasOne(ut => ut.Ticket)
                .WithMany(t => t.Users)
                .HasForeignKey(ut => ut.TicketId);
        }
    }
}
