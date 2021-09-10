
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }

        public int Total { get; set; }

        [ForeignKey("IdVenta")]
        public ICollection<DetalleVentas> DetalleVentas { get; set; }
    }
}
