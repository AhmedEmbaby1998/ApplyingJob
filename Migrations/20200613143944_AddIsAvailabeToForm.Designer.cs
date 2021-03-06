﻿// <auto-generated />
using System;
using JobApplying.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobApplying.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200613143944_AddIsAvailabeToForm")]
    partial class AddIsAvailabeToForm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApplying.Models.Applier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplyingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EnglishGrade")
                        .HasColumnType("float");

                    b.Property<double>("ExpectedSalary")
                        .HasColumnType("float");

                    b.Property<string>("Government")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraduatingFaculty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GraduatingGrade")
                        .HasColumnType("int");

                    b.Property<int>("GraduatingYear")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<double>("MicrosoftOfficeGrade")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Appliers");
                });

            modelBuilder.Entity("JobApplying.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplierId")
                        .HasColumnType("int");

                    b.Property<string>("ExperienceItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplierId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobApplying.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Pos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("JobApplying.Models.PreviousWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplierId")
                        .HasColumnType("int");

                    b.Property<string>("LeftReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplierId");

                    b.ToTable("PreviousWorks");
                });

            modelBuilder.Entity("JobApplying.Models.Applier", b =>
                {
                    b.HasOne("JobApplying.Models.Position", "Position")
                        .WithMany("Appliers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobApplying.Models.Experience", b =>
                {
                    b.HasOne("JobApplying.Models.Applier", "Applier")
                        .WithMany("Experiences")
                        .HasForeignKey("ApplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobApplying.Models.PreviousWork", b =>
                {
                    b.HasOne("JobApplying.Models.Applier", "Applier")
                        .WithMany("PreviousWorks")
                        .HasForeignKey("ApplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
