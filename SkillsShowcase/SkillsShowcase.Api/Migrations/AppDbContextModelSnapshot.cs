﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillsShowcase.Api.Models.Data;

#nullable disable

namespace SkillsShowcase.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillsShowcase.Shared.Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Email = "Devonpaniccia@gmail.com",
                            FirstName = "Devon",
                            Gender = 0,
                            LastName = "Rismay",
                            MaritalStatus = 0,
                            PhoneNumber = "8322156677"
                        });
                });

            modelBuilder.Entity("SkillsShowcase.Shared.Domain.Models.EmployeeSecretKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeSecretKeys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeName = "Devon Rismay",
                            SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5555"
                        },
                        new
                        {
                            Id = 2,
                            EmployeeName = "John Hull",
                            SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5554"
                        },
                        new
                        {
                            Id = 3,
                            EmployeeName = "Quinshae Hopkins",
                            SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5553"
                        },
                        new
                        {
                            Id = 4,
                            EmployeeName = "Robert Pyron",
                            SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5552"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
