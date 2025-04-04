﻿// <auto-generated />
using System;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace REST_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250404183534_EntitiesFixes")]
    partial class EntitiesFixes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Domain.Aggregates.Book", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSeries")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PreviousPartOfSeriesKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.HasIndex("PreviousPartOfSeriesKey");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Loan", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("ProlongTimes")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Key");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Person", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Key");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Type").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Library.Domain.Aggregates.User", b =>
                {
                    b.HasBaseType("Library.Domain.Aggregates.Person");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Worker", b =>
                {
                    b.HasBaseType("Library.Domain.Aggregates.Person");

                    b.Property<string>("EmployeeCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Book", b =>
                {
                    b.HasOne("Library.Domain.Aggregates.Book", "PreviousPartOfSeries")
                        .WithMany()
                        .HasForeignKey("PreviousPartOfSeriesKey");

                    b.Navigation("PreviousPartOfSeries");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Loan", b =>
                {
                    b.HasOne("Library.Domain.Aggregates.Book", "Book")
                        .WithOne("Loan")
                        .HasForeignKey("Library.Domain.Aggregates.Loan", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Aggregates.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.Book", b =>
                {
                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Library.Domain.Aggregates.User", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
