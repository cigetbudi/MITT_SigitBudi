﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skills.Models;

namespace Skills.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skills.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .HasColumnType("nVarchar(500)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Skills.Models.SkillLevel", b =>
                {
                    b.Property<string>("SkillLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("SkillLevelName")
                        .HasColumnType("nVarchar(500)");

                    b.HasKey("SkillLevelId");

                    b.ToTable("SkillLevel");
                });

            modelBuilder.Entity("Skills.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Skills.Models.UserProfile", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Address")
                        .HasColumnType("nVarchar(500)");

                    b.Property<DateTime>("BOD")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nVarchar(500)");

                    b.Property<string>("Name")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("Username");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("Skills.Models.UserSkills", b =>
                {
                    b.Property<string>("UserSkillId")
                        .HasColumnType("nVarchar(50)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("SkillLevelId")
                        .IsRequired()
                        .HasColumnType("nVarchar(50)");

                    b.Property<string>("Username")
                        .HasColumnType("nVarchar(50)");

                    b.HasKey("UserSkillId");

                    b.HasIndex("SkillId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("Username");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Skills.Models.UserProfile", b =>
                {
                    b.HasOne("Skills.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Skills.Models.UserSkills", b =>
                {
                    b.HasOne("Skills.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.Models.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("Skill");

                    b.Navigation("SkillLevel");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
