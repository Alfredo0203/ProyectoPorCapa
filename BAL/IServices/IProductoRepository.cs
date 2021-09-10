
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IProductoRepository : IDisposable
    {
        bool CreateOrEditProducto(Productos model);
        Productos ObtenerPorId(int IdProd);
        bool EliminarProducto(int IdProd);
     
    }
}
