using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalRBackend.DAL.DBConfiguration.ModelsDBConfiguration;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfiguration.ConfigureAll(modelBuilder);

        }
    }
}
