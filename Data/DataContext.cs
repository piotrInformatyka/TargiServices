using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Targi.Core.Domain;

namespace Targi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<ModeratorProfile> ModeratorProfiles { get; set; }
        public DbSet<BenefitCard> BenefitCards { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Webinar> Webinars { get; set; }
        public DbSet<CompanyProfilePhoto> CompanyProfilePhotos { get; set; }
        public DbSet<JobOfferPhoto> JobOfferPhoto { get; set; }
        public DbSet<WebinarPhoto> WebinarPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid adminId = Guid.NewGuid();
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("getJob", out passwordHash, out passwordSalt);

            modelBuilder.Entity<BenefitCard>()
                .Property(e => e.Description)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<JobOffer>()
                .Property(p => p.Id).IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Photo>()
                .Property(p => p.Id).IsRequired().ValueGeneratedNever();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                Role = "admin",
                Email = "npc",
                IsActive = true,
                CreatedAt = DateTime.Now,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                IsCompany = false         
            });
            modelBuilder.Entity<ModeratorProfile>().HasData(new ModeratorProfile
            {
                Id = Guid.NewGuid(),
                UserId = adminId,
                ContactPerson = "Webmastery",
                PhoneNumber = "783032065",
                Position = "admin"
            });
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }

}

