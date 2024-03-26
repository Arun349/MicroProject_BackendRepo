using Backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<RepairShop> RepairShop { get; set; }
        public DbSet<Mobile> Mobile { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<FinalAppointment> FinalAppointment { get; set; }
        public DbSet<FinalService> FinalService { get; set; }


    }
}
