using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPorCapa.Controllers
{
    public class ProductosController : Controller
    {
        Contexto contexto = new Contexto();
        private IProductoRepository productoRepository;

        public ProductosController()
        {
            this.productoRepository = new ProductoRepository(new Contexto());
        }

        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarProductos(bool? eliminado)
        {
            if (eliminado.HasValue)
            {
                ViewBag.Eliminado = eliminado.Value;
            }

            var model = contexto.Productos.ToList();
            return View(model);
        }

        public ActionResult AgregarProductos(int idProd = 0)
        {
            var model = new Productos();
  
            if (idProd > 0)
            {
                model = productoRepository.ObtenerPorId(idProd);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarProductos(Productos model)
        {
            if (ModelState.IsValid)
            {

                var creado = productoRepository.CreateOrEditProducto(model);

                if (creado)
                {
                    return RedirectToAction("MostrarProductos");
                }
            }

            return View(model);
        }

        public ActionResult EliminarProducto(int idProd)
        {
            var success = productoRepository.EliminarProducto(idProd);

            return RedirectToAction("MostrarProductos", new { eliminado = success });
        }

        public ActionResult SeleccionarProducto(int id)
        {
            int cantidad = 1;
            ProductoVendido prod = new ProductoVendido();
            var nombre = contexto.Productos.FirstOrDefault(x => x.IdProducto == id).NombreProducto;
            var precio = contexto.Productos.FirstOrDefault(x => x.IdProducto == id).Precio;
            var Total = cantidad * precio;
            ProductoVendido.TotalAPagar += Total;
            bool existe = (from c in ProductoVendido.listaProductoVendido where c.id == id select c).Any();
            if (existe == false)
            {
                prod.AgregarParaVender(id, cantidad, nombre, precio, Total);
                
            } else
            {
              
              foreach  (var p in ProductoVendido.listaProductoVendido.Where(r=> r.id == id))
                    {
                   
                    p.cantidad = p.cantidad + 1;
                    p.Total += precio * cantidad;
                  
                    break;
                }
                


            }
            var productos = ProductoVendido.listaProductoVendido;

            return RedirectToAction("MostrarProductos", productos);
        }
       
        public ActionResult Vender()
        {
            var ven = new Ventas();
            ven.Total = ProductoVendido.TotalAPagar;
            contexto.Entry(ven).State = EntityState.Added;
            
            foreach (var p in ProductoVendido.listaProductoVendido)
            {
                
                    var model = new DAL.Models.DetalleVentas();

                    model.IdProducto = p.id;
                model.Cantidad = p.cantidad;
                    model.IdVenta = ven.IdVenta;
                    contexto.Entry(model).State = EntityState.Added;
                    contexto.SaveChanges();
                
            }

            ProductoVendido.listaProductoVendido.RemoveRange(0, ProductoVendido.listaProductoVendido.Count());
            ProductoVendido.TotalAPagar = 0;
            return RedirectToAction("MostrarProductos");
        }

        public ActionResult MostrarVentas()
        {
            DetalleVentas db = new DetalleVentas();
            var model = contexto.DetalleVentas.ToList();
            ViewBag.Ventas = contexto.Ventas.ToList();
            return View(model);
        }
    }
}