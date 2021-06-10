using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class ProductoCD
    {
        public static List<cp_ListarProductoResult> ListarProductoFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarProducto(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Articulo.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<cp_ListarReporteMensajeResult> ListarVistaReporteFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarReporteMensaje(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar reporte.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarProducto(Producto oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_InsertarProducto(oc.Articulos, oc.Estado, oc.Ubicacion, oc.Cantidad, oc.Descripcion, oc.Fecha, (decimal)oc.Precio_Aproximado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar el Articulo.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarProducto(Producto oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_ActualizarProducto(oc.ID_Producto, oc.Articulos, oc.Estado, oc.Ubicacion, oc.Cantidad, oc.Descripcion, oc.Fecha, (decimal)oc.Precio_Aproximado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar el Articulo.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarProducto(Producto oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_EliminarProducto(oc.ID_Producto);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar el Articulo.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
