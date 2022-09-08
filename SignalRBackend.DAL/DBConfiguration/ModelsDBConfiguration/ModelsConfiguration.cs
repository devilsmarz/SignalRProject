using Microsoft.EntityFrameworkCore;
using SignalRBackend.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

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

            modelBuilder.Entity<Chat>().HasData(new Chat 
            { Name = "eff", Id = 1 });
            modelBuilder.Entity<Chat>().HasMany(p => p.Users).WithMany(p => p.Chats).UsingEntity(j => j.HasData(
                new { ChatsId = 1, UsersId = 1 },
                new { ChatsId = 1, UsersId = 2 },
                new { ChatsId = 1, UsersId = 3 }));
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
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Message>()
                   .HasOne(s => s.Receiver)
                   .WithMany(s => s.Messages)
                   .HasForeignKey(s => s.ReceiverId);

        }
    }
}
