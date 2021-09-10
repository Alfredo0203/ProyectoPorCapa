using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
   public class ProductoVendido
    {
        public int id { get; set; }
        public string NombreProducto { get; set; }
        public int cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public static double TotalAPagar { get; set; }
        public static List<ProductoVendido> listaProductoVendido = new List<ProductoVendido>();

        public List<ProductoVendido> AgregarParaVender(int id, int cantidad, string nombre, double Precio, double total)
        {
            ProductoVendido pv = new ProductoVendido();
            pv.id = id;
            pv.cantidad = cantidad;
            pv.NombreProducto = nombre;
            pv.Precio = Precio;
            pv.Total = total;
            
            listaProductoVendido.Add(pv);

            return listaProductoVendido;
        }
    }
}
