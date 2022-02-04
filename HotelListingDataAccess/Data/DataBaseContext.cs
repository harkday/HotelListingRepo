using HotelListingModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListingDataAccess.Data
{
   public  class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(

                new Country
                {
                    Id = 1,
                    Name ="Nigeria",
                    Shortname = "NIG"

                },
                new Country
                {
                    Id =2,
                    Name ="Ghana",
                    Shortname="GHN"
                },
                new Country
                {
                    Id = 3,
                    Name ="Cameroon",
                    Shortname ="CMR"
                }
                );
            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sharaton",
                    Rating = 4,
                    Address = "Maryland",
                    CountryId=1

                },

                new Hotel
                {
                    Id =2,
                    Name = "Radisson Blue",
                    Rating = 5,
                    Address="Victoria Island",
                    CountryId=2
                },
                new Hotel
                {
                    Id=3,
                    Name ="Chesterfield",
                    Rating = 3,
                    Address = "Adeniyi Jones",
                    CountryId = 3
                }
                
                );

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
