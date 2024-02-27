﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission_08_GROUP_1_3.Models;

#nullable disable

namespace Mission_08_GROUP_1_3.Migrations
{
    [DbContext(typeof(TaskListContext))]
    partial class TaskListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Mission_08_GROUP_1_3.Models.TaskList", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quadrant")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
