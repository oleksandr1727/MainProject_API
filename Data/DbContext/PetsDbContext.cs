﻿using Data.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.DbContext
{
    public class PetsDbContext : IdentityDbContext
    {
        public DbSet<Pet> Pet { get; set;}
        public DbSet<Breed> Breed { get; set;}
        public DbSet<BreedDTB> BreedDTB { get; set;}
        public DbSet<User> User { get; set;}

        public PetsDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("LocalDb");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new List<Category>()
            {
                new Category() { Id = 1, Name="Dog"},
                new Category() { Id = 2, Name="Cat"}
            });

            builder.Entity<Breed>().HasData(new List<Breed>()
            {
                new Breed() { Id = 1, Name="Samoyed", CategoryId=1}
            });

            builder.Entity<Pet>().HasData(new List<Pet>()
            {
                new Pet() {Id = 1, Name="Alex", YearsOld=2, Description="Cute pupy with blue eyes", ImageUrl="https://www.google.com/url?sa=i&url=https%3A%2F%2Fsamvillesamoyeds.com%2Fzdorovya-samoyidskyh-sobak%2F&psig=AOvVaw3u5uF9WJHN7815XZ4uHVIo&ust=1725373467187000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKDj_du6pIgDFQAAAAAdAAAAABAK"}
            });

            builder.Entity<BreedDTB>().HasData(new List<BreedDTB>()
            {
                new BreedDTB {PetId=1, BreedId=1}
            });

            builder.Entity<BreedDTB>()
              .HasKey(fg => new { fg.PetId, fg.BreedId });

            builder.Entity<BreedDTB>()
                .HasOne(fg => fg.Pet)
                .WithMany(m => m.Breed)
                .HasForeignKey(fg => fg.PetId);
        }
    }
}
