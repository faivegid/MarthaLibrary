﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using marthaLibrary.CoreData.AppContexts;

#nullable disable

namespace marthaLibrary.CoreData.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20230327131229_adding-seeding")]
    partial class addingseeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66cd4d2f-7f00-4c32-8e2b-697fbc968f55"),
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontPagePicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AuthorName = "Paulo Coelho",
                            BookName = "The Alchemist",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A shepherd boy travels to Egypt to find treasure and discovers his personal legend.",
                            FrontPagePicUrl = "https://example.com/alchemist.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            AuthorName = "Harper Lee",
                            BookName = "To Kill a Mockingbird",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A lawyer in the South defends a black man accused of rape.",
                            FrontPagePicUrl = "https://example.com/mockinbird.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 3L,
                            AuthorName = "F. Scott Fitzgerald",
                            BookName = "The Great Gatsby",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A wealthy man tries to win back his lost love in the Jazz Age.",
                            FrontPagePicUrl = "https://example.com/gatsby.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 4L,
                            AuthorName = "Jane Austen",
                            BookName = "Pride and Prejudice",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Bennet sisters navigate love and marriage in Georgian England.",
                            FrontPagePicUrl = "https://example.com/pride.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 5L,
                            AuthorName = "George Orwell",
                            BookName = "1984",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A man rebels against a totalitarian government that controls everything.",
                            FrontPagePicUrl = "https://example.com/1984.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 6L,
                            AuthorName = "J.D. Salinger",
                            BookName = "The Catcher in the Rye",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A teenage boy struggles with adolescence and the adult world.",
                            FrontPagePicUrl = "https://example.com/catcher.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 7L,
                            AuthorName = "J.R.R. Tolkien",
                            BookName = "The Hobbit",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A hobbit goes on an adventure to help reclaim a dwarven treasure.",
                            FrontPagePicUrl = "https://example.com/hobbit.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 8L,
                            AuthorName = "J.R.R. Tolkien",
                            BookName = "The Lord of the Rings",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Frodo Baggins carries the One Ring to Mount Doom to destroy it.",
                            FrontPagePicUrl = "https://example.com/lotr.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 9L,
                            AuthorName = "Douglas Adams",
                            BookName = "The Hitchhiker's Guide to the Galaxy",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A hapless human and his alien friend travel the galaxy in search of answers.",
                            FrontPagePicUrl = "https://example.com/hitchhiker.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 10L,
                            AuthorName = "Aldous Huxley",
                            BookName = "Brave New World",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A dystopian society controls citizens through conditioning and pleasure.",
                            FrontPagePicUrl = "https://example.com/brave.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 11L,
                            AuthorName = "Patrick Rothfuss",
                            BookName = "The Name of the Wind",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A legendary wizard tells his life story to a chronicler in a tavern.",
                            FrontPagePicUrl = "https://example.com/name-wind.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 12L,
                            AuthorName = "Stieg Larsson",
                            BookName = "The Girl with the Dragon Tattoo",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A journalist investigates a wealthy family and enlists the help of a computer hacker.",
                            FrontPagePicUrl = "https://example.com/dragon-tattoo.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 13L,
                            AuthorName = "Suzanne Collins",
                            BookName = "The Hunger Games",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Teenagers compete in a televised death match in a dystopian society.",
                            FrontPagePicUrl = "https://example.com/hunger-games.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 14L,
                            AuthorName = "Cormac McCarthy",
                            BookName = "The Road",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A father and son journey through a post-apocalyptic world.",
                            FrontPagePicUrl = "https://example.com/road.jpg",
                            IsDeleted = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 15L,
                            AuthorName = "Alexandre Dumas",
                            BookName = "The Count of Monte Cristo",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A man takes revenge on those who wronged him after being falsely imprisoned.",
                            FrontPagePicUrl = "https://example.com/monte-cristo.jpg",
                            IsDeleted = false,
                            Status = 0
                        });
                });

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.BookTransactionLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookLogs");
                });

            modelBuilder.Entity("marthaLibrary.CoreData.DatabaseModels.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notifcations");
                });
#pragma warning restore 612, 618
        }
    }
}
