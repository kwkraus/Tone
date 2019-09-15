﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tone.LibraryManagement.Data.Contexts;

namespace Tone.LibraryManagement.Data.Migrations
{
    [DbContext(typeof(LibraryMgmtContext))]
    partial class LibraryMgmtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.BookLibraryAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsCheckedOut");

                    b.Property<int?>("LibraryId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibraryId");

                    b.ToTable("BookLibraryAssociations");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.UserBookAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookLibraryAssociationId");

                    b.Property<DateTime>("DueDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookLibraryAssociationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBookAssociation");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.BookLibraryAssociation", b =>
                {
                    b.HasOne("Tone.LibraryManagement.Data.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Tone.LibraryManagement.Data.Entities.Library", "Library")
                        .WithMany()
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.User", b =>
                {
                    b.HasOne("Tone.LibraryManagement.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Tone.LibraryManagement.Data.Entities.UserBookAssociation", b =>
                {
                    b.HasOne("Tone.LibraryManagement.Data.Entities.BookLibraryAssociation", "BookLibraryAssociation")
                        .WithMany()
                        .HasForeignKey("BookLibraryAssociationId");

                    b.HasOne("Tone.LibraryManagement.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
