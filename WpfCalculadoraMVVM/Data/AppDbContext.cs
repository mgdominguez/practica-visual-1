using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCalculadoraMVVM.Models;

namespace WpfCalculadoraMVVM.Data
{
    public class AppDbContext : DbContext
    {
        //tablas
        public DbSet<Calculadora> Calculadora { get; set; }

        //conexion a base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0QF3P7K;Initial Catalog=uninorte2025;User ID=sa;Password=Milciades1987;Encrypt=False;Trust Server Certificate=True");
        }
    }
}