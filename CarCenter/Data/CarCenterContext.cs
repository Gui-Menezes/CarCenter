using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarCenter.Models;

namespace CarCenter.Data
{
    public class CarCenterContext : DbContext
    {
        public CarCenterContext (DbContextOptions<CarCenterContext> options)
            : base(options)
        {
        }

        public DbSet<CarCenter.Models.Client> Client { get; set; } = default!;

        public DbSet<CarCenter.Models.Car>? Car { get; set; }

        public DbSet<CarCenter.Models.Seller>? Seller { get; set; }

        public DbSet<CarCenter.Models.Bill>? Bill { get; set; }
    }
}
