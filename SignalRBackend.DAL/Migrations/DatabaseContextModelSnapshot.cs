﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;

namespace SignalRBackend.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<int>("ChatsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatUser");

                    b.HasData(
                        new
                        {
                            ChatsId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            ChatsId = 1,
                            UsersId = 2
                        },
                        new
                        {
                            ChatsId = 1,
                            UsersId = 3
                        },
                        new
                        {
                            ChatsId = 2,
                            UsersId = 1
                        },
                        new
                        {
                            ChatsId = 2,
                            UsersId = 2
                        },
                        new
                        {
                            ChatsId = 3,
                            UsersId = 2
                        },
                        new
                        {
                            ChatsId = 3,
                            UsersId = 3
                        },
                        new
                        {
                            ChatsId = 4,
                            UsersId = 1
                        },
                        new
                        {
                            ChatsId = 4,
                            UsersId = 3
                        });
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.Chat", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChatType = 0,
                            Name = "GroupChat"
                        },
                        new
                        {
                            Id = 2,
                            ChatType = 1,
                            Name = "PrivateChat"
                        },
                        new
                        {
                            Id = 3,
                            ChatType = 1,
                            Name = "PrivateChat"
                        },
                        new
                        {
                            Id = 4,
                            ChatType = 1,
                            Name = "PrivateChat"
                        });
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.Message", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActivityDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("isDeletedOnlyForCreator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "Ann"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "Ludwig"
                        },
                        new
                        {
                            Id = 3,
                            UserName = "Alex"
                        });
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("SignalRBackend.DAL.DomainModels.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalRBackend.DAL.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.Message", b =>
                {
                    b.HasOne("SignalRBackend.DAL.DomainModels.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalRBackend.DAL.DomainModels.User", "Receiver")
                        .WithMany("Messages")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("SignalRBackend.DAL.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Receiver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("SignalRBackend.DAL.DomainModels.User", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
