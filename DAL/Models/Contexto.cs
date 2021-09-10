
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<DetalleVentas> DetalleVentas { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
    }
}
