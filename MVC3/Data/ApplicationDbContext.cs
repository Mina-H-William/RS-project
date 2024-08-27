using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC3.Areas.Access.Models;
using MVC3.Areas.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace MVC3.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TechnicalInterview> TechnicalInterviews { get; set; }
        public DbSet<ApplicantAnswers> ApplicantAnswers { get; set; }
        public DbSet<ApplicantStatus> ApplicantStatus { get; set; }
        public DbSet<UserDepartmentProject> UserDepartmentProject { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<question> questions { get; set; }
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

            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Title)
                .WithMany(t => t.Vacancies)
                .HasForeignKey(v => v.TitleId);

            modelBuilder.Entity<Title>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Titles)
                .HasForeignKey(v => v.DepartmentId);

            //Configure VacancyApplicant
            modelBuilder.Entity<VacancyApplicant>(entity =>
            {
                entity.HasKey(e => new { e.VacancyId, e.ApplicantId });

                //entity.HasOne(e => e.Vacancy)
                //    .WithMany(v => v.VacancyApplicants)
                //    .HasForeignKey(e => e.VacancyId);

                entity.HasOne(e => e.Applicant)
                    .WithMany(a => a.VacancyApplicants)
                    .HasForeignKey(e => e.ApplicantId).OnDelete(DeleteBehavior.Cascade);
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

            // role permissions intially

            modelBuilder.Entity<RolePermission>()
           .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            /////////////////////////////

            var permissions = new List<Permission>()
            {
                new Permission { Id = 1, Name = "Admin" },
                new Permission { Id = 2, Name = "Applicant" },
                new Permission { Id = 3, Name = "Country" },
                new Permission { Id = 4, Name = "Vacancy" },
                new Permission { Id = 5, Name = "Title" },
                new Permission { Id = 6, Name = "Project" },
                new Permission { Id = 7, Name = "Department" },
                new Permission { Id = 8, Name = "Location" },
                new Permission { Id = 9, Name = "Questions" }
            };

            // initial permissions data
            modelBuilder.Entity<Permission>().HasData(permissions);
            ////////////////
            ////////////////////create role admin and user and assign all permissions to this role /////////////

            var hasher = new PasswordHasher<ApplicationUser>();

            // Create Admin Role
            var adminRoleId = "1"; // Assign an ID to the Admin role
            var adminUserId = "1"; // Assign an ID to the Admin user
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Create Admin User
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminUserId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                Active = true
            });

            // Assign Admin Role to Admin User
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });

            // Assign All Permissions to Admin Role
            var rolepermissions = new List<RolePermission>();
            foreach (var permission in permissions)
            {
                var rolepermission = new RolePermission()
                {
                    PermissionId = permission.Id,
                    RoleId = adminRoleId
                };
                rolepermissions.Add(rolepermission);
            }
            modelBuilder.Entity<RolePermission>().HasData(rolepermissions.ToArray());

            //////////////////// UPD-database ////////////////

            modelBuilder.Entity<UserDepartmentProject>()
            .HasKey(du => new { du.Id });

            modelBuilder.Entity<UserDepartmentProject>()
                .HasOne(du => du.Department)
                .WithMany(d => d.UserDepartmentProject)
                .HasForeignKey(du => du.DepartmentId);

            modelBuilder.Entity<UserDepartmentProject>()
                .HasOne(du => du.User)
                .WithMany(u => u.UserDepartmentProject)
                .HasForeignKey(du => du.UserId);

            modelBuilder.Entity<UserDepartmentProject>()
                .HasOne(du => du.Project)
                .WithMany(u => u.UserDepartmentProject)
                .HasForeignKey(du => du.ProjectId);

            //////////////////

            ///// hr-technical evalute database //////////////////
            ///// Applicant Answer ///////////////

            modelBuilder.Entity<ApplicantAnswers>()
                .HasKey(du => new { du.ApplicantId,du.VacancyId,du.QuestionId });

            modelBuilder.Entity<ApplicantAnswers>()
                .HasOne(AA => AA.Applicant)
                .WithMany(A => A.ApplicantAnswers)
                .HasForeignKey(AA => AA.ApplicantId);

            modelBuilder.Entity<ApplicantAnswers>()
                .HasOne(AA => AA.Vacancy)
                .WithMany(v => v.ApplicantAnswers)
                .HasForeignKey(AA => AA.VacancyId);

            modelBuilder.Entity<ApplicantAnswers>()
                .HasOne(AA => AA.Question)
                .WithMany(u => u.ApplicantAnswers)
                .HasForeignKey(AA => AA.QuestionId);

            ///////// Applicant Status ///////////////

            modelBuilder.Entity<ApplicantStatus>()
                .HasKey(du => new { du.ApplicantId, du.VacancyId });

            modelBuilder.Entity<ApplicantStatus>()
                .HasOne(AA => AA.Applicant)
                .WithMany(A => A.ApplicantStatus)
                .HasForeignKey(AA => AA.ApplicantId);

            modelBuilder.Entity<ApplicantStatus>()
                .HasOne(AA => AA.Vacancy)
                .WithMany(v => v.ApplicantStatus)
                .HasForeignKey(AA => AA.VacancyId);

            //////////////////////
            ////////// TechnicalInterviews ////////////////

            modelBuilder.Entity<TechnicalInterview>()
                .HasKey(du => new { du.ApplicantId, du.VacancyId });

            modelBuilder.Entity<TechnicalInterview>()
                .HasOne(AA => AA.Applicant)
                .WithMany(A => A.TechnicalInterviews)
                .HasForeignKey(AA => AA.ApplicantId);

            modelBuilder.Entity<TechnicalInterview>()
                .HasOne(AA => AA.Vacancy)
                .WithMany(v => v.TechnicalInterviews)
                .HasForeignKey(AA => AA.VacancyId);

            //////////////////////////

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}