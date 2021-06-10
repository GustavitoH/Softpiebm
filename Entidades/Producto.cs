using System;

namespace Entidades
{
    public class Producto
    {
        private int iD_Producto;
        private string articulos;
        private string estado;
        private string ubicacion;
        private int cantidad;
        private string descripcion;
        private DateTime fecha;
        private double precio_Aproximado;

        public Producto()
        {
        }

        public Producto(int iD_Producto, string articulos, string estado, string ubicacion, int cantidad, string descripcion, DateTime fecha, double precio_Aproximado)
        {
            this.iD_Producto = iD_Producto;
            this.articulos = articulos;
            this.estado = estado;
            this.ubicacion = ubicacion;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.precio_Aproximado = precio_Aproximado;
        }

        public int ID_Producto { get => iD_Producto; set => iD_Producto = value; }
        public string Articulos { get => articulos; set => articulos = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Precio_Aproximado { get => precio_Aproximado; set => precio_Aproximado = value; }
    }
}
