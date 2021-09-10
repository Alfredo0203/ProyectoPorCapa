using BAL.IServices;

using DAL.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ProductoRepository : IProductoRepository, IDisposable
    {
        private readonly Contexto contexto;

        public ProductoRepository(Contexto contexto_)
        {
            this.contexto = contexto_;
        }

        public bool CreateOrEditProducto(Productos model)
        {
            bool success;
            try
            {

                if (model.IdProducto > 0)
                {
                    contexto.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }

                contexto.SaveChanges();

                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public Productos ObtenerPorId(int IdProd)
        {
            var model = contexto.Productos.FirstOrDefault(x => x.IdProducto == IdProd);
            return model;
        }

        public bool EliminarProducto(int IdProd)
        {
            bool success;
            var model = ObtenerPorId(IdProd);

            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                }
            }
            else
            {
                success = false;
            }

            return success;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}