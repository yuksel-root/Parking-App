using Microsoft.EntityFrameworkCore;
using Parking_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Contexts
{
    public class CarParkingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VNKEEQV\\SQLEXPRESS;database=dbParking; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasMany(I => I.CarParkings).WithOne(I => I.Car)
                 .HasForeignKey(I => I.CarId);


            modelBuilder.Entity<Parking>().HasMany(I => I.CarParkings).WithOne(I => I.Parking)
                 .HasForeignKey(I => I.ParkingId);

            modelBuilder.Entity<CarParking>().HasIndex(I => new
            {
                I.CarId,
                I.ParkingId
            }).IsUnique();
        }

        public DbSet<CarParking> CarParkings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Parking> Parkings { get; set; }
    }
}
