using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC3.Models;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace MVC3.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Applicant> Applicant { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
        public virtual DbSet<VacancyApplicant> VacancyApplicant { get; set; }
        public virtual DbSet<VacancyProject> VacancyProject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Applicant>()
            .HasIndex(a => new { a.EmailAddress, a.ContactNumber })
            .IsUnique();


            base.OnModelCreating(modelBuilder);  // Ensure Identity entities are configured

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            // Configure VacancyProject
            //modelBuilder.Entity<VacancyProject>(entity =>
            //{
            //    entity.HasKey(e => new { e.VacancyId, e.ProjectId });

            //    entity.HasOne(e => e.Vacancy)
            //        .WithMany(v => v.VacancyProjects)
            //        .HasForeignKey(e => e.VacancyId);

            //    entity.HasOne(e => e.Project)
            //        .WithMany(p => p.VacancyProjects)
            //        .HasForeignKey(e => e.ProjectId);
            //});

            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { Id = 6, Name = "Egyptian" },
                new Nationality { Id = 7, Name = "Scottish" },
                new Nationality { Id = 8, Name = "Belgium" },
                new Nationality { Id = 9, Name = "Spanish" },
                new Nationality { Id = 10, Name = "Irish" }
    // Add more nationalities as needed
    );

            modelBuilder.Entity<Vacancy>()
                .HasMany(p => p.Projects)
                .WithMany(v => v.Vacancies)
                .UsingEntity<VacancyProject>(
                    j => j
                        .HasOne(vp => vp.Project)
                        .WithMany(p => p.VacancyProjects)
                        .HasForeignKey(vp => vp.ProjectId),
                    j => j
                        .HasOne(vp => vp.Vacancy)
                        .WithMany(v => v.VacancyProjects)
                        .HasForeignKey(vp => vp.VacancyId),
                    j =>
                    {
                        j.HasKey(v => new { v.VacancyId, v.ProjectId });
                    }
                );
            //Configure VacancyApplicant
            modelBuilder.Entity<VacancyApplicant>(entity =>
            {
                entity.HasKey(e => new { e.VacancyId, e.ApplicantId });

                //entity.HasOne(e => e.Vacancy)
                //    .WithMany(v => v.VacancyApplicants)
                //    .HasForeignKey(e => e.VacancyId);

                entity.HasOne(e => e.Applicant)
                    .WithMany(a => a.VacancyApplicants)
                    .HasForeignKey(e => e.ApplicantId);
            });

            //modelBuilder.Entity<IdentityUser>().ToTable("Users", "security");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "security");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "security");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "security");
            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "security");

            //.Ignore(e => e.PhoneNumberConfirmed);

            // Other entity configurations...

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}