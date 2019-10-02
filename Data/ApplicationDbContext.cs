using Microsoft.EntityFrameworkCore;
using SampleEF_Core_Relations.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF_Core_Relations.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SampleDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupSub>()
                .HasKey(bc => new { bc.GroupId, bc.SubGroupId });

            modelBuilder.Entity<GroupSub>()
                .HasOne(bc => bc.Group)
                .WithMany(b => b.GroupSubs)
                .HasForeignKey(bc => bc.GroupId);

            modelBuilder.Entity<GroupSub>()
                .HasOne(bc => bc.SubGroup)
                .WithMany(c => c.GroupSubs)
                .HasForeignKey(bc => bc.SubGroupId);

            //-------------------------------------------

            modelBuilder.Entity<GroupUser>()
                .HasKey(bc => new { bc.GroupId, bc.UserId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.Group)
                .WithMany(b => b.GroupUsers)
                .HasForeignKey(bc => bc.GroupId);

            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.GroupUsers)
                .HasForeignKey(bc => bc.UserId);
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
    }
}
