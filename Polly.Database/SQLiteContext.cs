using Microsoft.EntityFrameworkCore;

using TheKrystalShip.Polly.Database.Models;

namespace TheKrystalShip.Polly.Database
{
    public class SQLiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<Server> Servers { get; set; }

        public SQLiteContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User);

            builder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages);

            builder.Entity<User>()
                .HasMany(u => u.Servers)
                .WithOne(s => s.User);

            builder.Entity<Server>()
                .HasOne(s => s.User)
                .WithMany(u => u.Servers);

            builder.Entity<Guild>()
                .HasMany(g => g.Servers)
                .WithOne(s => s.Guild);

            builder.Entity<Server>()
                .HasOne(s => s.Guild)
                .WithMany(g => g.Servers);
        }
    }
}
