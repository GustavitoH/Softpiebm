using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ProductoLN
    {
        public List<Producto> MostrarProductoFitro(string busqueda)
        {
            List<Producto> Lista = new List<Producto>();
            Producto oc;
            try
            {
                List<cp_ListarProductoResult> auxLista = ProductoCD.ListarProductoFiltro(busqueda);
                foreach (cp_ListarProductoResult aux in auxLista)
                {

                    oc = new Producto(aux.ID_Producto, aux.Producto, aux.Estado, aux.Ubicación, (int)aux.Cantidad, aux.Descripción, (DateTime)aux.Fecha, Convert.ToDouble(aux.Precio_Aproximado));
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar el articulo.", ex);
            }
            return Lista;
        }
        public List<VistaReporte> MostrarReporteFitro(string busqueda)
        {
            List<VistaReporte> Lista = new List<VistaReporte>();
            VistaReporte oc;
            try
            {
                List<cp_ListarReporteMensajeResult> auxLista = ProductoCD.ListarVistaReporteFiltro(busqueda);
                foreach (cp_ListarReporteMensajeResult aux in auxLista)
                {

                    oc = new VistaReporte(aux.ID_Producto, aux.Producto, aux.Estado, aux.Ubicación, (int)aux.Cantidad, aux.Descripción, (DateTime)aux.Fecha, (double)aux.Precio_Aproximado, aux.Usuario, aux.Ocupación, aux.Email);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar el reporte.", ex);
            }
            return Lista;
        }
        public bool CreateProducto(Producto oc)
        {
            try
            {
                ProductoCD.InsertarProducto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear el articulo.", ex);
            }
        }
        public bool UpdateProducto(Producto oc)
        {
            try
            {
                ProductoCD.ActualizarProducto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar el articulo.", ex);
            }
        }

        public bool DeleteProducto(Producto oc)
        {
            try
            {
                ProductoCD.EliminarProducto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar el articulo.", ex);
            }
        }

    }
}
