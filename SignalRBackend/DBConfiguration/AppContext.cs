using Microsoft.EntityFrameworkCore;
using SignalRBackend.Entities;

namespace SignalRBackend.DBConfiguration
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public AppContext(DbContextOptions<AppContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\DESKTOP-FCQK9JB;Database=chatdb;Trusted_Connection=True;");
        }

    }
}
