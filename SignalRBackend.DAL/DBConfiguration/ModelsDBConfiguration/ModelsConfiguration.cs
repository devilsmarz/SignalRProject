using Microsoft.EntityFrameworkCore;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.DAL.DBConfiguration.ModelsDBConfiguration
{
    public static class ModelsConfiguration
    {
        public static void ConfigureAll(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureChat(modelBuilder);
            ConfigureMessage(modelBuilder);
        }
        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.UserName)
                .HasMaxLength(32)
                .IsRequired(true);

            modelBuilder.Entity<User>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Ann" },
                new User { Id = 2, UserName = "Ludwig" },
                new User { Id = 3, UserName = "Alex" }
            );
        }

        private static void ConfigureChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .Property(s => s.Name)
                .HasMaxLength(128)
                .IsRequired(true);


            modelBuilder.Entity<Chat>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Chat>().HasData(
                new Chat { Name = "GroupChat", Id = 1, ChatType = 0 },
                new Chat { Name = "PrivateChat", Id = 2, ChatType = 1 },
                new Chat { Name = "PrivateChat", Id = 3, ChatType = 1 },
                new Chat { Name = "PrivateChat", Id = 4, ChatType = 1 });

            modelBuilder.Entity<Chat>().HasMany(p => p.Users).WithMany(p => p.Chats).UsingEntity(j => j.HasData(
                new { ChatsId = 1, UsersId = 1 },
                new { ChatsId = 1, UsersId = 2 },
                new { ChatsId = 1, UsersId = 3 },

                new { ChatsId = 2, UsersId = 1 },
                new { ChatsId = 2, UsersId = 2 },

                new { ChatsId = 3, UsersId = 2 },
                new { ChatsId = 3, UsersId = 3 },

                new { ChatsId = 4, UsersId = 1 },
                new { ChatsId = 4, UsersId = 3 }));
        }
        private static void ConfigureMessage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(s => s.MessageText)
                .HasMaxLength(4096)
                .IsRequired(true);


            modelBuilder.Entity<Message>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Message>()
                .Property(s => s.ActivityDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired(true);

            modelBuilder.Entity<Message>()
                .HasOne(s => s.Receiver)
                .WithMany(s => s.Messages)
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(s => s.RepliedMessage)
                .WithMany(s => s.RepliedMessages)
                .HasForeignKey(s => s.RepliedMessageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .Property(s => s.IsDeletedOnlyForCreator)
                .HasDefaultValue(false)
                .IsRequired(true);

            modelBuilder.Entity<Message>()
               .Property(s => s.UserName)
               .HasMaxLength(32)
               .IsRequired(true);
        }
    }
}
