using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class UsuarioLN
    {
        public List<Usuario> MostrarUsuarioFitro(string busqueda)
        {
            List<Usuario> Lista = new List<Usuario>();
            Usuario oc;
            try
            {
                List<cp_ListarUsuarioResult> auxLista = UsuarioCD.ListarUsuarioFiltro(busqueda);
                foreach (cp_ListarUsuarioResult aux in auxLista)
                {

                    oc = new Usuario(aux.ID_Usuario, aux.Usuario, aux.Ocupación, aux.Email, aux.Contraseña);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar los usuario.", ex);
            }
            return Lista;
        }
        public List<VistaUsuario> MostrarVistaUsuarioFitro(string busqueda)
        {
            List<VistaUsuario> Lista = new List<VistaUsuario>();
            VistaUsuario oc;
            try
            {
                List<cp_ListarVistaUsuarioResult> auxLista = UsuarioCD.ListarVistaUsuarioFiltro(busqueda);
                foreach (cp_ListarVistaUsuarioResult aux in auxLista)
                {

                    oc = new VistaUsuario(aux.ID_Usuario, aux.Usuario, aux.Ocupación);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar los usuario.", ex);
            }
            return Lista;
        }
        public bool CreateUsuario(Usuario oc)
        {
            try
            {
                UsuarioCD.InsertarUsuario(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear el usuario.", ex);
            }
        }
        public bool DeleteUsuario(Usuario oc)
        {
            try
            {
                UsuarioCD.EliminarUsuario(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar el usuario.", ex);
            }
        }
    }
}
