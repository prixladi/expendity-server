﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shamyr.Expendity.Server.Service.Database;

namespace Shamyr.Expendity.Server.Service.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210207183028_EntityTypeProject")]
    partial class EntityTypeProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ExpenseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AddedUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("added_utc");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.Property<double>("Value")
                        .HasColumnType("float")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_expenses");

                    b.HasIndex("AddedUtc")
                        .HasDatabaseName("ix_expenses_added_utc");

                    b.HasIndex("TypeId")
                        .HasDatabaseName("ix_expenses_type_id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ExpenseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.HasKey("Id")
                        .HasName("pk_expense_types");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_expense_types_project_id");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ProjectPermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_project_permissions");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_project_permissions_project_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_project_permissions_user_id");

                    b.HasIndex("UserId", "ProjectId")
                        .IsUnique()
                        .HasDatabaseName("ix_project_permissions_user_id_project_id");

                    b.ToTable("ProjectPermissions");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FamilyName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("family_name");

                    b.Property<string>("GivenName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("given_name");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("subject_id");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("SubjectId")
                        .IsUnique()
                        .HasDatabaseName("ix_users_subject_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ExpenseEntity", b =>
                {
                    b.HasOne("Shamyr.Expendity.Server.Entities.ExpenseTypeEntity", "Type")
                        .WithMany("Expenses")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("fk_expenses_expense_types_type_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ExpenseTypeEntity", b =>
                {
                    b.HasOne("Shamyr.Expendity.Server.Entities.ProjectEntity", "Project")
                        .WithMany("ExpenseTypes")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("fk_expense_types_projects_project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ProjectPermissionEntity", b =>
                {
                    b.HasOne("Shamyr.Expendity.Server.Entities.ProjectEntity", "Project")
                        .WithMany("Permissions")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("fk_project_permissions_projects_project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shamyr.Expendity.Server.Entities.UserEntity", "User")
                        .WithMany("ProjectPermissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_project_permissions_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ExpenseTypeEntity", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.ProjectEntity", b =>
                {
                    b.Navigation("ExpenseTypes");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Shamyr.Expendity.Server.Entities.UserEntity", b =>
                {
                    b.Navigation("ProjectPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}