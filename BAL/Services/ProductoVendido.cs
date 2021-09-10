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
        public static List<ProductoVendido> listaProductoVendido = new List<ProductoVendido>();

        public List<ProductoVendido> AgregarParaVender(int id)
        {
            ProductoVendido pv = new ProductoVendido();
            pv.id = id;
            listaProductoVendido.Add(pv);

            return listaProductoVendido;
        }
    }
}
