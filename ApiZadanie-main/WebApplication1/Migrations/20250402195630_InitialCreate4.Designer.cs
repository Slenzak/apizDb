﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20250402195630_InitialCreate4")]
    partial class InitialCreate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskCategoryAssignment", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("TaskCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "TaskCategoryId");

                    b.HasIndex("TaskCategoryId");

                    b.ToTable("TaskCategoryAssignments");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskCattegory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TaskCattegories");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskPiority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Piority")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaskPiorities");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskTag", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TaskTag");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TaskTags");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.UserTask", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("WebApplication1.Models.Comment", b =>
                {
                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskCategoryAssignment", b =>
                {
                    b.HasOne("WebApplication1.Models.TaskCattegory", "TaskCategory")
                        .WithMany("TaskCategoryAssignments")
                        .HasForeignKey("TaskCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany("TaskCategoryAssignments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("TaskCategory");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskTag", b =>
                {
                    b.HasOne("WebApplication1.Models.TaskTags", "Tag")
                        .WithMany("TaskTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany("TaskTags")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplication1.Models.UserTask", b =>
                {
                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany("UserTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.Navigation("TaskCategoryAssignments");

                    b.Navigation("TaskTags");

                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskCattegory", b =>
                {
                    b.Navigation("TaskCategoryAssignments");
                });

            modelBuilder.Entity("WebApplication1.Models.TaskTags", b =>
                {
                    b.Navigation("TaskTag");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
