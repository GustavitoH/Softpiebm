using System;

namespace Entidades
{
    public class VistaMensaje
    {
        private int iD;
        private DateTime fecha;
        private string mensaje;

        public VistaMensaje()
        {
        }

        public VistaMensaje(int iD, DateTime fecha, string mensaje)
        {
            this.iD = iD;
            this.fecha = fecha;
            this.mensaje = mensaje;
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
