using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data
{
    public class FilmRentalContext : DbContext
    {
        public FilmRentalContext(DbContextOptions<FilmRentalContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Account> Accounts { get; set; }

        ////
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
                (
                    new User { Id = 2, Email = "mail@msn.se", Name = "Tobias" },
                    new User { Id = 3, Email = "John@msn.se", Name = "John" }
                );
            modelBuilder.Entity<Movie>().HasData
                (
                    new Movie { Id = 1, Title = "John Wick", ReleaseYear = 2019 },
                    new Movie { Id = 2, Title = "John Wick2", ReleaseYear = 2021 }
                );
            modelBuilder.Entity<Rental>().HasData
                (
                    new Rental { FK_UserId = 1, FK_MovieId = 1, LoanDate = DateTime.Now, ReturnDate = null, Id = 1 },
                    new Rental { FK_UserId = 2, FK_MovieId = 2, LoanDate = new DateTime(2024, 8, 10), ReturnDate = new DateTime(2024, 8, 15), Id = 2 }
                );
        }
    }
}
//"server=(localdb)\MSSQLLocalDB;Databas=FilmRentalContext;Trusted_Connection=True;"