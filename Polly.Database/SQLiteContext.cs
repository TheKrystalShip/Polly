using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using TheKrystalShip.Polly.Database.Models;

namespace TheKrystalShip.Polly.Database
{
    public class SQLiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User);

            builder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages);
        }
    }
}
