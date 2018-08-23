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
        private readonly IConfiguration _config;
        public SQLiteContext(IConfiguration config) : base()
        {
            _config = config;
        }

        public void Migrate() => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(_config.GetConnectionString("SQLite"));
        }
    }
}
