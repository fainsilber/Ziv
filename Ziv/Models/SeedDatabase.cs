using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ziv.Models
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider argServiceProvider)
        {
            using (var aContext = new ZivContext(argServiceProvider.GetRequiredService<DbContextOptions<ZivContext>>()))
            {
                if (aContext.Animal.Any()) return;//DB has Data

                aContext.Gorilla.Add(
                    new Gorilla
                    {
                        DateOfBirth = DateTime.Parse("1977-01-01"),
                        Gender = "Male",
                        Name = "King Kong",
                        Weight = 20000,
                        HairColor = "Black",
                        Age = 15
                    });
                aContext.Gorilla.Add(
                    new Gorilla
                    {
                        DateOfBirth = DateTime.Parse("2001-01-01"),
                        Gender = "Male",
                        Name = "Caesar",
                        Weight = 96,
                        HairColor = "Black",
                        Age = 16
                    });
                aContext.Parrot.Add(
                    new Parrot
                    {
                        DateOfBirth = DateTime.Parse("1987-02-02"),
                        Gender = "Female",
                        Name = "Lady",
                        Weight = 1.5M,
                        CanTalk = true,
                        FeathersColor = "Blue"
                    });
                aContext.Parrot.Add(
                    new Parrot
                    {
                        DateOfBirth = DateTime.Parse("2015-06-09"),
                        Gender = "Male",
                        Name = "Paulie",
                        Weight = 2.1M,
                        CanTalk = false,
                        FeathersColor = "Green"
                    });
                aContext.Shark.Add(
                    new Shark
                    {

                        DateOfBirth = DateTime.Parse("1997-03-03"),
                        Gender = "Male",
                        Name = "Jaws",
                        Weight = 950,
                        AmountOfTeeth = 300,
                        NeedSaltWater = true,
                        SkinColor = "Gray"
                    });
                aContext.SaveChanges();

            }
        }
    }
}
