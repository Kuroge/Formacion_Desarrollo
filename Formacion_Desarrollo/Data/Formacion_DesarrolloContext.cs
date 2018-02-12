using Formacion_Desarrollo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Data
{
    public class Formacion_DesarrolloContext : DbContext
    {
        public Formacion_DesarrolloContext(DbContextOptions<Formacion_DesarrolloContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>().HasKey(sc => new { sc.UserId, sc.ProjectId });
        }

        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Department> Department { get; set; }



    }
}
