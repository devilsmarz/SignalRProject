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

            modelBuilder.Entity<Chat>()
                    .Property(s => s.Id)
                    .ValueGeneratedOnAdd();
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
        }
    }
}
