using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class MensajeLN
    {
        public List<Mensaje> MostrarMensajeFitro(string busqueda)
        {
            List<Mensaje> Lista = new List<Mensaje>();
            Mensaje oc;
            try
            {
                List<cp_ListarMensajeResult> auxLista = MensajeCD.ListarMensajeFiltro(busqueda);
                foreach (cp_ListarMensajeResult aux in auxLista)
                {

                    oc = new Mensaje(aux.ID_Mensaje, (DateTime)aux.Fecha, aux.Remitente, aux.Mensaje, aux.Estado);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar el mensaje.", ex);
            }
            return Lista;
        }
        public List<VistaMensaje> MostrarVistaMensajeFitro(string busqueda)
        {
            List<VistaMensaje> Lista = new List<VistaMensaje>();
            VistaMensaje oc;
            try
            {
                List<cp_ListarVistaMensajeResult> auxLista = MensajeCD.ListarVistaMensajeFiltro(busqueda);
                foreach (cp_ListarVistaMensajeResult aux in auxLista)
                {

                    oc = new VistaMensaje(aux.ID_Mensaje, (DateTime)aux.Fecha, aux.Mensaje);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar los mensajes.", ex);
            }
            return Lista;
        }
        public bool CreateMensaje(Mensaje oc)
        {
            try
            {
                MensajeCD.InsertarMensaje(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear el mensaje.", ex);
            }
        }
        public bool UpdateEstadoMsm(Mensaje oc)
        {
            try
            {
                MensajeCD.ActualizarEstadoMensajes(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar el estado del mensaje.", ex);
            }
        }
    }
}