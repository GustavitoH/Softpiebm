using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class MensajeCD
    {
        public static List<cp_ListarMensajeResult> ListarMensajeFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarMensaje(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar mensaje.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<cp_ListarVistaMensajeResult> ListarVistaMensajeFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarVistaMensaje(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar mensajes.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarMensaje(Mensaje oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_InsertarMensaje(oc.Fecha, oc.Remitente, oc.Mensajes, oc.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar el mensaje.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarEstadoMensajes(Mensaje oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_ActualizarEstadoMensaje(oc.ID_Mensaje, oc.Mensajes);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar el estado del mensaje.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
