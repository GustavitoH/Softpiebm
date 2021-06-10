using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class UsuarioCD
    {
        public static List<cp_ListarUsuarioResult> ListarUsuarioFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarUsuario(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Usuarios.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<cp_ListarVistaUsuarioResult> ListarVistaUsuarioFiltro(string busqueda)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    return DB.cp_ListarVistaUsuario(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Usuarios.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarUsuario(Usuario oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_InsertarUsuario(oc.User, oc.Ocupacion, oc.Email, oc.Contras);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar el usuario.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarUsuario(Usuario oc)
        {
            BDSoftPiebmDataContext DB = null;
            try
            {
                using (DB = new BDSoftPiebmDataContext())
                {
                    DB.cp_EliminarUsuario(oc.ID_Usuario);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar el usuario.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
