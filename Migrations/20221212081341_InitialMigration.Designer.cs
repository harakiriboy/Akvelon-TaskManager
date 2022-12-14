// <auto-generated />
using System;
using Akvelon_Task_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Akvelon_Task_Manager.Migrations
{
    [DbContext(typeof(AkvelonTaskManagerDbContext))]
    [Migration("20221212081341_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Akvelon_Task_Manager.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectPriority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompletionDate = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Web Api Project",
                            ProjectPriority = 1,
                            ProjectStatus = 0,
                            StartDate = new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CompletionDate = new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Client Server Project",
                            ProjectPriority = 2,
                            ProjectStatus = 0,
                            StartDate = new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CompletionDate = new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Machine Learning Project",
                            ProjectPriority = 3,
                            ProjectStatus = 0,
                            StartDate = new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Akvelon_Task_Manager.Data.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectId = 2,
                            TaskName = "Create Models",
                            TaskPriority = 1,
                            TaskStatus = 0
                        },
                        new
                        {
                            Id = 2,
                            ProjectId = 3,
                            TaskName = "Collect Dataset",
                            TaskPriority = 2,
                            TaskStatus = 0
                        },
                        new
                        {
                            Id = 3,
                            ProjectId = 1,
                            TaskName = "Create From CLI",
                            TaskPriority = 3,
                            TaskStatus = 0
                        });
                });

            modelBuilder.Entity("Akvelon_Task_Manager.Data.Models.Task", b =>
                {
                    b.HasOne("Akvelon_Task_Manager.Data.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Akvelon_Task_Manager.Data.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
