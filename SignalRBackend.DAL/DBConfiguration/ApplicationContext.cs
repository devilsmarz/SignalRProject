using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalRBackend.DAL.Entities;
using System;

namespace SignalRBackend.DAL.DBConfiguration
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            String connection = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(s => s.UserName)
                    .HasMaxLength(32)                   
                    .IsRequired(true);

            modelBuilder.Entity<Chat>()
                    .Property(s => s.Name)
                    .HasMaxLength(128)
                    .IsRequired(true);

            modelBuilder.Entity<Message>()
                    .Property(s => s.MessageText)
                    .HasMaxLength(4096)
                    .IsRequired(true);
        }
    }
}
