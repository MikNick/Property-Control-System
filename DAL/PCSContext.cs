using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PCSContext : DbContext
    {
        public DbSet<Depratment> Departments { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Documentary> Documentary{ get; set; }
        public DbSet<StuffReport> StuffReports { get; set; }

        public PCSContext(DbContextOptions options) : base(options)
        {
        }
    }
}
