

using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    public class DetalleVentas
    {
        private Contexto contexto = new Contexto();
        [Key]
        public int IdDetalleVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public int IdVenta { get; set; }
        [NotMapped]
        public List<Ventas>ListaVentas { get; set; }

        [NotMapped]
        public List<DetalleVentas> ListaDetalleVentas { get; set; }

        [NotMapped]
        public string NombreProducto
        {
            get
            {
              return  contexto.Productos.FirstOrDefault(x => x.IdProducto == IdProducto).NombreProducto;
            }
        }
    }

}
