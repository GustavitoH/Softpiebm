using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        public string correoUsuario;

        private string obtenerUsuario()
        {
            string resp = "";
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(correoUsuario))
                {
                    resp = uln.MostrarUsuarioFitro("")[i].User;
                }
            }
            return resp;
        }
        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            FrmEditProducto ep = new FrmEditProducto();
            ep.val = 1;
            ep.ShowDialog();
            cargarProductos("");
            lbNum.Text = totalArti();
        }
        ProductoLN pln = new ProductoLN();
        MensajeLN mln = new MensajeLN();
        Form1 f = new Form1();
        private void cargarProductos(string buscar)
        {
            bunifuCustomDataGrid1.DataSource = pln.MostrarProductoFitro(buscar);
        }
        UsuarioLN uln = new UsuarioLN();

        private void cargarMensajes()
        {
            List<VistaMensaje> listaMsm = new List<VistaMensaje>();
            for (int i = 0; i < mln.MostrarMensajeFitro("").Count; i++)
            {
                if (mln.MostrarMensajeFitro("")[i].Estado.Equals("No leído") && mln.MostrarMensajeFitro("")[i].Remitente.Equals(obtenerUsuario()))
                {
                    listaMsm.Add(mln.MostrarVistaMensajeFitro("")[i]);
                }
            }
            bunifuCustomDataGrid2.DataSource = listaMsm.ToList();
        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Buscar";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Buscar")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Buscar"))
            {
                cargarProductos("");
            }
            else
            {
                cargarProductos(textBox1.Text);
            }
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            cargarProductos("");
            cargarMensajes();
            lbNum.Text = totalArti();
            bunifuCustomDataGrid1.Columns[0].Width = 85;
            bunifuCustomDataGrid1.Columns[1].Width = 80;
            bunifuCustomDataGrid1.Columns[2].Width = 80;
            bunifuCustomDataGrid1.Columns[3].Width = 90;
            bunifuCustomDataGrid1.Columns[4].Width = 84;
            bunifuCustomDataGrid1.Columns[5].Width = 250;
            bunifuCustomDataGrid1.Columns[6].Width = 88;

            bunifuCustomDataGrid2.Columns[0].Width = 60;
            bunifuCustomDataGrid2.Columns[1].Width = 70;
            bunifuCustomDataGrid2.Columns[2].Width = 380;
        }
        private string totalArti()
        {
            int tot = 0;
            for (int i = 0; i < pln.MostrarProductoFitro("").Count; i++)
            {
                tot += pln.MostrarProductoFitro("")[i].Cantidad;
            }
            return tot.ToString(); ;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.CurrentRow.Selected == false)
            {
                MessageBox.Show("Seleccione el producto que desea modificar.");
            }
            else
            {
                FrmEditProducto ep = new FrmEditProducto();
                ep.val = 2;
                ep.pa = bunifuCustomDataGrid1.CurrentRow.DataBoundItem as Producto;
                ep.ShowDialog();
                cargarProductos("");
                lbNum.Text = totalArti();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.CurrentRow.Selected == false)
            {
                MessageBox.Show("Seleccione el articulo que desea eliminar.");
            }
            else
            {
                try
                {
                    var res = MessageBox.Show("¿Esta seguro de eliminar este articulo?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Producto oc = bunifuCustomDataGrid1.CurrentRow.DataBoundItem as Producto;
                        if (pln.DeleteProducto(oc))
                        {
                            MessageBox.Show("Articulo Eliminado con exito");
                            cargarProductos("");
                            lbNum.Text = totalArti();
                        }
                        else
                        {
                            MessageBox.Show("Elimación cancelada...");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        public Mensaje p = new Mensaje();
        private Mensaje crearMensaje(int id)
        {
            p.ID_Mensaje = id;

            p.Mensajes = "Leído";

            return p;
        }
        private void bunifuCustomDataGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            if (bunifuCustomDataGrid2.CurrentRow == null)
            {
                MessageBox.Show("Por el momento, usted no tiene mensajes", "Mensaje");
            }
            if (bunifuCustomDataGrid2.CurrentRow != null)
            {
                for (int i = 0; i < mln.MostrarMensajeFitro("").Count; i++)
                {
                    if (mln.MostrarMensajeFitro("")[i].ID_Mensaje == (int)bunifuCustomDataGrid2.CurrentRow.Cells[0].Value)
                    {
                        MessageBox.Show(bunifuCustomDataGrid2.CurrentRow.Cells[2].Value.ToString(), "Mensaje");
                        Mensaje m = crearMensaje((int)bunifuCustomDataGrid2.CurrentRow.Cells[0].Value);
                        mln.UpdateEstadoMsm(m);
                    }
                }
            }

            cargarMensajes();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmReporte fr = new FrmReporte();
            fr.email = correoUsuario;
            fr.ShowDialog();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bunifuCustomDataGrid1.CurrentRow == null)
            {
                MessageBox.Show("Por el momento no se han ingresado artículos", "Mensaje");
            }
        }
    }
}
