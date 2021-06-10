using Entidades;
using Logica;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmEditProducto : Form
    {
        public FrmEditProducto()
        {
            InitializeComponent();
            CenterToScreen();
        }
        public int val;
        public Producto pa = new Producto();

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Producto crearObjeto()
        {

            pa.ID_Producto = pa.ID_Producto;
            pa.Cantidad = (int)txtCant.Value;
            pa.Descripcion = txtDescrp.Text;
            pa.Estado = cbEstado.selectedValue;
            pa.Fecha = dateGrid.Value;
            pa.Articulos = txtProdu.Text;
            pa.Ubicacion = txtUbicac.Text;
            pa.Precio_Aproximado = Convert.ToDouble(txtPrecio.Text);

            return pa;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }

        }

        private void llenarCampos()
        {

            txtCant.Value = pa.Cantidad;
            txtDescrp.Text = pa.Descripcion;
            txtProdu.Text = pa.Articulos;
            txtUbicac.Text = pa.Ubicacion;
            for (int i = 0; i < cbEstado.Items.Length; i++)
            {
                if (pa.Estado.Equals(cbEstado.Items[i]))
                {
                    cbEstado.selectedIndex = i;
                }
            }
            dateGrid.Value = pa.Fecha;
            txtPrecio.Text = pa.Precio_Aproximado.ToString();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmEditProducto_Load(object sender, EventArgs e)
        {
            if (val == 2)
            {
                llenarCampos();
            }
            if (val == 1)
            {
                dateGrid.Value = DateTime.Now;
            }

        }
        private bool validarDatos()
        {
            if (txtCant.Value == 0 || txtDescrp.Text.Equals("") || txtProdu.Text.Equals("") || txtUbicac.Text.Equals("") || cbEstado.selectedIndex == -1 || txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return false;
            }
            else
            {
                if (txtPrecio.Text.Contains('.') == true)
                {
                    MessageBox.Show("Separe los decimales con una coma(,)");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        ProductoLN pln = new ProductoLN();
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (val == 1)
            {
                if (validarDatos() == true)
                {
                    Producto pr = crearObjeto();
                    if (pln.CreateProducto(pr))
                    {
                        MessageBox.Show("Articulo Ingresado con exito");
                    }
                    this.Close();
                }
            }
            if (val == 2)
            {
                if (validarDatos() == true)
                {
                    Producto pr = crearObjeto();
                    if (pln.UpdateProducto(pr))
                    {
                        MessageBox.Show("Articulo Modificado con exito");
                    }
                    this.Close();
                }
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se permiten letras");
            }
        }
    }
}
