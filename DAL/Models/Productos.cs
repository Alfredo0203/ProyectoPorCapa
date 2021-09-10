
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El campo no puede ser nulo")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El campo no puede ser nulo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo no puede ser nulo")]
        [Range(0,int.MaxValue,ErrorMessage = "Cantidad no válida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo no puede ser nulo")]
        [Range(0, double.MaxValue, ErrorMessage = "Precio no válido")]
        public double Precio { get; set; }

        [ForeignKey("IdProducto")]
        public ICollection<DetalleVentas> Ventas { get; set; }
    }
}
