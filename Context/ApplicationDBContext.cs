using EjemploConexioBDMySQL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConexioBDMySQL.Context
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseMySQL("Server=localhost; Database=23cv; User=root; Password=; ");
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
