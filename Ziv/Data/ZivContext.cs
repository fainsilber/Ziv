using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ziv.Models;

namespace Ziv.Models
{
    public class ZivContext : DbContext
    {
        public ZivContext (DbContextOptions<ZivContext> options)
            : base(options)
        {
        }

        public DbSet<Ziv.Models.Gorilla> Gorilla { get; set; }

        public DbSet<Ziv.Models.Parrot> Parrot { get; set; }

        public DbSet<Ziv.Models.Shark> Shark { get; set; }

        public DbSet<Ziv.Models.Animal> Animal { get; set; }
        
    }
}
