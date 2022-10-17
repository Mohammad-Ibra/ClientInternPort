using System;
using Microsoft.EntityFrameworkCore;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInternPort.Models
{
    public partial class InternPortContext : DbContext
    {
        public InternPortContext()
        {
        }

        public InternPortContext(DbContextOptions<InternPortContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Interns> Interns { get; set; }
        public virtual DbSet<Programs> Program { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exams>(entity =>
            {
                entity.HasKey(e => e.AssessmentId);
            });

            modelBuilder.Entity<Instructors>(entity =>
            {
                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<Interns>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FullName).IsRequired();
            });

            modelBuilder.Entity<Programs>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
