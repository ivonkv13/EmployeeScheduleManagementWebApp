﻿// <auto-generated />
using System;
using EmployeeScheduleManagementWebApp.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeScheduleManagementWebApp.Server.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeEmployeeRole", b =>
                {
                    b.Property<int>("EmployeeRolesId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeRolesId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("EmployeeEmployeeRole");
                });

            modelBuilder.Entity("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeScheduleManagementWebApp.Server.Domain.Entities.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("EmployeeEmployeeRole", b =>
                {
                    b.HasOne("EmployeeScheduleManagementWebApp.Server.Domain.Entities.EmployeeRole", null)
                        .WithMany()
                        .HasForeignKey("EmployeeRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Shift", b =>
                {
                    b.HasOne("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Employee", "Employee")
                        .WithMany("Shifts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeScheduleManagementWebApp.Server.Domain.Entities.EmployeeRole", "EmployeeRole")
                        .WithMany()
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("EmployeeRole");
                });

            modelBuilder.Entity("EmployeeScheduleManagementWebApp.Server.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
