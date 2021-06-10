using System;

namespace Entidades
{
    public class VistaReporte
    {
        private int iD_Producto;
        private string producto;
        private string estado;
        private string ubicacion;
        private int cant;
        private string descrip;
        private DateTime fecha;
        private double precio_Aprox;
        private string usuario;
        private string ocupacion;
        private string email;

        public VistaReporte()
        {
        }

        public VistaReporte(int iD_Producto, string producto, string estado, string ubicacion, int cant, string descrip, DateTime fecha, double precio_Aprox, string usuario, string ocupacion, string email)
        {
            this.iD_Producto = iD_Producto;
            this.producto = producto;
            this.estado = estado;
            this.ubicacion = ubicacion;
            this.cant = cant;
            this.descrip = descrip;
            this.fecha = fecha;
            this.precio_Aprox = precio_Aprox;
            this.usuario = usuario;
            this.ocupacion = ocupacion;
            this.email = email;
        }

        public int ID_Producto { get => iD_Producto; set => iD_Producto = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public int Cant { get => cant; set => cant = value; }
        public string Descrip { get => descrip; set => descrip = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Precio_Aprox { get => precio_Aprox; set => precio_Aprox = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string Email { get => email; set => email = value; }
    }
}
