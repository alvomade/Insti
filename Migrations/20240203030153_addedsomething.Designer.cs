﻿// <auto-generated />
using System;
using Insti.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insti.Migrations
{
    [DbContext(typeof(InstiDb))]
    [Migration("20240203030153_addedsomething")]
    partial class addedsomething
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insti.Models.Admin.AdminModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Insti.Modules.AdminInstitution.AdminInstitutionModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Adminid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Institutionid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Adminid");

                    b.HasIndex("Institutionid");

                    b.ToTable("AdminInstitutions");
                });

            modelBuilder.Entity("Insti.Modules.Institution.InstitutionModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("id");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("Insti.Modules.AdminInstitution.AdminInstitutionModel", b =>
                {
                    b.HasOne("Insti.Models.Admin.AdminModel", "Admin")
                        .WithMany("adminInstitutuions")
                        .HasForeignKey("Adminid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insti.Modules.Institution.InstitutionModel", "Institution")
                        .WithMany("adminInstitutuions")
                        .HasForeignKey("Institutionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Insti.Models.Admin.AdminModel", b =>
                {
                    b.Navigation("adminInstitutuions");
                });

            modelBuilder.Entity("Insti.Modules.Institution.InstitutionModel", b =>
                {
                    b.Navigation("adminInstitutuions");
                });
#pragma warning restore 612, 618
        }
    }
}
