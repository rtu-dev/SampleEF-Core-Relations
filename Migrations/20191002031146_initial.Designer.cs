﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleEF_Core_Relations.Data;

namespace SampleEF_Core_Relations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191002031146_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("GroupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.GroupSub", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<int>("SubGroupId");

                    b.HasKey("GroupId", "SubGroupId");

                    b.HasIndex("SubGroupId");

                    b.ToTable("GroupSub");
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.GroupUser", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<int>("UserId");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.SubGroup", b =>
                {
                    b.Property<int>("SubGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("SubGroupId");

                    b.ToTable("SubGroup");
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.GroupSub", b =>
                {
                    b.HasOne("SampleEF_Core_Relations.Entity.Group", "Group")
                        .WithMany("GroupSubs")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleEF_Core_Relations.Entity.SubGroup", "SubGroup")
                        .WithMany("GroupSubs")
                        .HasForeignKey("SubGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleEF_Core_Relations.Entity.GroupUser", b =>
                {
                    b.HasOne("SampleEF_Core_Relations.Entity.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleEF_Core_Relations.Entity.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
