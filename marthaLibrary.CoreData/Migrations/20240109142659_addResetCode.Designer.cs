﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using marthaLibrary.CoreData.AppContexts;

#nullable disable

namespace marthaLibrary.CoreData.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240109142659_addResetCode")]
    partial class addResetCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00578bef-97e5-48ff-871c-19151e2e35af"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "martha@elibrary.com",
                            IsDeleted = false,
                            Name = "Martha Admin",
                            PasswordHash = "$2a$11$YRh/zfwN/M/zHX6ZdtOuY.YmlE1F0A8Une6DbIbPS2fNBMd26RI5G",
                            Role = 1
                        });
                });

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Authors")
                        .HasColumnType("text");

                    b.Property<string>("BookName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<string>("FrontPagePicUrl")
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Langauge")
                        .HasColumnType("text");

                    b.Property<int>("NoOfPages")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BookName = "The Alchemist",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A shepherd boy travels to Egypt to find treasure and discovers his personal legend.",
                            FrontPagePicUrl = "https://example.com/alchemist.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            BookName = "To Kill a Mockingbird",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A lawyer in the South defends a black man accused of rape.",
                            FrontPagePicUrl = "https://example.com/mockinbird.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 3L,
                            BookName = "The Great Gatsby",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A wealthy man tries to win back his lost love in the Jazz Age.",
                            FrontPagePicUrl = "https://example.com/gatsby.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 4L,
                            BookName = "Pride and Prejudice",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Bennet sisters navigate love and marriage in Georgian England.",
                            FrontPagePicUrl = "https://example.com/pride.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 5L,
                            BookName = "1984",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A man rebels against a totalitarian government that controls everything.",
                            FrontPagePicUrl = "https://example.com/1984.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 6L,
                            BookName = "The Catcher in the Rye",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A teenage boy struggles with adolescence and the adult world.",
                            FrontPagePicUrl = "https://example.com/catcher.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 7L,
                            BookName = "The Hobbit",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A hobbit goes on an adventure to help reclaim a dwarven treasure.",
                            FrontPagePicUrl = "https://example.com/hobbit.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 8L,
                            BookName = "The Lord of the Rings",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Frodo Baggins carries the One Ring to Mount Doom to destroy it.",
                            FrontPagePicUrl = "https://example.com/lotr.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 9L,
                            BookName = "The Hitchhiker's Guide to the Galaxy",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A hapless human and his alien friend travel the galaxy in search of answers.",
                            FrontPagePicUrl = "https://example.com/hitchhiker.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 10L,
                            BookName = "Brave New World",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A dystopian society controls citizens through conditioning and pleasure.",
                            FrontPagePicUrl = "https://example.com/brave.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 11L,
                            BookName = "The Name of the Wind",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A legendary wizard tells his life story to a chronicler in a tavern.",
                            FrontPagePicUrl = "https://example.com/name-wind.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 12L,
                            BookName = "The Girl with the Dragon Tattoo",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A journalist investigates a wealthy family and enlists the help of a computer hacker.",
                            FrontPagePicUrl = "https://example.com/dragon-tattoo.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 13L,
                            BookName = "The Hunger Games",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Teenagers compete in a televised death match in a dystopian society.",
                            FrontPagePicUrl = "https://example.com/hunger-games.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 14L,
                            BookName = "The Road",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A father and son journey through a post-apocalyptic world.",
                            FrontPagePicUrl = "https://example.com/road.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        },
                        new
                        {
                            Id = 15L,
                            BookName = "The Count of Monte Cristo",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DatePublished = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A man takes revenge on those who wronged him after being falsely imprisoned.",
                            FrontPagePicUrl = "https://example.com/monte-cristo.jpg",
                            IsDeleted = false,
                            NoOfPages = 0,
                            Status = 0
                        });
                });

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.BookTransactionLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("BookName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookLogs");
                });

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("BookName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("NotificationStatus")
                        .HasColumnType("integer");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notifcations");
                });
#pragma warning restore 612, 618
        }
    }
}