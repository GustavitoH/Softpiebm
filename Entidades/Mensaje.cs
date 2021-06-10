using System;

namespace Entidades
{
    public class Mensaje
    {
        private int iD_Mensaje;
        private DateTime fecha;
        private string remitente;
        private string mensajes;
        private string estado;

        public Mensaje()
        {
        }

        public Mensaje(int iD_Mensaje, DateTime fecha, string remitente, string mensajes, string estado)
        {
            this.iD_Mensaje = iD_Mensaje;
            this.fecha = fecha;
            this.remitente = remitente;
            this.mensajes = mensajes;
            this.estado = estado;
        }

        public int ID_Mensaje { get => iD_Mensaje; set => iD_Mensaje = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Remitente { get => remitente; set => remitente = value; }
        public string Mensajes { get => mensajes; set => mensajes = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
